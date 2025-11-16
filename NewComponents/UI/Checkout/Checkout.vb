Imports MySql.Data.MySqlClient

Public Class Checkout

    Private bs As New BindingSource()
    Private cartDt As New DataTable() ' DataTable for cart
    Private Sub Checkout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillTable()
        InitializeCartTable()
        SetHeaderSize(ViewPetTable)
        TableProductDesign.ApplyModernDarkTableStyle(ViewPetTable)
        TableProductDesign.ApplyModernDarkTableStyle(CartTable)
        UpdateGrandTotal()

    End Sub

    ' ✅ LOAD PETS INTO DATAGRIDVIEW
    Public Sub FillTable()
        Dim sql As String = "
SELECT 
    p.pet_id AS ProductID,
    p.pet_name AS Product,
    c.category_name AS Category,
    p.selling_price AS Price,
    IFNULL((
        SELECT SUM(ps.quantity)
        FROM pet_stock ps
        WHERE ps.pet_id = p.pet_id
    ), 0) AS Stock
FROM pets p
LEFT JOIN pet_categories c ON p.category_id = c.category_id
ORDER BY p.pet_name;
"

        ' Load the data
        Dim dt As DataTable = FillData(sql, ViewPetTable)

        ' Bind to BindingSource
        bs.DataSource = dt
        ViewPetTable.DataSource = bs

        ' Hide the ID column
        If ViewPetTable.Columns.Contains("ProductID") Then
            ViewPetTable.Columns("ProductID").Visible = False
        End If
    End Sub



    ' ✅ SET DATAGRIDVIEW COLUMN WIDTHS
    Public Sub SetHeaderSize(ByVal dgv As DataGridView)
        If dgv.Columns.Contains("Product") Then dgv.Columns("Product").Width = 230
        If dgv.Columns.Contains("Category_Name") Then dgv.Columns("Category").Width = 170
        If dgv.Columns.Contains("Selling_Price") Then dgv.Columns("Price").Width = 80
        If dgv.Columns.Contains("Total_Stock") Then dgv.Columns("Stock").Width = 70
    End Sub

    ' ✅ SEARCH FUNCTIONALITY
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim searchTerm As String = TextBox1.Text.Trim().Replace("'", "''")
        ApplyFilterToBindingSource(searchTerm, bs, "Product", "Category")
    End Sub

    Private Sub ViewProdTable_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ViewPetTable.CellClick
        If e.RowIndex < 0 Then Return ' Ignore header clicks

        Try
            Dim row As DataGridViewRow = ViewPetTable.Rows(e.RowIndex)

            Dim productId As Integer = Convert.ToInt32(row.Cells("ProductID").Value)
            Dim productName As String = row.Cells("Product").Value.ToString()
            Dim price As Decimal = Convert.ToDecimal(row.Cells("Price").Value)

            ' Check if product already in cart
            Dim existingRow As DataRow = Nothing
            For Each cartRow As DataRow In cartDt.Rows
                If Convert.ToInt32(cartRow("ProductID")) = productId Then
                    existingRow = cartRow
                    Exit For
                End If
            Next

            If existingRow IsNot Nothing Then
                ' Increase quantity if already in cart
                existingRow("QTY") = Convert.ToInt32(existingRow("QTY")) + 1
                existingRow("Total") = Convert.ToDecimal(existingRow("Price")) * Convert.ToInt32(existingRow("QTY"))
            Else
                ' Add new row to cart
                Dim newRow As DataRow = cartDt.NewRow()
                newRow("ProductID") = productId
                newRow("Product") = productName
                newRow("Price") = price
                newRow("QTY") = 1
                newRow("Total") = price * 1
                cartDt.Rows.Add(newRow)
            End If

        Catch ex As Exception
            MessageBox.Show("Error adding to cart: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        UpdateGrandTotal()
    End Sub

    ' ✅ Update total when quantity is changed
    Private Sub CartTable_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles CartTable.CellValueChanged
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Try
            If CartTable.Columns(e.ColumnIndex).Name = "QTY" Then
                Dim row As DataGridViewRow = CartTable.Rows(e.RowIndex)

                Dim quantity As Integer
                If Integer.TryParse(row.Cells("QTY").Value?.ToString(), quantity) AndAlso quantity > 0 Then
                    Dim price As Decimal = Convert.ToDecimal(row.Cells("Price").Value)
                    row.Cells("Total").Value = price * quantity
                Else
                    MessageBox.Show("Please enter a valid quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    row.Cells("QTY").Value = 1
                    row.Cells("Total").Value = Convert.ToDecimal(row.Cells("Price").Value)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error updating quantity: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        UpdateGrandTotal()
    End Sub

    ' ✅ Remove item from cart when X button is clicked
    Private Sub CartTable_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles CartTable.CellContentClick
        If e.RowIndex < 0 Then Return ' Ignore header clicks

        Try
            If CartTable.Columns(e.ColumnIndex).Name = "Delete" Then
                Dim result As DialogResult = MessageBox.Show("Remove this item from cart?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    cartDt.Rows.RemoveAt(e.RowIndex)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error removing item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        UpdateGrandTotal()
    End Sub

    Public Sub UpdateGrandTotal()
        Dim grandTotal As Decimal = 0

        ' Sum all totals in cart
        For Each row As DataRow In cartDt.Rows
            If row("Total") IsNot DBNull.Value Then
                grandTotal += Convert.ToDecimal(row("Total"))
            End If
        Next

        ' Display grand total
        GrandTotalLbl.Text = grandTotal.ToString("N2")
    End Sub

    Private Sub InitializeCartTable()
        ' Create cart DataTable structure
        cartDt.Columns.Add("ProductID", GetType(Integer))
        cartDt.Columns.Add("Product", GetType(String))
        cartDt.Columns.Add("Price", GetType(Decimal))
        cartDt.Columns.Add("QTY", GetType(Integer))
        cartDt.Columns.Add("Total", GetType(Decimal))

        ' Bind to CartTable
        CartTable.DataSource = cartDt

        ' Add Delete button column
        Dim deleteBtn As New DataGridViewButtonColumn()
        deleteBtn.Name = "Delete"
        deleteBtn.HeaderText = ""
        deleteBtn.Text = "✕"
        deleteBtn.UseColumnTextForButtonValue = True
        deleteBtn.Width = 50
        CartTable.Columns.Add(deleteBtn)

        ' Hide ProductID
        If CartTable.Columns.Contains("ProductID") Then
            CartTable.Columns("ProductID").Visible = False
        End If

        ' Set column widths
        If CartTable.Columns.Contains("Product") Then
            CartTable.Columns("Product").Width = 160
            CartTable.Columns("Product").ReadOnly = True
        End If

        If CartTable.Columns.Contains("Price") Then
            CartTable.Columns("Price").Width = 100
            CartTable.Columns("Price").ReadOnly = True
            CartTable.Columns("Price").DefaultCellStyle.Format = "N2"
        End If

        If CartTable.Columns.Contains("QTY") Then
            CartTable.Columns("QTY").Width = 60
            CartTable.Columns("QTY").ReadOnly = False
        End If

        If CartTable.Columns.Contains("Total") Then
            CartTable.Columns("Total").Width = 100
            CartTable.Columns("Total").ReadOnly = True
            CartTable.Columns("Total").DefaultCellStyle.Format = "N2"
        End If
    End Sub

    Private Sub CheckoutBtn_Click(sender As Object, e As EventArgs) Handles CheckoutBtn.Click
        Try
            ' Validate cart is not empty
            If cartDt.Rows.Count = 0 Then
                MessageBox.Show("Cart is empty. Please add products before checkout.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Confirm checkout
            Dim grandTotal As Decimal = Convert.ToDecimal(GrandTotalLbl.Text)
            Dim result As DialogResult = MessageBox.Show(
                "Proceed with checkout?" & vbCrLf & vbCrLf &
                "Total Amount: ₱" & grandTotal.ToString("N2"),
                "Confirm Checkout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If result <> DialogResult.Yes Then Return

            ' Process each item in cart
            Dim allSuccess As Boolean = True
            Dim errorMessages As New List(Of String)

            For Each cartRow As DataRow In cartDt.Rows
                Dim petId As Integer = Convert.ToInt32(cartRow("ProductID"))
                Dim quantity As Integer = Convert.ToInt32(cartRow("QTY"))
                Dim salePrice As Decimal = Convert.ToDecimal(cartRow("Price"))

                ' 1️⃣ Check available stock
                Dim availableStock As Object = GlobalCrud.ExecuteScalar(
                    "SELECT IFNULL(SUM(quantity), 0) FROM pet_stock WHERE pet_id = @petId;",
                    New MySqlParameter("@petId", petId))

                Dim stockQty As Integer = If(availableStock IsNot Nothing, Convert.ToInt32(availableStock), 0)

                If stockQty < quantity Then
                    Dim petName As String = cartRow("Product").ToString()
                    errorMessages.Add($"Insufficient stock for '{petName}'. Available: {stockQty}, Requested: {quantity}")
                    allSuccess = False
                    Continue For
                End If

                ' 2️⃣ Insert into pet_sales table
                Dim insertSale As String = "INSERT INTO pet_sales (pet_id, quantity, sale_price) VALUES (@petId, @quantity, @salePrice);"
                Dim saleSuccess As Boolean = GlobalCrud.ExecuteNonQuery(insertSale,
                    New MySqlParameter("@petId", petId),
                    New MySqlParameter("@quantity", quantity),
                    New MySqlParameter("@salePrice", salePrice))

                If Not saleSuccess Then
                    errorMessages.Add($"Failed to record sale for pet ID {petId}")
                    allSuccess = False
                    Continue For
                End If

                ' 3️⃣ Deduct from pet_stock (FIFO - earliest expiry first)
                Dim remainingQty As Integer = quantity

                Dim stockBatches As DataTable = GlobalCrud.ExecuteQuery(
                    "SELECT batch_id, quantity FROM pet_stock WHERE pet_id = @petId AND quantity > 0 ORDER BY expiry_date ASC;",
                    New MySqlParameter("@petId", petId))

                For Each batchRow As DataRow In stockBatches.Rows
                    If remainingQty <= 0 Then Exit For

                    Dim batchId As Integer = Convert.ToInt32(batchRow("batch_id"))
                    Dim batchQty As Integer = Convert.ToInt32(batchRow("quantity"))

                    If batchQty >= remainingQty Then
                        ' Batch has enough stock
                        Dim updateBatch As String = "UPDATE pet_stock SET quantity = quantity - @qty WHERE batch_id = @batchId;"
                        GlobalCrud.ExecuteNonQuery(updateBatch,
                            New MySqlParameter("@qty", remainingQty),
                            New MySqlParameter("@batchId", batchId))
                        remainingQty = 0
                    Else
                        ' Use entire batch
                        Dim updateBatch As String = "UPDATE pet_stock SET quantity = 0 WHERE batch_id = @batchId;"
                        GlobalCrud.ExecuteNonQuery(updateBatch,
                            New MySqlParameter("@batchId", batchId))
                        remainingQty -= batchQty
                    End If
                Next

                If remainingQty > 0 Then
                    errorMessages.Add($"Stock deduction failed for pet ID {petId}")
                    allSuccess = False
                End If
            Next

            ' 4️⃣ Show results
            If allSuccess Then
                MessageBox.Show("Checkout successful!" & vbCrLf & "Total: ₱" & grandTotal.ToString("N2"), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cartDt.Clear()
                UpdateGrandTotal()
                FillTable()
            Else
                MessageBox.Show("Checkout completed with errors:" & vbCrLf & vbCrLf & String.Join(vbCrLf, errorMessages), "Checkout Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Error during checkout: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class
