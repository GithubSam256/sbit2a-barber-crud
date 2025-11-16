Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Windows.Forms

Module CardDataLoader

    ' ✅ Load ALL-TIME data for cards
    Public Sub LoadCardData(totalProductLbl As Label, totalSalesLbl As Label, totalCostLbl As Label, totalProfitLbl As Label)
        Try
            ' Total Products (count of pets)
            Dim totalProducts As Object = GlobalCrud.ExecuteScalar("SELECT COUNT(*) FROM pets;", Nothing)
            totalProductLbl.Text = If(totalProducts IsNot Nothing, totalProducts.ToString(), "0")

            ' Total Sales Revenue
            Dim totalSalesRevenue As Object = GlobalCrud.ExecuteScalar("SELECT IFNULL(SUM(total_price), 0) FROM pet_sales;", Nothing)
            totalSalesLbl.Text = If(totalSalesRevenue IsNot Nothing, Convert.ToDecimal(totalSalesRevenue).ToString("N2"), "0.00")

            ' Total Cost (from purchases table)
            Dim totalCostValue As Object = GlobalCrud.ExecuteScalar("SELECT IFNULL(SUM(total_price), 0) FROM pet_purchases;", Nothing)
            totalCostLbl.Text = If(totalCostValue IsNot Nothing, Convert.ToDecimal(totalCostValue).ToString("N2"), "0.00")

            ' Total Profit (Sales Revenue - Purchase Cost per item)
            Dim totalProfitValue As Object = GlobalCrud.ExecuteScalar(
                "SELECT IFNULL(SUM(s.quantity * (s.sale_price - p.cost_price)), 0) " &
                "FROM pet_sales s " &
                "INNER JOIN pets p ON s.pet_id = p.pet_id;", Nothing)
            totalProfitLbl.Text = If(totalProfitValue IsNot Nothing, Convert.ToDecimal(totalProfitValue).ToString("N2"), "0.00")

        Catch ex As Exception
            MessageBox.Show("Error loading card data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            totalProductLbl.Text = "0"
            totalSalesLbl.Text = "0.00"
            totalCostLbl.Text = "0.00"
            totalProfitLbl.Text = "0.00"
        End Try
    End Sub

    ' ✅ Load WEEKLY data (last 7 days)
    Public Sub LoadWeeklyCardData(totalProductLbl As Label, totalSalesLbl As Label, totalCostLbl As Label, totalProfitLbl As Label)
        Try
            Dim weekStart As String = Date.Now.AddDays(-7).ToString("yyyy-MM-dd 00:00:00")
            Dim weekEnd As String = Date.Now.ToString("yyyy-MM-dd 23:59:59")

            ' Total Quantity Sold
            Dim totalQuantitySold As Object = GlobalCrud.ExecuteScalar(
                "SELECT IFNULL(SUM(quantity), 0) FROM pet_sales WHERE sale_date >= @start AND sale_date <= @end;",
                New MySqlParameter("@start", weekStart),
                New MySqlParameter("@end", weekEnd))
            totalProductLbl.Text = If(totalQuantitySold IsNot Nothing, totalQuantitySold.ToString(), "0")

            ' Weekly Sales Revenue
            Dim weeklySales As Object = GlobalCrud.ExecuteScalar(
                "SELECT IFNULL(SUM(total_price), 0) FROM pet_sales WHERE sale_date >= @start AND sale_date <= @end;",
                New MySqlParameter("@start", weekStart),
                New MySqlParameter("@end", weekEnd))
            totalSalesLbl.Text = If(weeklySales IsNot Nothing, Convert.ToDecimal(weeklySales).ToString("N2"), "0.00")

            ' Weekly Cost
            Dim weeklyCost As Object = GlobalCrud.ExecuteScalar(
                "SELECT IFNULL(SUM(total_price), 0) FROM pet_purchases WHERE purchase_date >= @start AND purchase_date <= @end;",
                New MySqlParameter("@start", weekStart),
                New MySqlParameter("@end", weekEnd))
            totalCostLbl.Text = If(weeklyCost IsNot Nothing, Convert.ToDecimal(weeklyCost).ToString("N2"), "0.00")

            ' Weekly Profit
            Dim weeklyProfit As Object = GlobalCrud.ExecuteScalar(
                "SELECT IFNULL(SUM(s.quantity * (s.sale_price - p.cost_price)), 0) " &
                "FROM pet_sales s " &
                "INNER JOIN pets p ON s.pet_id = p.pet_id " &
                "WHERE s.sale_date >= @start AND s.sale_date <= @end;",
                New MySqlParameter("@start", weekStart),
                New MySqlParameter("@end", weekEnd))
            totalProfitLbl.Text = If(weeklyProfit IsNot Nothing, Convert.ToDecimal(weeklyProfit).ToString("N2"), "0.00")

        Catch ex As Exception
            MessageBox.Show("Error loading weekly data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            totalProductLbl.Text = "0"
            totalSalesLbl.Text = "0.00"
            totalCostLbl.Text = "0.00"
            totalProfitLbl.Text = "0.00"
        End Try
    End Sub

    ' ✅ Load DAILY data (today only)
    Public Sub LoadDailyCardData(totalProductLbl As Label, totalSalesLbl As Label, totalCostLbl As Label, totalProfitLbl As Label)
        Try
            Dim todayStart As String = Date.Now.ToString("yyyy-MM-dd 00:00:00")
            Dim todayEnd As String = Date.Now.ToString("yyyy-MM-dd 23:59:59")

            ' Total Quantity Sold
            Dim totalQuantitySold As Object = GlobalCrud.ExecuteScalar(
                "SELECT IFNULL(SUM(quantity), 0) FROM pet_sales WHERE sale_date >= @start AND sale_date <= @end;",
                New MySqlParameter("@start", todayStart),
                New MySqlParameter("@end", todayEnd))
            totalProductLbl.Text = If(totalQuantitySold IsNot Nothing, totalQuantitySold.ToString(), "0")

            ' Daily Sales Revenue
            Dim dailySales As Object = GlobalCrud.ExecuteScalar(
                "SELECT IFNULL(SUM(total_price), 0) FROM pet_sales WHERE sale_date >= @start AND sale_date <= @end;",
                New MySqlParameter("@start", todayStart),
                New MySqlParameter("@end", todayEnd))
            totalSalesLbl.Text = If(dailySales IsNot Nothing, Convert.ToDecimal(dailySales).ToString("N2"), "0.00")

            ' Daily Cost
            Dim dailyCost As Object = GlobalCrud.ExecuteScalar(
                "SELECT IFNULL(SUM(total_price), 0) FROM pet_purchases WHERE purchase_date >= @start AND purchase_date <= @end;",
                New MySqlParameter("@start", todayStart),
                New MySqlParameter("@end", todayEnd))
            totalCostLbl.Text = If(dailyCost IsNot Nothing, Convert.ToDecimal(dailyCost).ToString("N2"), "0.00")

            ' Daily Profit
            Dim dailyProfit As Object = GlobalCrud.ExecuteScalar(
                "SELECT IFNULL(SUM(s.quantity * (s.sale_price - p.cost_price)), 0) " &
                "FROM pet_sales s " &
                "INNER JOIN pets p ON s.pet_id = p.pet_id " &
                "WHERE s.sale_date >= @start AND s.sale_date <= @end;",
                New MySqlParameter("@start", todayStart),
                New MySqlParameter("@end", todayEnd))
            totalProfitLbl.Text = If(dailyProfit IsNot Nothing, Convert.ToDecimal(dailyProfit).ToString("N2"), "0.00")

        Catch ex As Exception
            MessageBox.Show("Error loading daily data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            totalProductLbl.Text = "0"
            totalSalesLbl.Text = "0.00"
            totalCostLbl.Text = "0.00"
            totalProfitLbl.Text = "0.00"
        End Try
    End Sub

    ' ✅ Load Month-to-Month Percent Change
    Public Sub LoadPercentDataCards(Card2Percent As Label, Card3Percent As Label, Card4Percent As Label)
        Try
            Dim currentMonthStart As String = New Date(Date.Now.Year, Date.Now.Month, 1).ToString("yyyy-MM-dd")
            Dim currentMonthEnd As String = New Date(Date.Now.Year, Date.Now.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd 23:59:59")
            Dim lastMonthStart As String = New Date(Date.Now.Year, Date.Now.Month, 1).AddMonths(-1).ToString("yyyy-MM-dd")
            Dim lastMonthEnd As String = New Date(Date.Now.Year, Date.Now.Month, 1).AddDays(-1).ToString("yyyy-MM-dd 23:59:59")

            ' Sales Percent Change
            Dim currentSales As Object = GlobalCrud.ExecuteScalar(
                "SELECT IFNULL(SUM(total_price), 0) FROM pet_sales WHERE sale_date >= @start AND sale_date <= @end;",
                New MySqlParameter("@start", currentMonthStart),
                New MySqlParameter("@end", currentMonthEnd))
            Dim lastSales As Object = GlobalCrud.ExecuteScalar(
                "SELECT IFNULL(SUM(total_price), 0) FROM pet_sales WHERE sale_date >= @start AND sale_date <= @end;",
                New MySqlParameter("@start", lastMonthStart),
                New MySqlParameter("@end", lastMonthEnd))
            DisplayChange(Card2Percent, Convert.ToDecimal(If(currentSales, 0)), Convert.ToDecimal(If(lastSales, 0)))

            ' Cost Percent Change
            Dim currentCost As Object = GlobalCrud.ExecuteScalar(
                "SELECT IFNULL(SUM(total_price), 0) FROM pet_purchases WHERE purchase_date >= @start AND purchase_date <= @end;",
                New MySqlParameter("@start", currentMonthStart),
                New MySqlParameter("@end", currentMonthEnd))
            Dim lastCost As Object = GlobalCrud.ExecuteScalar(
                "SELECT IFNULL(SUM(total_price), 0) FROM pet_purchases WHERE purchase_date >= @start AND purchase_date <= @end;",
                New MySqlParameter("@start", lastMonthStart),
                New MySqlParameter("@end", lastMonthEnd))
            DisplayChange(Card3Percent, Convert.ToDecimal(If(currentCost, 0)), Convert.ToDecimal(If(lastCost, 0)))

            ' Profit Percent Change
            Dim currentProfit As Object = GlobalCrud.ExecuteScalar(
                "SELECT IFNULL(SUM(s.quantity * (s.sale_price - p.cost_price)), 0) " &
                "FROM pet_sales s INNER JOIN pets p ON s.pet_id = p.pet_id " &
                "WHERE s.sale_date >= @start AND s.sale_date <= @end;",
                New MySqlParameter("@start", currentMonthStart),
                New MySqlParameter("@end", currentMonthEnd))
            Dim lastProfit As Object = GlobalCrud.ExecuteScalar(
                "SELECT IFNULL(SUM(s.quantity * (s.sale_price - p.cost_price)), 0) " &
                "FROM pet_sales s INNER JOIN pets p ON s.pet_id = p.pet_id " &
                "WHERE s.sale_date >= @start AND s.sale_date <= @end;",
                New MySqlParameter("@start", lastMonthStart),
                New MySqlParameter("@end", lastMonthEnd))
            DisplayChange(Card4Percent, Convert.ToDecimal(If(currentProfit, 0)), Convert.ToDecimal(If(lastProfit, 0)))

        Catch ex As Exception
            MessageBox.Show("Error loading percentage data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ✅ Display up/down percent change
    Private Sub DisplayChange(label As Label, currentMonth As Decimal, lastMonth As Decimal)
        Dim percentChange As Decimal = 0
        If lastMonth > 0 Then
            percentChange = ((currentMonth - lastMonth) / lastMonth) * 100
        ElseIf currentMonth > 0 Then
            percentChange = 100
        End If

        If percentChange > 0 Then
            label.Text = "▲ " & percentChange.ToString("N1") & "%"
            label.BackColor = Color.Transparent
            label.ForeColor = Color.FromArgb(0, 188, 125)
        ElseIf percentChange < 0 Then
            label.Text = "▼ " & Math.Abs(percentChange).ToString("N1") & "%"
            label.BackColor = Color.Transparent
            label.ForeColor = Color.FromArgb(251, 44, 54)
        Else
            label.Text = "— 0.0%"
            label.BackColor = Color.Gray
            label.ForeColor = Color.White
        End If
    End Sub

End Module
