Imports MySql.Data.MySqlClient

Public Class Transactions

    Private bsSales As New BindingSource()
    Private bsRestocks As New BindingSource()

    Private Sub Transactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillSalesTable()
        FillRestocksTable()

        TableProductDesign.ApplyModernDarkTableStyle(ViewSalesTable)
        TableProductDesign.ApplyModernDarkTableStyle(ViewRestocksTable)

        FormatSalesColumns()
        FormatRestocksColumns()
    End Sub

    ' ===== 1️⃣ SALES TRANSACTIONS TABLE =====
    Public Sub FillSalesTable()
        Dim sql As String = "
        SELECT 
            s.sale_id AS TransactionID,
            p.pet_name AS PetName,
            c.category_name AS Category,
            s.quantity AS Qty,
            s.sale_price AS UnitPrice,
            s.total_price AS Total,
            s.sale_date AS Date,
            CONCAT('Sold ', s.quantity, 'x ', p.pet_name, ' @ ₱', FORMAT(s.sale_price, 2)) AS Remarks
        FROM pet_sales s
        INNER JOIN pets p ON s.pet_id = p.pet_id
        LEFT JOIN pet_categories c ON p.category_id = c.category_id
        ORDER BY s.sale_date DESC;"

        Try
            Dim dt As DataTable = FillData(sql, ViewSalesTable)
            If dt IsNot Nothing Then
                bsSales.DataSource = dt
                ViewSalesTable.DataSource = bsSales
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading sales: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatSalesColumns()
        If ViewSalesTable.Columns.Contains("TransactionID") Then
            ViewSalesTable.Columns("TransactionID").HeaderText = "Sale ID"
            ViewSalesTable.Columns("TransactionID").Width = 80
        End If
        If ViewSalesTable.Columns.Contains("PetName") Then
            ViewSalesTable.Columns("PetName").HeaderText = "Pet"
            ViewSalesTable.Columns("PetName").Width = 200
        End If
        If ViewSalesTable.Columns.Contains("Category") Then
            ViewSalesTable.Columns("Category").HeaderText = "Category"
            ViewSalesTable.Columns("Category").Width = 150
        End If
        If ViewSalesTable.Columns.Contains("Qty") Then
            ViewSalesTable.Columns("Qty").Width = 80
            ViewSalesTable.Columns("Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        If ViewSalesTable.Columns.Contains("UnitPrice") Then
            ViewSalesTable.Columns("UnitPrice").HeaderText = "Price"
            ViewSalesTable.Columns("UnitPrice").Width = 100
            ViewSalesTable.Columns("UnitPrice").DefaultCellStyle.Format = "₱#,##0.00"
        End If
        If ViewSalesTable.Columns.Contains("Total") Then
            ViewSalesTable.Columns("Total").Width = 120
            ViewSalesTable.Columns("Total").DefaultCellStyle.Format = "₱#,##0.00"
        End If
        If ViewSalesTable.Columns.Contains("Date") Then
            ViewSalesTable.Columns("Date").Width = 150
            ViewSalesTable.Columns("Date").DefaultCellStyle.Format = "MMM dd, yyyy hh:mm tt"
        End If
        If ViewSalesTable.Columns.Contains("Remarks") Then
            ViewSalesTable.Columns("Remarks").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If
    End Sub

    ' ===== 2️⃣ RESTOCK TRANSACTIONS TABLE =====
    Public Sub FillRestocksTable()
        Dim sql As String = "
        SELECT 
            ps.batch_id AS BatchID,
            p.pet_name AS PetName,
            c.category_name AS Category,
            ps.quantity AS Qty,
            ps.expiry_date AS ExpirationDate,
            CASE 
                WHEN (SELECT COUNT(*) FROM pet_stock ps2 WHERE ps2.pet_id = ps.pet_id AND ps2.batch_id < ps.batch_id) = 0 
                THEN 'Initial Stock'
                ELSE 'Restock'
            END AS Type,
            CONCAT(
                CASE 
                    WHEN (SELECT COUNT(*) FROM pet_stock ps2 WHERE ps2.pet_id = ps.pet_id AND ps2.batch_id < ps.batch_id) = 0 
                    THEN 'Added '
                    ELSE 'Restocked '
                END,
                ps.quantity, 'x (Batch ', ps.batch_id, '), total ',
                (SELECT COALESCE(SUM(ps_total.quantity), 0) 
                 FROM pet_stock ps_total 
                 WHERE ps_total.pet_id = ps.pet_id 
                 AND ps_total.batch_id <= ps.batch_id),
                ' units.'
            ) AS Remarks
        FROM pet_stock ps
        INNER JOIN pets p ON ps.pet_id = p.pet_id
        LEFT JOIN pet_categories c ON p.category_id = c.category_id
        ORDER BY ps.batch_id DESC;"

        Try
            Dim dt As DataTable = FillData(sql, ViewRestocksTable)
            If dt IsNot Nothing Then
                bsRestocks.DataSource = dt
                ViewRestocksTable.DataSource = bsRestocks
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading restocks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatRestocksColumns()
        If ViewRestocksTable.Columns.Contains("BatchID") Then
            ViewRestocksTable.Columns("BatchID").HeaderText = "Batch ID"
            ViewRestocksTable.Columns("BatchID").Width = 80
        End If
        If ViewRestocksTable.Columns.Contains("PetName") Then
            ViewRestocksTable.Columns("PetName").HeaderText = "Pet"
            ViewRestocksTable.Columns("PetName").Width = 250
        End If
        If ViewRestocksTable.Columns.Contains("Category") Then
            ViewRestocksTable.Columns("Category").HeaderText = "Category"
            ViewRestocksTable.Columns("Category").Width = 150
        End If
        If ViewRestocksTable.Columns.Contains("Qty") Then
            ViewRestocksTable.Columns("Qty").Width = 80
            ViewRestocksTable.Columns("Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        If ViewRestocksTable.Columns.Contains("ExpirationDate") Then
            ViewRestocksTable.Columns("ExpirationDate").HeaderText = "Expiry Date"
            ViewRestocksTable.Columns("ExpirationDate").Width = 120
            ViewRestocksTable.Columns("ExpirationDate").DefaultCellStyle.Format = "MMM dd, yyyy"
        End If
        If ViewRestocksTable.Columns.Contains("Type") Then
            ViewRestocksTable.Columns("Type").Width = 100
        End If
        If ViewRestocksTable.Columns.Contains("Remarks") Then
            ViewRestocksTable.Columns("Remarks").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If
    End Sub

    ' ===== SEARCH FUNCTIONALITY =====
    Private Sub SearchSales_TextChanged(sender As Object, e As EventArgs) Handles SearchBar.TextChanged
        SearchData.ApplyFilterToBindingSource(SearchBar.Text, bsSales, "PetName", "Category", "Remarks")
    End Sub

    Private Sub SearchRestocks_TextChanged(sender As Object, e As EventArgs) Handles SearchBar1.TextChanged
        SearchData.ApplyFilterToBindingSource(SearchBar1.Text, bsRestocks, "PetName", "Category", "Type", "Remarks")
    End Sub

End Class
