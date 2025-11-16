Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms
Imports System.Drawing

Public Module ChartGenerators

    ''' <summary>
    ''' Clears a target panel and generates a customized column chart within it.
    ''' </summary>
    ''' <param name="targetPanel">The Panel control to host the chart.</param>
    ''' <param name="categories">The X-axis category labels (e.g., "Jan", "Feb").</param>
    ''' <param name="values">The Y-axis values for the bars.</param>
    ''' <param name="barColors">The base color for each bar (used for gradients).</param>
    ''' <param name="backgroundColor">Optional background color for the chart control.</param>
    ''' <param name="titleText">Optional chart title text.</param>
    ''' <param name="titleColor">Optional chart title color.</param>
    Public Sub CreateSimpleColumnChart(ByVal targetPanel As Panel,
                                       ByVal categories() As String,
                                       ByVal values() As Double,
                                       ByVal barColors() As Color,
                                       Optional ByVal backgroundColor As Color = Nothing,
                                       Optional ByVal titleText As String = "",
                                       Optional ByVal titleColor As Color = Nothing)

        targetPanel.Controls.Clear()

        Dim chart As New Chart()
        chart.Dock = DockStyle.Fill
        chart.BackColor = If(backgroundColor = Nothing, Color.White, backgroundColor)
        chart.BorderSkin.SkinStyle = BorderSkinStyle.None ' Removes chart border

        ' --- Chart Area Setup ---
        Dim area As New ChartArea("MainArea")
        area.BackColor = Color.FromArgb(82, 75, 67) ' Light gray plot area background
        area.BorderColor = Color.Transparent

        ' X-Axis (Categories) Styling
        area.AxisX.Interval = 1
        area.AxisX.MajorGrid.Enabled = False   ' Remove vertical grid lines
        area.AxisX.LineColor = Color.White
        area.AxisX.LabelStyle.ForeColor = Color.White
        area.AxisX.LabelStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        area.AxisX.IsMarginVisible = True

        ' Y-Axis (Values) Styling
        area.AxisY.MajorGrid.Enabled = False   ' Remove horizontal grid lines
        area.AxisY.MinorGrid.Enabled = False
        area.AxisY.LineColor = Color.Gray
        area.AxisY.LabelStyle.ForeColor = Color.White
        area.AxisY.LabelStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        area.AxisY.IsStartedFromZero = True

        chart.ChartAreas.Add(area)

        ' --- Series Setup ---
        Dim series As New Series("Data")
        series.ChartType = SeriesChartType.Column
        series.IsValueShownAsLabel = True                 ' Show value labels on top of bars
        series.LabelForeColor = Color.White
        series.Font = New Font("Segoe UI", 9, FontStyle.Bold) ' Font for the value label
        series.CustomProperties = "PointWidth=0.5"        ' Sets bar width (0.5 = 50% width, 50% gap)
        series.Palette = ChartColorPalette.None           ' Use custom colors only

        ' --- Data Point Creation Loop ---
        For i As Integer = 0 To categories.Length - 1

            ' 1. Explicitly add a point using index + 1 for X-position and value for Y-position
            series.Points.AddXY(i + 1, values(i))

            ' 2. Get the newly added point to set custom properties
            Dim point As DataPoint = series.Points(i)

            ' 3. Set the AxisLabel (text) for the X-axis tick mark
            point.AxisLabel = categories(i)

            ' 4. Ensure label is explicitly shown (redundant but safe)
            point.IsValueShownAsLabel = True

            Dim baseColor As Color
            If i < barColors.Length Then
                baseColor = barColors(i)
            Else
                baseColor = Color.SteelBlue ' Fallback color
            End If

            ' 5. Apply color and gradient properties to match the visual style
            point.Color = baseColor
            point.BackGradientStyle = GradientStyle.TopBottom ' Gradient style

            ' Use ControlPaint.Dark to generate a darker shade for the gradient bottom
            point.BackSecondaryColor = ControlPaint.Dark(baseColor, 0.2F)

        Next

        chart.Series.Add(series)

        ' --- Optional Title ---
        If Not String.IsNullOrEmpty(titleText) Then
            Dim title As New Title(titleText, Docking.Top, New Font("Segoe UI", 12, FontStyle.Bold),
                                    If(titleColor = Nothing, Color.Black, titleColor))
            chart.Titles.Add(title)
        End If

        targetPanel.BackColor = Color.FromArgb(82, 75, 67)
        chart.BackColor = Color.Transparent()
        targetPanel.Controls.Add(chart)

    End Sub

End Module