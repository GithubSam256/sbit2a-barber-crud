Public Class DashBoard2

    Private bs As New BindingSource()

    Private Sub DashBoard2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillTable()
        SetHeaderSize(ViewPetTable)
        TableProductDesign.ApplyModernDarkTableStyle(ViewPetTable)
        'TableWithActions.TableWithButtons(ViewPetTable)
    End Sub

    ' ✅ LOAD PETS INTO DATAGRIDVIEW
    Public Sub FillTable()
        Dim sql As String = "
SELECT 
    p.pet_id AS ID,
    p.pet_name AS Pet_Name,
    c.category_name AS Category_Name,
    p.selling_price AS Selling_Price,
    p.cost_price AS Cost_Price,
    p.reorder_level AS Reorder_Level,
    COALESCE(SUM(ps.quantity), 0) AS Total_Stock,
    MIN(ps.expiry_date) AS Expiry_Date
FROM pets p
LEFT JOIN pet_categories c ON p.category_id = c.category_id
LEFT JOIN pet_stock ps ON ps.pet_id = p.pet_id
GROUP BY p.pet_id, p.pet_name, c.category_name, p.selling_price, p.cost_price, p.reorder_level
ORDER BY p.pet_name;
"

        ' Load the data
        Dim dt As DataTable = FillData(sql, ViewPetTable)

        ' Bind to BindingSource
        bs.DataSource = dt
        ViewPetTable.DataSource = bs
    End Sub

    ' ✅ SET DATAGRIDVIEW COLUMN WIDTHS
    Public Sub SetHeaderSize(ByVal dgv As DataGridView)
        If dgv.Columns.Contains("Pet_Name") Then dgv.Columns("Pet_Name").Width = 190
        If dgv.Columns.Contains("Category_Name") Then dgv.Columns("Category_Name").Width = 190
        If dgv.Columns.Contains("Selling_Price") Then dgv.Columns("Selling_Price").Width = 130
        If dgv.Columns.Contains("Cost_Price") Then dgv.Columns("Cost_Price").Width = 130
        If dgv.Columns.Contains("Reorder_Level") Then dgv.Columns("Reorder_Level").Width = 150
        If dgv.Columns.Contains("Total_Stock") Then dgv.Columns("Total_Stock").Width = 100
        If dgv.Columns.Contains("Expiry_Date") Then dgv.Columns("Expiry_Date").Width = 130
    End Sub

    ' ✅ SEARCH FUNCTIONALITY
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim searchTerm As String = TextBox1.Text.Trim().Replace("'", "''")
        ApplyFilterToBindingSource(searchTerm, bs, "Pet_Name", "Category_Name")
    End Sub

    Private Sub Panel8_Paint(sender As Object, e As PaintEventArgs) Handles Panel8.Paint

    End Sub
End Class
