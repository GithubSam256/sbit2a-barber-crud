Imports MySql.Data.MySqlClient
Imports Mysqlx
Imports Mysqlx.XDevAPI.Relational

Public Class Product

    Private bs As New BindingSource()

    Private Sub Category_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProducts(PetTable)
        SetHeaderSize(PetTable)


        TableWithActions.TableWithButtons(PetTable, AddressOf UpdateProduct, AddressOf DeleteCategory)
    End Sub

    Public Sub LoadProducts(dgv As DataGridView)
        Dim sql As String = "
        SELECT 
            p.pet_id AS ID,
            p.pet_name AS Product,
            p.category_id AS CategoryID,            
            c.category_name AS Category,
            p.selling_price AS Price,
            p.cost_price AS Cost,
            p.reorder_level AS Threshold,
            SUM(ps.quantity) AS Stock,
            MIN(ps.expiry_date) AS ExpDate
        FROM pets p
        LEFT JOIN pet_categories c ON p.category_id = c.category_id
        LEFT JOIN pet_stock ps ON ps.pet_id = p.pet_id
        GROUP BY 
            p.pet_id, p.pet_name, p.category_id, c.category_name, p.selling_price, p.cost_price, p.reorder_level
        ORDER BY c.category_name, p.pet_name;
    "

        Dim dt As DataTable = GlobalCrud.ExecuteQuery(sql, Nothing)
        bs.DataSource = dt
        dgv.DataSource = bs

        If dgv.Columns.Contains("CategoryID") Then
            dgv.Columns("CategoryID").Visible = False
        End If
    End Sub

    Public Sub DeleteCategory(dgv As DataGridView, rowIndex As Integer)
        Dim petId As Integer = CInt(dgv.Rows(rowIndex).Cells("ID").Value)

        If MessageBox.Show("Are you sure you want to delete this pet?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Dim sql As String = "DELETE FROM pets WHERE pet_id = @id"
            Dim param As New MySqlParameter("@id", petId)

            Dim success As Boolean = GlobalCrud.ExecuteNonQuery(sql, param)

            If success Then
                MessageBox.Show("Pet deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadProducts(dgv)
            Else
                MessageBox.Show("Failed to delete pet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Public Sub SetHeaderSize(ByVal dgv As DataGridView)
        If dgv.Columns.Count > 0 Then
            If dgv.Columns.Contains("ID") Then dgv.Columns("ID").Width = 50
            If dgv.Columns.Contains("Product") Then dgv.Columns("Product").Width = 190
            If dgv.Columns.Contains("Category") Then dgv.Columns("Category").Width = 150
            If dgv.Columns.Contains("Price") Then dgv.Columns("Price").Width = 85
            If dgv.Columns.Contains("Cost") Then dgv.Columns("Cost").Width = 85
            If dgv.Columns.Contains("Threshold") Then dgv.Columns("Threshold").Width = 100
            If dgv.Columns.Contains("Stock") Then dgv.Columns("Stock").Width = 85
            If dgv.Columns.Contains("ExpDate") Then dgv.Columns("ExpDate").Width = 125
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        InsertProduct(PetTable)
    End Sub

    Public Sub UpdateProduct(dgv As DataGridView, rowIndex As Integer)
        Try
            If rowIndex < 0 OrElse rowIndex >= dgv.Rows.Count Then
                MessageBox.Show("Please select a valid pet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If dgv.Rows(rowIndex).Cells("ID").Value Is Nothing OrElse IsDBNull(dgv.Rows(rowIndex).Cells("ID").Value) Then
                MessageBox.Show("Cannot edit pet without ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim petId As Integer = CInt(dgv.Rows(rowIndex).Cells("ID").Value)
            Dim currentName As String = If(dgv.Rows(rowIndex).Cells("Product").Value IsNot Nothing, dgv.Rows(rowIndex).Cells("Product").Value.ToString(), "")
            Dim currentPrice As Decimal = If(dgv.Rows(rowIndex).Cells("Price").Value IsNot Nothing AndAlso Not IsDBNull(dgv.Rows(rowIndex).Cells("Price").Value), CDec(dgv.Rows(rowIndex).Cells("Price").Value), 0D)
            Dim currentCost As Decimal = If(dgv.Rows(rowIndex).Cells("Cost").Value IsNot Nothing AndAlso Not IsDBNull(dgv.Rows(rowIndex).Cells("Cost").Value), CDec(dgv.Rows(rowIndex).Cells("Cost").Value), 0D)
            Dim currentReorderLevel As Integer = If(dgv.Rows(rowIndex).Cells("Threshold").Value IsNot Nothing AndAlso Not IsDBNull(dgv.Rows(rowIndex).Cells("Threshold").Value), CInt(dgv.Rows(rowIndex).Cells("Threshold").Value), 0)
            Dim currentCategoryId As Integer = If(dgv.Rows(rowIndex).Cells("CategoryID").Value IsNot Nothing AndAlso Not IsDBNull(dgv.Rows(rowIndex).Cells("CategoryID").Value), CInt(dgv.Rows(rowIndex).Cells("CategoryID").Value), 0)

            Using editForm As New ProductPopUpForm(petId, currentName, currentPrice, currentCost, currentReorderLevel, currentCategoryId)
                If editForm.ShowDialog() = DialogResult.OK Then
                    Dim newName As String = editForm.ProductNamee
                    Dim newPrice As Decimal = editForm.Price
                    Dim newCost As Decimal = editForm.Cost
                    Dim newReorderLevel As Integer = editForm.ReorderLevel
                    Dim newCategoryId As Integer = editForm.CategoryId
                    Dim newQuantity As Integer = editForm.Quantity
                    Dim newExpiryDate As Date = editForm.ExpiryDate

                    If String.IsNullOrWhiteSpace(newName) Then
                        MessageBox.Show("Pet name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    If newCategoryId = 0 Then
                        MessageBox.Show("Please select a valid category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    ' 1. UPDATE pet details
                    Dim updatePetSql As String = "UPDATE pets SET pet_name = @name, selling_price = @price, cost_price = @cost, reorder_level = @reorder, category_id = @category WHERE pet_id = @id"
                    Dim updateParams() As MySqlParameter = {
                        New MySqlParameter("@name", newName),
                        New MySqlParameter("@price", newPrice),
                        New MySqlParameter("@cost", newCost),
                        New MySqlParameter("@reorder", newReorderLevel),
                        New MySqlParameter("@category", newCategoryId),
                        New MySqlParameter("@id", petId)
                    }

                    Dim updateSuccess As Boolean = GlobalCrud.ExecuteNonQuery(updatePetSql, updateParams)

                    If updateSuccess Then
                        ' 2. If adding new stock, record purchase and stock
                        If newQuantity > 0 Then
                            ' Insert into pet_purchases table
                            Dim purchaseSql As String = "INSERT INTO pet_purchases (pet_id, quantity, purchase_price) VALUES (@pet_id, @quantity, @purchase_price); SELECT LAST_INSERT_ID();"
                            Dim purchaseParams() As MySqlParameter = {
                                New MySqlParameter("@pet_id", petId),
                                New MySqlParameter("@quantity", newQuantity),
                                New MySqlParameter("@purchase_price", newCost)
                            }

                            Dim purchaseIdObj As Object = GlobalCrud.ExecuteScalar(purchaseSql, purchaseParams)

                            If purchaseIdObj IsNot Nothing Then
                                Dim purchaseId As Integer = Convert.ToInt32(purchaseIdObj)

                                ' Insert into pet_stock with purchase reference
                                Dim insertStockSql As String = "INSERT INTO pet_stock (pet_id, quantity, expiry_date, purchase_id) VALUES (@pet_id, @quantity, @expiry, @purchase_id)"
                                Dim stockParams() As MySqlParameter = {
                                    New MySqlParameter("@pet_id", petId),
                                    New MySqlParameter("@quantity", newQuantity),
                                    New MySqlParameter("@expiry", newExpiryDate),
                                    New MySqlParameter("@purchase_id", purchaseId)
                                }

                                Dim stockSuccess As Boolean = GlobalCrud.ExecuteNonQuery(insertStockSql, stockParams)

                                If stockSuccess Then
                                    MessageBox.Show("Pet updated, purchase recorded, and new stock added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Else
                                    MessageBox.Show("Pet updated and purchase recorded but failed to add stock entry.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            Else
                                MessageBox.Show("Pet updated but failed to record purchase.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else
                            MessageBox.Show("Pet updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        LoadProducts(dgv)
                    Else
                        MessageBox.Show("Failed to update pet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error updating pet: " & ex.Message & vbCrLf & ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub InsertProduct(dgv As DataGridView)
        Using insertForm As New ProductPopUpForm()
            If insertForm.ShowDialog() = DialogResult.OK Then
                Try
                    Dim petName As String = insertForm.ProductNamee
                    Dim price As Decimal = insertForm.Price
                    Dim cost As Decimal = insertForm.Cost
                    Dim reorderLevel As Integer = insertForm.ReorderLevel
                    Dim categoryId As Integer = insertForm.CategoryId
                    Dim quantity As Integer = insertForm.Quantity
                    Dim expiryDate As Date = insertForm.ExpiryDate

                    ' 1. INSERT pet first
                    Dim petSql As String = "INSERT INTO pets (pet_name, selling_price, cost_price, reorder_level, category_id) VALUES (@name, @price, @cost, @reorder, @category); SELECT LAST_INSERT_ID();"
                    Dim petParams() As MySqlParameter = {
                        New MySqlParameter("@name", petName),
                        New MySqlParameter("@price", price),
                        New MySqlParameter("@cost", cost),
                        New MySqlParameter("@reorder", reorderLevel),
                        New MySqlParameter("@category", categoryId)
                    }

                    Dim petIdObj As Object = GlobalCrud.ExecuteScalar(petSql, petParams)

                    If petIdObj IsNot Nothing Then
                        Dim petId As Integer = Convert.ToInt32(petIdObj)

                        ' 2. INSERT into pet_purchases table
                        Dim purchaseSql As String = "INSERT INTO pet_purchases (pet_id, quantity, purchase_price) VALUES (@pet_id, @quantity, @purchase_price); SELECT LAST_INSERT_ID();"
                        Dim purchaseParams() As MySqlParameter = {
                            New MySqlParameter("@pet_id", petId),
                            New MySqlParameter("@quantity", quantity),
                            New MySqlParameter("@purchase_price", cost)
                        }

                        'sam 


                        Dim purchaseIdObj As Object = GlobalCrud.ExecuteScalar(purchaseSql, purchaseParams)

                        If purchaseIdObj IsNot Nothing Then
                            Dim purchaseId As Integer = Convert.ToInt32(purchaseIdObj)

                            ' 3. INSERT into pet_stock with purchase reference
                            Dim stockSql As String = "INSERT INTO pet_stock (pet_id, quantity, expiry_date, purchase_id) VALUES (@pet_id, @quantity, @expiry, @purchase_id)"
                            Dim stockParams() As MySqlParameter = {
                                New MySqlParameter("@pet_id", petId),
                                New MySqlParameter("@quantity", quantity),
                                New MySqlParameter("@expiry", expiryDate),
                                New MySqlParameter("@purchase_id", purchaseId)
                            }

                            Dim stockSuccess As Boolean = GlobalCrud.ExecuteNonQuery(stockSql, stockParams)

                            If stockSuccess Then
                                MessageBox.Show("Pet, purchase, and stock added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                LoadProducts(dgv)
                            Else
                                MessageBox.Show("Pet and purchase created but stock entry failed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else
                            MessageBox.Show("Pet created but purchase recording failed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Failed to add pet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Catch ex As Exception
                    MessageBox.Show("Error adding pet: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub



    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim searchTerm As String = TextBox1.Text.Trim().Replace("'", "''")
        SearchData.ApplyFilterToBindingSource(searchTerm, bs, "Product")
    End Sub
End Class