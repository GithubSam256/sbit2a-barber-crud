Imports MySql.Data.MySqlClient
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Drawing

Module ChartsCRUD

    ' ✅ Load Pie Chart with Top 5 Pet Categories by Sales
    Public Sub LoadPieChart(pieChartPanel As Panel, backgroundColor As Color)
        Try
            ' Set panel background color
            pieChartPanel.BackColor = backgroundColor

            ' Get top 5 categories by total sales revenue
            Dim query As String = "
            SELECT 
                c.category_name,
                SUM(s.total_price) AS total_sales
            FROM pet_sales s
            INNER JOIN pets p ON s.pet_id = p.pet_id
            INNER JOIN pet_categories c ON p.category_id = c.category_id
            GROUP BY c.category_id, c.category_name
            ORDER BY total_sales DESC
            LIMIT 5;"

            Dim dt As DataTable = GlobalCrud.ExecuteQuery(query, Nothing)

            ' Get total sales for percentage calculation
            Dim totalSalesQuery As String = "SELECT IFNULL(SUM(total_price), 0) FROM pet_sales;"
            Dim totalSalesObj As Object = GlobalCrud.ExecuteScalar(totalSalesQuery, Nothing)
            Dim totalSales As Decimal = If(totalSalesObj IsNot Nothing, Convert.ToDecimal(totalSalesObj), 0)

            If totalSales = 0 Then
                MessageBox.Show("No pet sales data available for chart.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Compute top 5 and "Others"
            Dim top5Sales As Decimal = dt.AsEnumerable().Sum(Function(r) Convert.ToDecimal(r("total_sales")))
            Dim othersSales As Decimal = totalSales - top5Sales

            ' Prepare lists for chart data
            Dim categoryList As New List(Of String)
            Dim valueList As New List(Of Double)
            Dim colorList As New List(Of Color)

            Dim chartColors() As Color = {
                Color.FromArgb(255, 99, 132),   ' Red
                Color.FromArgb(54, 162, 235),   ' Blue
                Color.FromArgb(255, 206, 86),   ' Yellow
                Color.FromArgb(75, 192, 192),   ' Teal
                Color.FromArgb(153, 102, 255),  ' Purple
                Color.FromArgb(201, 203, 207)   ' Gray (Others)
            }

            Dim colorIndex As Integer = 0
            For Each row As DataRow In dt.Rows
                Dim categoryName As String = row("category_name").ToString()
                Dim salesValue As Decimal = Convert.ToDecimal(row("total_sales"))
                Dim percentage As Double = CDbl((salesValue / totalSales) * 100)

                categoryList.Add(categoryName)
                valueList.Add(percentage)
                colorList.Add(chartColors(colorIndex))
                colorIndex += 1
            Next

            If othersSales > 0 Then
                Dim othersPercentage As Double = CDbl((othersSales / totalSales) * 100)
                categoryList.Add("Others")
                valueList.Add(othersPercentage)
                colorList.Add(chartColors(5))
            End If

            ' Create the pie chart
            StaticChartModule.CreateSalesChart(
                pieChartPanel,
                categoryList.ToArray(),
                valueList.ToArray(),
                colorList.ToArray(),
                backgroundColor
            )

        Catch ex As Exception
            MessageBox.Show("Error loading pet sales pie chart: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ✅ Load Column Chart for Pet Stock Status
    Public Sub LoadColumnChart(columnChartPanel As Panel, chartTitle As String, Optional backgroundColor As Color = Nothing)
        Try
            ' Set panel background color (default to dark if not provided)
            columnChartPanel.BackColor = If(backgroundColor = Nothing, Color.FromArgb(28, 34, 44), backgroundColor)

            ' 🟠 Low Stock (<= reorder level but > 0)
            Dim lowStockQuery As String = "
            SELECT COUNT(DISTINCT p.pet_id)
            FROM pets p
            LEFT JOIN (
                SELECT pet_id, SUM(quantity) AS total_qty
                FROM pet_stock
                GROUP BY pet_id
            ) ps ON p.pet_id = ps.pet_id
            WHERE IFNULL(ps.total_qty, 0) <= p.reorder_level AND IFNULL(ps.total_qty, 0) > 0;"
            Dim lowStockObj As Object = GlobalCrud.ExecuteScalar(lowStockQuery, Nothing)
            Dim lowStock As Integer = If(lowStockObj IsNot Nothing, Convert.ToInt32(lowStockObj), 0)

            ' 🔴 Out of Stock (= 0)
            Dim outOfStockQuery As String = "
            SELECT COUNT(DISTINCT p.pet_id)
            FROM pets p
            LEFT JOIN (
                SELECT pet_id, SUM(quantity) AS total_qty
                FROM pet_stock
                GROUP BY pet_id
            ) ps ON p.pet_id = ps.pet_id
            WHERE IFNULL(ps.total_qty, 0) = 0;"
            Dim outOfStockObj As Object = GlobalCrud.ExecuteScalar(outOfStockQuery, Nothing)
            Dim outOfStock As Integer = If(outOfStockObj IsNot Nothing, Convert.ToInt32(outOfStockObj), 0)

            ' ⚫ Expired (expiry_date < today)
            Dim expiredQuery As String = "
            SELECT COUNT(DISTINCT pet_id)
            FROM pet_stock
            WHERE expiry_date < CURDATE() AND quantity > 0;"
            Dim expiredObj As Object = GlobalCrud.ExecuteScalar(expiredQuery, Nothing)
            Dim expired As Integer = If(expiredObj IsNot Nothing, Convert.ToInt32(expiredObj), 0)

            ' 🟡 Soon to Expire (within 30 days)
            Dim soonExpireQuery As String = "
            SELECT COUNT(DISTINCT pet_id)
            FROM pet_stock
            WHERE expiry_date BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 30 DAY) AND quantity > 0;"
            Dim soonExpireObj As Object = GlobalCrud.ExecuteScalar(soonExpireQuery, Nothing)
            Dim soonExpire As Integer = If(soonExpireObj IsNot Nothing, Convert.ToInt32(soonExpireObj), 0)

            ' Build the arrays for column chart
            Dim labels() As String = {"LOW", "OUT", "EXP", "SOONEXP"}
            Dim values() As Double = {lowStock, outOfStock, expired, soonExpire}
            Dim colors() As Color = {
                Color.Orange,   ' Low
                Color.Red,      ' Out
                Color.DarkRed,  ' Expired
                Color.Gold      ' Soon Expire
            }

            ' Create the column chart
            CreateSimpleColumnChart(columnChartPanel, labels, values, colors, titleText:=chartTitle)

        Catch ex As Exception
            MessageBox.Show("Error loading pet stock chart: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Module
