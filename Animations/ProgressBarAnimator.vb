Module ProgressBarAnimator

    Public Enum BarDirection
        Horizontal
        Vertical
    End Enum

    Private Structure BarData
        Public TargetValue As Integer
        Public FillPanel As Panel
        Public CurrentValue As Integer
    End Structure

    Private bars As New List(Of BarData)
    Private WithEvents animTimer As New Timer With {.Interval = 15}

    Private flowPanel As FlowLayoutPanel
    Private refPanel As Panel
    Private direction As BarDirection

    ''' <summary>
    ''' Creates and animates progress bars horizontally or vertically.
    ''' </summary>
    ''' <param name="values">List of percentages (0–100)</param>
    ''' <param name="colors">List of colors for the fill panel of each bar</param> ' **NEW PARAMETER**
    ''' <param name="referencePanel">Panel to copy dimensions & background color</param>
    ''' <param name="targetFlowPanel">FlowLayoutPanel to contain bars</param>
    ''' <param name="dir">Animation direction: Horizontal or Vertical</param>
    Public Sub CreateAnimatedBars(values As List(Of Integer),
                                 colors As List(Of Color), ' **NEW PARAMETER**
                                 referencePanel As Panel,
                                 targetFlowPanel As FlowLayoutPanel,
                                 Optional dir As BarDirection = BarDirection.Horizontal)

        ' Input validation: Ensure lists have the same number of elements
        If values.Count <> colors.Count Then
            Throw New ArgumentException("The 'values' list and 'colors' list must contain the same number of elements.")
        End If

        ' Store references
        flowPanel = targetFlowPanel
        refPanel = referencePanel
        direction = dir

        ' Clear previous bars
        flowPanel.Controls.Clear()
        bars.Clear()

        Dim refWidth As Integer = refPanel.Width
        Dim refHeight As Integer = refPanel.Height
        Dim refBackColor As Color = refPanel.BackColor

        ' Create and initialize bars
        For i As Integer = 0 To values.Count - 1 ' Loop through index to access both lists
            Dim percent As Integer = values(i)
            Dim barColor As Color = colors(i) ' Get the specific color

            Dim container As New Panel With {
                .Width = refWidth,
                .Height = refHeight,
                .BackColor = refBackColor,
                .Margin = New Padding(10)
            }

            Dim fill As New Panel With {
                .BackColor = barColor ' **USING THE CUSTOM COLOR HERE**
            }

            ' Initialize fill panel based on direction
            If direction = BarDirection.Horizontal Then
                fill.Width = 0
                fill.Height = container.Height
                fill.Dock = DockStyle.Left
            Else
                fill.Width = container.Width
                fill.Height = 0
                fill.Dock = DockStyle.Bottom
            End If

            container.Controls.Add(fill)
            flowPanel.Controls.Add(container)

            Dim targetValue As Integer =
                If(direction = BarDirection.Horizontal,
                    CInt((percent / 100) * container.Width),
                    CInt((percent / 100) * container.Height))

            bars.Add(New BarData With {
                .FillPanel = fill,
                .CurrentValue = 0,
                .TargetValue = targetValue
            })
        Next

        animTimer.Start()
    End Sub

    Private Sub animTimer_Tick(sender As Object, e As EventArgs) Handles animTimer.Tick
        Dim allDone As Boolean = True

        For i As Integer = 0 To bars.Count - 1
            Dim b = bars(i)

            If b.CurrentValue < b.TargetValue Then
                ' Increased animation speed slightly for smoother look
                Dim stepValue As Integer = Math.Max(1, CInt(b.TargetValue / 20)) ' Dynamic step: at least 1, up to 1/20th of target

                b.CurrentValue += stepValue ' animation speed

                If b.CurrentValue > b.TargetValue Then b.CurrentValue = b.TargetValue

                If direction = BarDirection.Horizontal Then
                    b.FillPanel.Width = b.CurrentValue
                Else
                    b.FillPanel.Height = b.CurrentValue
                End If

                allDone = False
            End If

            bars(i) = b
        Next

        If allDone Then animTimer.Stop()
    End Sub

End Module