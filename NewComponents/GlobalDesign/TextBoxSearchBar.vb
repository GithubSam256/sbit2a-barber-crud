Imports System.Drawing
Imports System.Windows.Forms

Module TextBoxSearchBar

    ''' <summary>
    ''' Styles a TextBox to look like a modern search bar.
    ''' </summary>
    ''' <param name="txt">The TextBox to style.</param>
    Public Sub StyleSearchBox(ByVal txt As TextBox)

        ' ✅ Basic appearance
        txt.BorderStyle = BorderStyle.None
        txt.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        txt.ForeColor = Color.White
        txt.BackColor = Color.FromArgb(28, 34, 44)
        txt.Margin = New Padding(0)
        txt.Padding = New Padding(8, 6, 8, 6)

        ' ✅ Rounded look by placing TextBox inside a panel
        Dim parent = txt.Parent
        Dim wrapper As New Panel()

        wrapper.Size = New Size(txt.Width + 16, txt.Height + 12)
        wrapper.BackColor = Color.FromArgb(45, 55, 75)
        wrapper.Padding = New Padding(6)
        wrapper.Location = txt.Location
        wrapper.BorderStyle = BorderStyle.FixedSingle

        txt.Location = New Point(6, 6)

        ' Move textbox into wrapper panel
        parent.Controls.Remove(txt)
        wrapper.Controls.Add(txt)
        parent.Controls.Add(wrapper)

    End Sub

End Module
