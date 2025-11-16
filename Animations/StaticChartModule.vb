' StaticChartModule.vb
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms
Imports System.Drawing

Public Module StaticChartModule

    ''' <summary>
    ''' Creates a fully customizable Pie Chart.
    ''' </summary>
    ''' <param name="targetPanel">The panel where the chart will be displayed.</param>
    ''' <param name="categories">An array of category names (e.g. {"Snacks", "Drinks"}).</param>
    ''' <param name="values">An array of corresponding values (e.g. {40, 60}).</param>
    ''' <param name="sliceColors">An array of colors for each pie slice.</param>
    ''' <param name="backgroundColor">Optional background color for the chart area.</param>
    Public Sub CreateSalesChart(ByVal targetPanel As Panel,
                                ByVal categories() As String,
                                ByVal values() As Double,
                                ByVal sliceColors() As Color,
                                Optional ByVal backgroundColor As Color = Nothing)

        ' Clear any existing chart
        targetPanel.Controls.Clear()



        ' Initialize chart
        Dim chart As New Chart()
        chart.Parent = targetPanel
        chart.Dock = DockStyle.Fill
        chart.Text = "Category Sales Distribution"
        chart.BackColor = If(backgroundColor = Nothing, Color.Red, backgroundColor)
        chart.BorderlineDashStyle = ChartDashStyle.Solid
        chart.BorderlineColor = Color.FromArgb(36, 48, 63)
        chart.BorderlineWidth = 1

        ' Create Chart Area
        Dim area As New ChartArea("MainArea")
        area.BackColor = Color.Transparent
        chart.ChartAreas.Add(area)

        ' Create Series
        Dim series As New Series("Inventory")
        series.ChartType = SeriesChartType.Pie
        series.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        series.IsValueShownAsLabel = True
        series.LabelFormat = "0'%'"
        series.LegendText = "#VALX"
        series.SmartLabelStyle.Enabled = True

        ' Bind data
        series.Points.DataBindXY(categories, values)

        ' Apply slice colors
        For i As Integer = 0 To series.Points.Count - 1
            If i < sliceColors.Length Then
                series.Points(i).Color = sliceColors(i)
            End If
        Next

        ' Add Series
        chart.Series.Add(series)

        ' Optional: Legend styling
        Dim legend As New Legend()
        legend.Docking = Docking.Right
        legend.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        legend.BackColor = Color.FromArgb(82, 75, 67)
        legend.ForeColor = Color.White

        chart.Legends.Add(legend)

        targetPanel.BackColor = Color.FromArgb(82, 75, 67)

        chart.BackColor = Color.Transparent
        chart.BorderlineColor = Color.FromArgb(82, 75, 67)

        ' Add chart to panel
        targetPanel.Controls.Add(chart)

    End Sub

End Module