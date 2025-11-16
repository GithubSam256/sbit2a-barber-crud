Imports System.Windows.Forms
Imports System.Drawing

Module TableProductDesign

    ''' <summary>
    ''' Styles the DataGridView with a warm yellow-cream theme (close to #f5e4a4).
    ''' </summary>
    Public Sub ApplyModernDarkTableStyle(ByVal dgv As DataGridView)

        ' 🎨 Yellow Cream Theme (based on #f5e4a4)
        Dim CreamPrimary As Color = Color.FromArgb(245, 228, 164)      ' #f5e4a4 main color
        Dim CreamLighter As Color = Color.FromArgb(252, 240, 190)       ' lighter yellow
        Dim CreamLightest As Color = Color.FromArgb(255, 248, 210)      ' for alt rows
        Dim HeaderGold As Color = Color.FromArgb(205, 180, 90)          ' header yellow-gold
        Dim HoverGold As Color = Color.FromArgb(235, 210, 120)          ' hover gold
        Dim SelectGold As Color = Color.FromArgb(225, 200, 110)         ' selected row
        Dim GridSoft As Color = Color.FromArgb(230, 215, 160)           ' grid lines

        ' --- 1. General Appearance ---
        With dgv
            .BackgroundColor = CreamPrimary
            .BorderStyle = BorderStyle.None
            .Dock = DockStyle.Fill
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .EnableHeadersVisualStyles = False
        End With

        ' --- 2. Column Headers Styling ---
        With dgv.ColumnHeadersDefaultCellStyle
            .ForeColor = Color.White
            .BackColor = HeaderGold
            .SelectionBackColor = HeaderGold
            .Font = New Font("Segoe UI Semibold", 12, FontStyle.Bold)
            .Alignment = DataGridViewContentAlignment.MiddleLeft
            .Padding = New Padding(10, 10, 10, 10)
        End With

        dgv.ColumnHeadersHeight = 50
        dgv.RowHeadersVisible = False

        ' --- 3. Cell Styling ---
        With dgv.DefaultCellStyle
            .ForeColor = Color.Black
            .BackColor = CreamPrimary
            .Font = New Font("Segoe UI", 11, FontStyle.Regular)
            .Padding = New Padding(12, 8, 12, 8)
            .SelectionBackColor = SelectGold
            .SelectionForeColor = Color.Black
        End With

        ' --- 4. Rows ---
        dgv.RowsDefaultCellStyle.BackColor = CreamPrimary
        dgv.RowsDefaultCellStyle.SelectionBackColor = SelectGold

        dgv.AlternatingRowsDefaultCellStyle.BackColor = CreamLightest

        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgv.GridColor = GridSoft

        ' --- 5. Column Sizing ---
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        If dgv.Columns.Count > 0 Then
            dgv.Columns(dgv.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If

        ' --- 6. Row Height ---
        dgv.RowTemplate.Height = 45

        ' --- 7. Hover effect ---
        AddHandler dgv.CellMouseEnter,
            Sub(s, e)
                If e.RowIndex >= 0 Then
                    dgv.Rows(e.RowIndex).DefaultCellStyle.BackColor = HoverGold
                End If
            End Sub

        AddHandler dgv.CellMouseLeave,
            Sub(s, e)
                If e.RowIndex >= 0 Then
                    dgv.Rows(e.RowIndex).DefaultCellStyle.BackColor =
                        If(e.RowIndex Mod 2 = 0, CreamPrimary, CreamLightest)
                End If
            End Sub

    End Sub

End Module
