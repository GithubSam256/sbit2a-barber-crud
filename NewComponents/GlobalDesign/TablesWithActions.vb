Imports System.Drawing
Imports System.Windows.Forms

Module TableWithActions

    ''' <summary>
    ''' Apply DataGridView styling using a warm yellow-cream theme (based on #f5e4a4).
    ''' </summary>
    Public Sub TableWithButtons(dgv As DataGridView,
                                Optional editAction As Action(Of DataGridView, Integer) = Nothing,
                                Optional deleteAction As Action(Of DataGridView, Integer) = Nothing)

        ' 🎨 Yellow-Cream Theme
        Dim CreamBase As Color = Color.FromArgb(245, 228, 164)      ' #f5e4a4 base row
        Dim CreamLight As Color = Color.FromArgb(252, 240, 190)     ' lighter cream
        Dim DarkHeader As Color = Color.FromArgb(205, 180, 90)      ' header gold
        Dim HoverColor As Color = Color.FromArgb(235, 210, 120)     ' hover
        Dim SelectColor As Color = Color.FromArgb(225, 200, 110)    ' selected row
        Dim BorderColor As Color = Color.FromArgb(230, 215, 160)    ' grid border

        ' Action Button Colors
        Dim EditColor As Color = Color.FromArgb(255, 230, 150)      ' warm yellow for edit
        Dim DeleteColor As Color = Color.FromArgb(230, 160, 130)    ' muted red/brown for delete

        ' --- 1. GENERAL APPEARANCE ---
        With dgv
            .BackgroundColor = CreamBase
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
        End With

        ' --- 2. HEADER STYLE ---
        With dgv.ColumnHeadersDefaultCellStyle
            .ForeColor = Color.White
            .BackColor = DarkHeader
            .SelectionBackColor = DarkHeader
            .Font = New Font("Segoe UI Semibold", 12, FontStyle.Bold)
            .Alignment = DataGridViewContentAlignment.MiddleLeft
            .Padding = New Padding(10, 10, 10, 10)
        End With

        dgv.ColumnHeadersHeight = 50
        dgv.RowHeadersVisible = False

        ' --- 3. CELL STYLE ---
        With dgv.DefaultCellStyle
            .ForeColor = Color.Black
            .BackColor = CreamBase
            .Font = New Font("Segoe UI", 11, FontStyle.Regular)
            .Padding = New Padding(12, 8, 12, 8)
            .SelectionBackColor = SelectColor
            .SelectionForeColor = Color.Black
        End With

        dgv.RowsDefaultCellStyle.BackColor = CreamBase
        dgv.RowsDefaultCellStyle.SelectionBackColor = SelectColor
        dgv.AlternatingRowsDefaultCellStyle.BackColor = CreamLight

        dgv.CellBorderStyle = DataGridViewCellBorderStyle.None
        dgv.GridColor = BorderColor

        ' --- 4. CUSTOM RENDERING ---
        AddHandler dgv.CellPainting,
            Sub(s, e)
                If e.RowIndex >= 0 OrElse e.RowIndex = -1 Then
                    e.PaintBackground(e.ClipBounds, e.RowIndex >= 0)
                    e.PaintContent(e.ClipBounds)

                    Using p As New Pen(BorderColor, 1)
                        e.Graphics.DrawLine(p,
                                            e.CellBounds.Right - 1,
                                            e.CellBounds.Top,
                                            e.CellBounds.Right - 1,
                                            e.CellBounds.Bottom)
                    End Using

                    ' Custom Action Buttons
                    If dgv.Columns.Contains("Action") AndAlso
                       e.ColumnIndex = dgv.Columns("Action").Index AndAlso
                       e.RowIndex >= 0 Then

                        Dim buttonWidth As Integer = 70
                        Dim spacing As Integer = 5

                        Dim editRect As New Rectangle(e.CellBounds.Left + spacing, e.CellBounds.Top + 5,
                                                      buttonWidth, e.CellBounds.Height - 10)
                        Dim deleteRect As New Rectangle(e.CellBounds.Left + spacing + buttonWidth + spacing,
                                                        e.CellBounds.Top + 5,
                                                        buttonWidth, e.CellBounds.Height - 10)

                        ' Edit Button
                        e.Graphics.FillRectangle(New SolidBrush(EditColor), editRect)
                        e.Graphics.DrawRectangle(Pens.White, editRect)
                        TextRenderer.DrawText(e.Graphics, "Edit", e.CellStyle.Font, editRect,
                                              Color.Black, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)

                        ' Delete Button
                        e.Graphics.FillRectangle(New SolidBrush(DeleteColor), deleteRect)
                        e.Graphics.DrawRectangle(Pens.White, deleteRect)
                        TextRenderer.DrawText(e.Graphics, "Delete", e.CellStyle.Font, deleteRect,
                                              Color.Black, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)

                        e.Handled = True
                    End If
                End If
            End Sub

        ' --- 5. ADD ACTION COLUMN ---
        If dgv.Columns.Cast(Of DataGridViewColumn).All(Function(c) c.Name <> "Action") Then
            Dim actionCol As New DataGridViewTextBoxColumn() With {
                .Name = "Action",
                .HeaderText = "Action",
                .Width = 160
            }
            dgv.Columns.Add(actionCol)
        End If

        dgv.Columns("Action").AutoSizeMode = DataGridViewAutoSizeColumnMode.None

        ' --- 6. ROW HEIGHT ---
        dgv.RowTemplate.Height = 45

        ' --- 7. HOVER EFFECT ---
        AddHandler dgv.CellMouseEnter,
            Sub(s, e)
                If e.RowIndex >= 0 Then
                    dgv.Rows(e.RowIndex).DefaultCellStyle.BackColor = HoverColor
                End If
            End Sub

        AddHandler dgv.CellMouseLeave,
            Sub(s, e)
                If e.RowIndex >= 0 Then
                    dgv.Rows(e.RowIndex).DefaultCellStyle.BackColor =
                        If(e.RowIndex Mod 2 = 0, CreamBase, CreamLight)
                End If
            End Sub

        ' --- 8. BUTTON CLICK HANDLER ---
        AddHandler dgv.CellClick,
            Sub(s, e)
                If e.RowIndex >= 0 AndAlso
                   dgv.Columns.Contains("Action") AndAlso
                   e.ColumnIndex = dgv.Columns("Action").Index Then

                    Dim cellRect = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False)
                    Dim buttonWidth As Integer = 70
                    Dim spacing As Integer = 5
                    Dim clickPoint = dgv.PointToClient(Cursor.Position)

                    Dim editRect As New Rectangle(cellRect.Left + spacing, cellRect.Top + 5,
                                                  buttonWidth, cellRect.Height - 10)
                    Dim deleteRect As New Rectangle(cellRect.Left + spacing + buttonWidth + spacing,
                                                    cellRect.Top + 5,
                                                    buttonWidth, cellRect.Height - 10)

                    If editRect.Contains(clickPoint) AndAlso editAction IsNot Nothing Then
                        editAction(dgv, e.RowIndex)
                    ElseIf deleteRect.Contains(clickPoint) AndAlso deleteAction IsNot Nothing Then
                        deleteAction(dgv, e.RowIndex)
                    End If
                End If
            End Sub

    End Sub

End Module
