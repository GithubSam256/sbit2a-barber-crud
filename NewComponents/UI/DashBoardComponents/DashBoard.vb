Imports MySql.Data.MySqlClient

Public Class DashBoard
    Private Sub DashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CreateSalesChartt()
        'ForColumnBar()
        LoadCardData()
        CardDataLoader.LoadPercentDataCards(Label8, Label12, Label16)
        ChartsCRUD.LoadPieChart(PieChart, Color.FromArgb(82, 75, 67))
        ChartsCRUD.LoadColumnChart(BarChart, "")
    End Sub

    'Public Sub ProgressBarLoad()
    '    Dim sampleValues As New List(Of Integer) From {30, 60, 90, 45}

    '    Dim barColors As New List(Of Color) From {
    '      Color.MediumSlateBlue,
    '      Color.Orange,
    '      Color.ForestGreen,
    '      Color.Teal
    '    }

    ' Horizontal animation
    'ProgressBarAnimator.CreateAnimatedBars(sampleValues, ProgressBar, ChartFlowPanel, ProgressBarAnimator.BarDirection.Horizontal)

    ' OR Vertical animation
    '    ProgressBarAnimator.CreateAnimatedBars(sampleValues, barColors, barcomponent, BarContainer, ProgressBarAnimator.BarDirection.Vertical)
    'End Sub

    'Private Sub CreateSalesChartt()
    '    ' Categories for the pie chart
    '    Dim categories() As String = {"Snacks", "Drinks", "Frozen", "Others"}

    '    ' Values corresponding to each category
    '    Dim values() As Double = {40, 25, 20, 15}

    '    ' Colors for each slice
    '    Dim sliceColors() As Color = {Color.FromArgb(15, 173, 207), Color.FromArgb(143, 208, 239), Color.FromArgb(101, 119, 243), Color.FromArgb(60, 80, 224)}

    '    ' Call the chart creation function
    '    CreateSalesChart(PieChart, categories, values, sliceColors)
    'End Sub

    'Private Sub ForColumnBar()
    '    ' Categories for the column chart
    '    Dim categories() As String = {"Jan", "Feb", "Mar", "Apr", "May"}
    '    ' Values corresponding to each category
    '    Dim values() As Double = {50, 70, 40, 90, 60}
    '    ' Colors for each bar
    '    Dim barColors() As Color = {Color.FromArgb(15, 173, 207), Color.FromArgb(143, 208, 239), Color.FromArgb(101, 119, 243), Color.FromArgb(15, 173, 207), Color.FromArgb(60, 80, 224)}
    '    ' Call the column chart creation function
    '    CreateSimpleColumnChart(BarChart, categories, values, barColors)
    'End Sub

    Public Sub LoadCardData()
        Try
            ' ✅ Total Pets
            Dim totalPets As Object = GlobalCrud.ExecuteScalar("SELECT COUNT(*) FROM pets;", Nothing)
            TotalProduct.Text = If(totalPets IsNot Nothing, totalPets.ToString(), "0")

            ' ✅ Total Sales Revenue
            Dim totalSalesRevenue As Object = GlobalCrud.ExecuteScalar("SELECT IFNULL(SUM(total_price), 0) FROM pet_sales;", Nothing)
            If totalSalesRevenue IsNot Nothing Then
                Dim salesValue As Decimal = Convert.ToDecimal(totalSalesRevenue)
                TotalSales.Text = salesValue.ToString("N2")
            Else
                TotalSales.Text = "0.00"
            End If

            ' ✅ Total Cost
            Dim totalCostValue As Object = GlobalCrud.ExecuteScalar(
            "SELECT IFNULL(SUM(s.quantity * p.cost_price), 0) " &
            "FROM pet_sales s " &
            "INNER JOIN pets p ON s.pet_id = p.pet_id;", Nothing
        )
            If totalCostValue IsNot Nothing Then
                Dim costValue As Decimal = Convert.ToDecimal(totalCostValue)
                TotalCost.Text = costValue.ToString("N2")
            Else
                TotalCost.Text = "0.00"
            End If

            ' ✅ Total Profit
            Dim totalProfitValue As Object = GlobalCrud.ExecuteScalar(
            "SELECT IFNULL(SUM(s.quantity * (s.sale_price - p.cost_price)), 0) " &
            "FROM pet_sales s " &
            "INNER JOIN pets p ON s.pet_id = p.pet_id;", Nothing
        )
            If totalProfitValue IsNot Nothing Then
                Dim profitValue As Decimal = Convert.ToDecimal(totalProfitValue)
                TotalProfit.Text = profitValue.ToString("N2")
            Else
                TotalProfit.Text = "0.00"
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading card data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            TotalProduct.Text = "0"
            TotalSales.Text = "0.00"
            TotalCost.Text = "0.00"
            TotalProfit.Text = "0.00"
        End Try
    End Sub

End Class
