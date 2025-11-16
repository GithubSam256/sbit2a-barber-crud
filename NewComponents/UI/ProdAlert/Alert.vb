Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Alert

    Private bs1 As New BindingSource()
    Private bs2 As New BindingSource()

    Private Sub Alert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1️⃣ Fill DataTables
        FillLowOutTable()
        FillExpSoonExpTable()

        ' 2️⃣ Apply modern alert table style AFTER DataSource is set
        AlertTableDesign.ApplyAlertTableStyle(StockTable, "Status")
        AlertTableDesign.ApplyAlertTableStyle(ExpTable, "Status")

        ' 3️⃣ Set column widths and alignment
        SetHeaderSizeLowOut(StockTable)
        SetHeaderSizeExpSoonExp(ExpTable)

        ' 4️⃣ Force refresh to ensure CellFormatting triggers
        StockTable.Refresh()
        ExpTable.Refresh()
    End Sub

    ' ✅ Table 1: LOW and OUT of Stock Pets
    Public Sub FillLowOutTable()
        Dim sql As String = "
        SELECT 
            p.pet_id AS PetID,
            p.pet_name AS Pet, 
            c.category_name AS Category, 
            COALESCE((
                SELECT SUM(ps_inner.quantity) 
                FROM pet_stock ps_inner 
                WHERE ps_inner.pet_id = p.pet_id
            ), 0) AS Stock,
            p.reorder_level AS ReorderLevel,
            CASE
                WHEN COALESCE((SELECT SUM(ps_inner.quantity) FROM pet_stock ps_inner WHERE ps_inner.pet_id = p.pet_id), 0) = 0 THEN 'OUT'
                WHEN COALESCE((SELECT SUM(ps_inner.quantity) FROM pet_stock ps_inner WHERE ps_inner.pet_id = p.pet_id), 0) <= p.reorder_level THEN 'LOW'
                ELSE 'OK'
            END AS Status
        FROM pets p
        LEFT JOIN pet_categories c ON p.category_id = c.category_id
        HAVING Status IN ('OUT', 'LOW')
        ORDER BY 
            CASE 
                WHEN Status = 'OUT' THEN 1
                WHEN Status = 'LOW' THEN 2
                ELSE 3
            END,
            p.pet_name;"

        Dim dt As DataTable = FillData(sql, StockTable)
        bs1.DataSource = dt
        StockTable.DataSource = bs1

        ' Hide PetID
        If StockTable.Columns.Contains("PetID") Then
            StockTable.Columns("PetID").Visible = False
        End If
    End Sub

    ' ✅ Table 2: EXPIRED and SOON TO EXPIRE Pets
    Public Sub FillExpSoonExpTable()
        Dim sql As String = "
        SELECT DISTINCT
            p.pet_id AS PetID,
            p.pet_name AS Pet, 
            c.category_name AS Category,
            ps.expiry_date AS Expiration,
            CASE
                WHEN ps.expiry_date < CURDATE() THEN 'EXP'
                WHEN ps.expiry_date BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 30 DAY) THEN 'SOONEXP'
                ELSE 'OK'
            END AS Status
        FROM pets p
        LEFT JOIN pet_categories c ON p.category_id = c.category_id
        INNER JOIN pet_stock ps ON p.pet_id = ps.pet_id
        WHERE ps.quantity > 0
        AND (
            ps.expiry_date < CURDATE() 
            OR ps.expiry_date BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 30 DAY)
        )
        ORDER BY 
            CASE 
                WHEN ps.expiry_date < CURDATE() THEN 1
                WHEN ps.expiry_date BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 30 DAY) THEN 2
                ELSE 3
            END,
            ps.expiry_date ASC,
            p.pet_name;"

        Dim dt As DataTable = FillData(sql, ExpTable)
        bs2.DataSource = dt
        ExpTable.DataSource = bs2

        ' Hide PetID
        If ExpTable.Columns.Contains("PetID") Then
            ExpTable.Columns("PetID").Visible = False
        End If
    End Sub

    ' ✅ Header Sizing for LOW/OUT table
    Public Sub SetHeaderSizeLowOut(ByVal dgv As DataGridView)
        If dgv.Columns.Count >= 5 Then
            dgv.Columns("Pet").Width = 250
            dgv.Columns("Category").Width = 180
            dgv.Columns("Stock").Width = 100
            dgv.Columns("ReorderLevel").Width = 120
            dgv.Columns("Status").Width = 100

            dgv.Columns("Stock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv.Columns("ReorderLevel").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv.Columns("Status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
    End Sub

    ' ✅ Header Sizing for EXPIRED / SOON TO EXPIRE table
    Public Sub SetHeaderSizeExpSoonExp(ByVal dgv As DataGridView)
        If dgv.Columns.Count >= 4 Then
            dgv.Columns("Pet").Width = 250
            dgv.Columns("Category").Width = 180
            dgv.Columns("Expiration").Width = 150
            dgv.Columns("Status").Width = 100

            dgv.Columns("Expiration").DefaultCellStyle.Format = "MMM dd, yyyy"
            dgv.Columns("Expiration").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv.Columns("Status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
    End Sub

    ' ✅ Search functionality
    Private Sub SearchBar_TextChanged(sender As Object, e As EventArgs) Handles SearchBar.TextChanged
        SearchData.ApplyFilterToBindingSource(SearchBar.Text, bs1, "Pet", "Category", "Status")
    End Sub


End Class
