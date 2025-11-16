Public Class EditCategoryForm
    Inherits Form

    Public Property CategoryName As String
    Public Property CategoryDescription As String

    Private txtName As New TextBox()
    Private txtDescription As New TextBox()
    Private btnOk As New Button()
    Private btnCancel As New Button()
    Private lblName As New Label()
    Private lblDesc As New Label()
    Private lblTitle As New Label()
    Private btnClose As New Button()

    ' Properties to customize the form
    Public Property FormTitle As String
        Get
            Return lblTitle.Text
        End Get
        Set(value As String)
            lblTitle.Text = value
        End Set
    End Property

    Public Property SaveButtonText As String
        Get
            Return btnOk.Text
        End Get
        Set(value As String)
            btnOk.Text = value
        End Set
    End Property

    ' Warm-dark theme color palette (matches previous DataGridView)
    Private Shared ReadOnly BgColor As Color = Color.FromArgb(82, 75, 67)        ' Form background
    Private Shared ReadOnly InputBgColor As Color = Color.FromArgb(92, 85, 77)   ' TextBox background
    Private Shared ReadOnly InputFocusColor As Color = Color.FromArgb(110, 100, 92) ' TextBox focus
    Private Shared ReadOnly FgColor As Color = Color.WhiteSmoke                  ' Text color
    Private Shared ReadOnly LabelColor As Color = Color.WhiteSmoke               ' Label color
    Private Shared ReadOnly AccentColor As Color = Color.FromArgb(120, 110, 100) ' Save button
    Private Shared ReadOnly AccentHoverColor As Color = Color.FromArgb(140, 130, 120) ' Save button hover
    Private Shared ReadOnly ButtonColor As Color = Color.FromArgb(70, 64, 57)    ' Cancel button
    Private Shared ReadOnly ButtonHoverColor As Color = Color.FromArgb(90, 84, 77) ' Cancel hover
    Private Shared ReadOnly CloseHoverColor As Color = Color.FromArgb(180, 70, 70) ' Close button hover

    Public Sub New(name As String, description As String)
        Me.CategoryName = name
        Me.CategoryDescription = description

        ' --- Form Settings ---
        Me.Text = ""
        Me.Size = New Size(480, 400)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterParent
        Me.BackColor = BgColor
        Me.Font = New Font("Segoe UI", 9.5F)

        ' --- Custom Close Button ---
        btnClose.Text = "×"
        btnClose.Location = New Point(440, 10)
        btnClose.Size = New Size(30, 30)
        btnClose.BackColor = Color.Transparent
        btnClose.ForeColor = LabelColor
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.FlatAppearance.BorderSize = 0
        btnClose.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        btnClose.Cursor = Cursors.Hand
        btnClose.TabStop = False
        AddHandler btnClose.MouseEnter, Sub()
                                            btnClose.BackColor = CloseHoverColor
                                            btnClose.ForeColor = Color.White
                                        End Sub
        AddHandler btnClose.MouseLeave, Sub()
                                            btnClose.BackColor = Color.Transparent
                                            btnClose.ForeColor = LabelColor
                                        End Sub
        AddHandler btnClose.Click, AddressOf BtnClose_Click

        ' --- Title Label ---
        lblTitle.Text = "Edit Category"
        lblTitle.Location = New Point(30, 30)
        lblTitle.AutoSize = True
        lblTitle.ForeColor = FgColor
        lblTitle.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)

        ' --- Name Label ---
        lblName.Text = "Category Name"
        lblName.Location = New Point(30, 85)
        lblName.AutoSize = True
        lblName.ForeColor = LabelColor
        lblName.Font = New Font("Segoe UI", 9.0F)

        ' Create rounded panel for txtName
        Dim pnlName As New Panel() With {
            .Location = New Point(30, 110),
            .Size = New Size(420, 40),
            .BackColor = InputBgColor
        }
        txtName.Location = New Point(12, 8)
        txtName.Width = 396
        txtName.BorderStyle = BorderStyle.None
        txtName.Text = name
        txtName.BackColor = InputBgColor
        txtName.ForeColor = FgColor
        txtName.Font = New Font("Segoe UI", 10.5F)
        AddHandler txtName.Enter, AddressOf TextBox_Enter
        AddHandler txtName.Leave, AddressOf TextBox_Leave
        pnlName.Controls.Add(txtName)

        ' --- Description Label ---
        lblDesc.Text = "Description"
        lblDesc.Location = New Point(30, 170)
        lblDesc.AutoSize = True
        lblDesc.ForeColor = LabelColor
        lblDesc.Font = New Font("Segoe UI", 9.0F)

        ' Create rounded panel for txtDescription
        Dim pnlDesc As New Panel() With {
            .Location = New Point(30, 195),
            .Size = New Size(420, 100),
            .BackColor = InputBgColor
        }
        txtDescription.Location = New Point(12, 10)
        txtDescription.Width = 396
        txtDescription.Height = 80
        txtDescription.Multiline = True
        txtDescription.Text = description
        txtDescription.BackColor = InputBgColor
        txtDescription.ForeColor = FgColor
        txtDescription.BorderStyle = BorderStyle.None
        txtDescription.Font = New Font("Segoe UI", 10.5F)
        txtDescription.ScrollBars = ScrollBars.Vertical
        AddHandler txtDescription.Enter, AddressOf TextBox_Enter
        AddHandler txtDescription.Leave, AddressOf TextBox_Leave
        pnlDesc.Controls.Add(txtDescription)

        ' --- Save Button ---
        btnOk.Text = "Save Changes"
        btnOk.Location = New Point(30, 320)
        btnOk.Size = New Size(205, 42)
        btnOk.BackColor = AccentColor
        btnOk.ForeColor = Color.White
        btnOk.FlatStyle = FlatStyle.Flat
        btnOk.FlatAppearance.BorderSize = 0
        btnOk.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnOk.Cursor = Cursors.Hand
        btnOk.TabStop = True
        AddHandler btnOk.MouseEnter, Sub() btnOk.BackColor = AccentHoverColor
        AddHandler btnOk.MouseLeave, Sub() btnOk.BackColor = AccentColor
        AddHandler btnOk.Click, AddressOf BtnOk_Click

        ' --- Cancel Button ---
        btnCancel.Text = "Cancel"
        btnCancel.Location = New Point(245, 320)
        btnCancel.Size = New Size(205, 42)
        btnCancel.BackColor = ButtonColor
        btnCancel.ForeColor = FgColor
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.Font = New Font("Segoe UI", 10.0F)
        btnCancel.Cursor = Cursors.Hand
        btnCancel.TabStop = True
        AddHandler btnCancel.MouseEnter, Sub() btnCancel.BackColor = ButtonHoverColor
        AddHandler btnCancel.MouseLeave, Sub() btnCancel.BackColor = ButtonColor
        AddHandler btnCancel.Click, AddressOf BtnCancel_Click

        ' --- Add controls ---
        Me.Controls.AddRange(New Control() {
            btnClose,
            lblTitle,
            lblName, pnlName,
            lblDesc, pnlDesc,
            btnOk, btnCancel
        })

        ' Set tab order
        txtName.TabIndex = 0
        txtDescription.TabIndex = 1
        btnOk.TabIndex = 2
        btnCancel.TabIndex = 3

        ' Set accept/cancel buttons
        Me.AcceptButton = btnOk
        Me.CancelButton = btnCancel

        ' Allow form to be dragged
        AddHandler Me.MouseDown, AddressOf Form_MouseDown
        AddHandler lblTitle.MouseDown, AddressOf Form_MouseDown
    End Sub

    ' Variables for dragging
    Private isDragging As Boolean = False
    Private dragOffset As Point

    Private Sub Form_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            isDragging = True
            dragOffset = New Point(e.X, e.Y)
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If isDragging Then
            Dim currentScreenPos As Point = PointToScreen(e.Location)
            Me.Location = New Point(currentScreenPos.X - dragOffset.X, currentScreenPos.Y - dragOffset.Y)
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        If e.Button = MouseButtons.Left Then
            isDragging = False
        End If
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtName.Text) Then
            MessageBox.Show("Category name cannot be empty.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return
        End If

        Me.CategoryName = txtName.Text.Trim()
        Me.CategoryDescription = txtDescription.Text.Trim()
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ' Add focus effects to textboxes
    Private Sub TextBox_Enter(sender As Object, e As EventArgs)
        Dim txt As TextBox = DirectCast(sender, TextBox)
        txt.Parent.BackColor = InputFocusColor
        txt.BackColor = InputFocusColor
    End Sub

    Private Sub TextBox_Leave(sender As Object, e As EventArgs)
        Dim txt As TextBox = DirectCast(sender, TextBox)
        txt.Parent.BackColor = InputBgColor
        txt.BackColor = InputBgColor
    End Sub
End Class
