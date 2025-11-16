Imports System.Windows.Forms
Imports System.Drawing

Module AlertTableDesign

    Private rowColors As New Dictionary(Of Integer, Color)

    Public Sub ApplyAlertTableStyle(ByVal dgv As DataGridView, Optional statusColumnName As String = "Status")

        rowColors.Clear()

        ' --- Yellow-Cream Theme (matching #f5e4a4) ---
        Dim headerBack As Color = Color.FromArgb(205, 180, 90)      ' header gold
        Dim cellBack As Color = Color.FromArgb(245, 228, 164)       ' base cream
        Dim altRow As Color = Color.FromArgb(252, 240, 190)         ' lighter cream for alternate rows
        Dim hoverColor As Color = Color.FromArgb(235, 210, 120)     ' hover
        Dim selectBack As Color = Color.FromArgb(225, 200, 110)     ' selected row
        Dim borderColor As Color = Color.FromArgb(230, 215, 160)    ' grid border

        ' --- 1. General Appearance ---
        With dgv
            .BackgroundColor = cellBack
            .BorderStyle = BorderStyle.None
            .Dock = DockStyle.Fill
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .EnableHeadersVisualStyles = False
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .GridColor = borderColor
        End With

        ' --- 2. Column Headers ---
        With dgv.ColumnHeadersDefaultCellStyle
            .ForeColor = Color.White
            .BackColor = headerBack
            .Font = New Font("Segoe UI Semibold", 12, FontStyle.Bold)
            .Padding = New Padding(10, 10, 10, 10)
            .Alignment = DataGridViewContentAlignment.MiddleLeft
            .SelectionBackColor = headerBack
        End With

        dgv.ColumnHeadersHeight = 50
        dgv.RowHeadersVisible = False

        ' --- 3. Cell Styling ---
        With dgv.DefaultCellStyle
            .ForeColor = Color.Black
            .BackColor = cellBack
            .Font = New Font("Segoe UI", 11, FontStyle.Regular)
            .Padding = New Padding(12, 8, 12, 8)
            .SelectionBackColor = selectBack
            .SelectionForeColor = Color.Black
        End With

        ' --- 4. Default Row Style ---
        With dgv.RowsDefaultCellStyle
            .BackColor = cellBack
            .SelectionBackColor = selectBack
        End With

        dgv.AlternatingRowsDefaultCellStyle.BackColor = altRow
        dgv.RowTemplate.Height = 45

        ' --- 5. Custom Right Border ---
        AddHandler dgv.CellPainting,
            Sub(s, e)
                If e.RowIndex >= -1 Then
                    e.PaintBackground(e.ClipBounds, True)
                    e.PaintContent(e.ClipBounds)
                    Using p As New Pen(borderColor, 1)
                        e.Graphics.DrawLine(
                            p,
                            e.CellBounds.Right - 1,
                            e.CellBounds.Top,
                            e.CellBounds.Right - 1,
                            e.CellBounds.Bottom
                        )
                    End Using
                    e.Handled = True
                End If
            End Sub

        ' --- 6. Last Column Auto-Fill ---
        If dgv.Columns.Count > 0 Then
            dgv.Columns(dgv.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If

        ' --- 7. Alert Row Coloring ---
        AddHandler dgv.CellFormatting,
            Sub(s, e)
                If e.RowIndex >= 0 AndAlso dgv.Columns.Contains(statusColumnName) Then

                    Dim value As String =
                        dgv.Rows(e.RowIndex).Cells(statusColumnName).Value?.
                        ToString().ToUpper()

                    Dim baseColor As Color = cellBack
                    Dim selColor As Color = selectBack

                    Select Case value
                        Case "OUT", "OUT OF STOCK"
                            baseColor = Color.FromArgb(185, 28, 28)
                            selColor = Color.FromArgb(220, 38, 38)

                        Case "LOW", "LOW STOCK"
                            baseColor = Color.FromArgb(217, 119, 6)
                            selColor = Color.FromArgb(245, 158, 11)

                        Case "EXP", "EXPIRED"
                            baseColor = Color.FromArgb(153, 27, 27)
                            selColor = Color.FromArgb(185, 28, 28)

                        Case "SOONEXP", "SOON TO EXPIRE", "EXPIRING SOON"
                            baseColor = Color.FromArgb(180, 83, 9)
                            selColor = Color.FromArgb(217, 119, 6)
                    End Select

                    If Not rowColors.ContainsKey(e.RowIndex) Then
                        rowColors(e.RowIndex) = baseColor
                    End If

                    dgv.Rows(e.RowIndex).DefaultCellStyle.BackColor = baseColor
                    dgv.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = selColor
                End If
            End Sub

        ' --- 8. Hover Effect ---
        AddHandler dgv.CellMouseEnter,
            Sub(s, e)
                If e.RowIndex >= 0 Then
                    dgv.Rows(e.RowIndex).DefaultCellStyle.BackColor = hoverColor
                End If
            End Sub

        AddHandler dgv.CellMouseLeave,
            Sub(s, e)
                If e.RowIndex >= 0 Then
                    Dim originalColor = If(rowColors.ContainsKey(e.RowIndex), rowColors(e.RowIndex), cellBack)
                    dgv.Rows(e.RowIndex).DefaultCellStyle.BackColor = originalColor
                End If
            End Sub

    End Sub

End Module
