Imports MySql.Data.MySqlClient

Public Class ProductPopUpForm
    Inherits Form

    Public Property ProductNamee As String
    Public Property Price As Decimal
    Public Property Cost As Decimal
    Public Property ReorderLevel As Integer
    Public Property CategoryId As Integer
    Public Property Quantity As Integer
    Public Property ExpiryDate As Date

    Private txtProductName As New TextBox()
    Private txtPrice As New TextBox()
    Private txtCost As New TextBox()
    Private txtReorderLevel As New TextBox()
    Private cboCategory As New ComboBox()
    Private txtQuantity As New TextBox()
    Private dtpExpiryDate As New DateTimePicker()
    Private btnSave As New Button()
    Private btnCancel As New Button()
    Private lblTitle As New Label()
    Private btnClose As New Button()
    Private lblQuantityLabel As New Label()

    ' Track if this is an edit mode
    Private _isEditMode As Boolean = False
    Private _productId As Integer = 0

    ' Modern dark theme color palette
    Private Shared ReadOnly BgColor As Color = Color.FromArgb(82, 75, 67)        ' Form background
    Private Shared ReadOnly InputBgColor As Color = Color.FromArgb(92, 85, 77)   ' TextBox/ComboBox background
    Private Shared ReadOnly InputFocusColor As Color = Color.FromArgb(110, 100, 92) ' Focused TextBox/ComboBox
    Private Shared ReadOnly FgColor As Color = Color.WhiteSmoke                  ' Text color
    Private Shared ReadOnly LabelColor As Color = Color.WhiteSmoke               ' Label color
    Private Shared ReadOnly AccentColor As Color = Color.FromArgb(120, 110, 100) ' Save button
    Private Shared ReadOnly AccentHoverColor As Color = Color.FromArgb(140, 130, 120) ' Save hover
    Private Shared ReadOnly ButtonColor As Color = Color.FromArgb(70, 64, 57)    ' Cancel button
    Private Shared ReadOnly ButtonHoverColor As Color = Color.FromArgb(90, 84, 77) ' Cancel hover
    Private Shared ReadOnly CloseHoverColor As Color = Color.FromArgb(180, 70, 70) ' Close button hover


    ' Constructor for INSERT mode
    Public Sub New()
        _isEditMode = False
        InitializeForm()
        LoadCategories()
    End Sub

    ' Constructor for UPDATE mode
    Public Sub New(prodId As Integer, name As String, price As Decimal, cost As Decimal, reorder As Integer, categoryId As Integer)
        _isEditMode = True
        Me._productId = prodId
        InitializeForm()
        LoadCategories()

        ' Pre-populate fields for editing
        txtProductName.Text = name
        txtPrice.Text = price.ToString("0.00")
        txtCost.Text = cost.ToString("0.00")
        txtReorderLevel.Text = reorder.ToString()

        ' Select the correct category
        For i As Integer = 0 To cboCategory.Items.Count - 1
            Dim item As CategoryItem = DirectCast(cboCategory.Items(i), CategoryItem)
            If item.Id = categoryId Then
                cboCategory.SelectedIndex = i
                Exit For
            End If
        Next

        ' Update UI for edit mode
        lblTitle.Text = "Edit Product"
        btnSave.Text = "Update Product"
        lblQuantityLabel.Text = "Add Stock Quantity"
    End Sub

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
            Return btnSave.Text
        End Get
        Set(value As String)
            btnSave.Text = value
        End Set
    End Property

    Private Sub InitializeForm()
        ' --- Form Settings ---
        Me.Text = ""
        Me.Size = New Size(520, 620)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterParent
        Me.BackColor = BgColor
        Me.Font = New Font("Segoe UI", 9.5F)

        ' --- Custom Close Button ---
        btnClose.Text = "×"
        btnClose.Location = New Point(480, 10)
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
        lblTitle.Text = "Add New Product"
        lblTitle.Location = New Point(30, 30)
        lblTitle.AutoSize = True
        lblTitle.ForeColor = FgColor
        lblTitle.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)

        Dim yPos As Integer = 85

        ' --- Product Name ---
        CreateLabel("Product Name", 30, yPos)
        Dim pnlProductName = CreateTextBoxPanel(txtProductName, 30, yPos + 25, 460)
        yPos += 80

        ' --- Price and Cost (Side by Side) ---
        CreateLabel("Price", 30, yPos)
        CreateLabel("Cost", 255, yPos)
        Dim pnlPrice = CreateTextBoxPanel(txtPrice, 30, yPos + 25, 210)
        Dim pnlCost = CreateTextBoxPanel(txtCost, 255, yPos + 25, 205)
        txtPrice.Text = "0.00"
        txtCost.Text = "0.00"
        yPos += 80

        ' --- Reorder Level and Quantity (Side by Side) ---
        CreateLabel("Reorder Level", 30, yPos)
        lblQuantityLabel = CreateLabel("Initial Quantity", 255, yPos)
        Dim pnlReorder = CreateTextBoxPanel(txtReorderLevel, 30, yPos + 25, 210)
        Dim pnlQuantity = CreateTextBoxPanel(txtQuantity, 255, yPos + 25, 205)
        txtReorderLevel.Text = "0"
        txtQuantity.Text = "0"
        yPos += 80

        ' --- Category Dropdown ---
        CreateLabel("Category", 30, yPos)
        Dim pnlCategory = CreateComboBoxPanel(cboCategory, 30, yPos + 25, 460)
        yPos += 80

        ' --- Expiry Date ---
        CreateLabel("Expiry Date", 30, yPos)
        Dim pnlExpiryDate = CreateDatePickerPanel(dtpExpiryDate, 30, yPos + 25, 460)
        yPos += 80

        ' --- Save Button ---
        btnSave.Text = "Add Product"
        btnSave.Location = New Point(30, yPos + 20)
        btnSave.Size = New Size(225, 42)
        btnSave.BackColor = AccentColor
        btnSave.ForeColor = FgColor
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnSave.Cursor = Cursors.Hand
        AddHandler btnSave.MouseEnter, Sub() btnSave.BackColor = AccentHoverColor
        AddHandler btnSave.MouseLeave, Sub() btnSave.BackColor = AccentColor
        AddHandler btnSave.Click, AddressOf BtnSave_Click

        ' --- Cancel Button ---
        btnCancel.Text = "Cancel"
        btnCancel.Location = New Point(265, yPos + 20)
        btnCancel.Size = New Size(225, 42)
        btnCancel.BackColor = ButtonColor
        btnCancel.ForeColor = FgColor
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.Font = New Font("Segoe UI", 10.0F)
        btnCancel.Cursor = Cursors.Hand
        AddHandler btnCancel.MouseEnter, Sub() btnCancel.BackColor = ButtonHoverColor
        AddHandler btnCancel.MouseLeave, Sub() btnCancel.BackColor = ButtonColor
        AddHandler btnCancel.Click, AddressOf BtnCancel_Click

        ' --- Add controls ---
        Me.Controls.AddRange(New Control() {
            btnClose, lblTitle,
            pnlProductName, pnlPrice, pnlCost,
            pnlReorder, pnlQuantity, pnlCategory,
            pnlExpiryDate, btnSave, btnCancel
        })

        ' Set tab order
        txtProductName.TabIndex = 0
        txtPrice.TabIndex = 1
        txtCost.TabIndex = 2
        txtReorderLevel.TabIndex = 3
        txtQuantity.TabIndex = 4
        cboCategory.TabIndex = 5
        dtpExpiryDate.TabIndex = 6
        btnSave.TabIndex = 7
        btnCancel.TabIndex = 8

        ' Accept/Cancel buttons
        Me.AcceptButton = btnSave
        Me.CancelButton = btnCancel

        ' Allow form dragging
        AddHandler Me.MouseDown, AddressOf Form_MouseDown
        AddHandler lblTitle.MouseDown, AddressOf Form_MouseDown
    End Sub

    Private Function CreateLabel(text As String, x As Integer, y As Integer) As Label
        Dim lbl As New Label() With {
            .Text = text,
            .Location = New Point(x, y),
            .AutoSize = True,
            .ForeColor = LabelColor,
            .Font = New Font("Segoe UI", 9.0F)
        }
        Me.Controls.Add(lbl)
        Return lbl
    End Function

    Private Function CreateTextBoxPanel(txt As TextBox, x As Integer, y As Integer, width As Integer) As Panel
        Dim pnl As New Panel() With {
            .Location = New Point(x, y),
            .Size = New Size(width, 40),
            .BackColor = InputBgColor
        }
        txt.Location = New Point(12, 8)
        txt.Width = width - 24
        txt.BorderStyle = BorderStyle.None
        txt.BackColor = InputBgColor
        txt.ForeColor = FgColor
        txt.Font = New Font("Segoe UI", 10.5F)
        AddHandler txt.Enter, AddressOf TextBox_Enter
        AddHandler txt.Leave, AddressOf TextBox_Leave
        pnl.Controls.Add(txt)
        Return pnl
    End Function

    Private Function CreateComboBoxPanel(cbo As ComboBox, x As Integer, y As Integer, width As Integer) As Panel
        Dim pnl As New Panel() With {
            .Location = New Point(x, y),
            .Size = New Size(width, 40),
            .BackColor = InputBgColor
        }
        cbo.Location = New Point(8, 6)
        cbo.Width = width - 16
        cbo.DropDownStyle = ComboBoxStyle.DropDownList
        cbo.FlatStyle = FlatStyle.Flat
        cbo.BackColor = InputBgColor
        cbo.ForeColor = FgColor
        cbo.Font = New Font("Segoe UI", 10.5F)
        AddHandler cbo.Enter, AddressOf ComboBox_Enter
        AddHandler cbo.Leave, AddressOf ComboBox_Leave
        pnl.Controls.Add(cbo)
        Return pnl
    End Function

    Private Function CreateDatePickerPanel(dtp As DateTimePicker, x As Integer, y As Integer, width As Integer) As Panel
        Dim pnl As New Panel() With {
            .Location = New Point(x, y),
            .Size = New Size(width, 40),
            .BackColor = InputBgColor
        }
        dtp.Location = New Point(8, 7)
        dtp.Width = width - 16
        dtp.Format = DateTimePickerFormat.Long
        dtp.Font = New Font("Segoe UI", 10.5F)
        dtp.CalendarForeColor = FgColor
        dtp.CalendarMonthBackground = InputBgColor
        AddHandler dtp.Enter, AddressOf DatePicker_Enter
        AddHandler dtp.Leave, AddressOf DatePicker_Leave
        pnl.Controls.Add(dtp)
        Return pnl
    End Function

    Private Sub LoadCategories()
        Try
            cboCategory.Items.Clear()

            Dim sql As String = "SELECT category_id, category_name FROM pet_categories ORDER BY category_name"
            Dim dt As DataTable = GlobalCrud.ExecuteQuery(sql, Nothing)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    cboCategory.Items.Add(New CategoryItem(row("category_id"), row("category_name").ToString()))
                Next

                If cboCategory.Items.Count > 0 Then
                    cboCategory.SelectedIndex = 0
                End If
            Else
                cboCategory.Items.Add(New CategoryItem(0, "No categories available"))
                cboCategory.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading categories: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Helper class for ComboBox items
    Private Class CategoryItem
        Public Property Id As Integer
        Public Property Name As String

        Public Sub New(id As Integer, name As String)
            Me.Id = id
            Me.Name = name
        End Sub

        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class

    ' Dragging functionality
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

    ' Focus effects
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

    Private Sub ComboBox_Enter(sender As Object, e As EventArgs)
        Dim cbo As ComboBox = DirectCast(sender, ComboBox)
        cbo.Parent.BackColor = InputFocusColor
    End Sub

    Private Sub ComboBox_Leave(sender As Object, e As EventArgs)
        Dim cbo As ComboBox = DirectCast(sender, ComboBox)
        cbo.Parent.BackColor = InputBgColor
    End Sub

    Private Sub DatePicker_Enter(sender As Object, e As EventArgs)
        Dim dtp As DateTimePicker = DirectCast(sender, DateTimePicker)
        dtp.Parent.BackColor = InputFocusColor
    End Sub

    Private Sub DatePicker_Leave(sender As Object, e As EventArgs)
        Dim dtp As DateTimePicker = DirectCast(sender, DateTimePicker)
        dtp.Parent.BackColor = InputBgColor
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
        ' Validation
        If String.IsNullOrWhiteSpace(txtProductName.Text) Then
            MessageBox.Show("Product name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProductName.Focus()
            Return
        End If

        Dim price As Decimal
        If Not Decimal.TryParse(txtPrice.Text, price) OrElse price < 0 Then
            MessageBox.Show("Please enter a valid price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrice.Focus()
            Return
        End If

        Dim cost As Decimal
        If Not Decimal.TryParse(txtCost.Text, cost) OrElse cost < 0 Then
            MessageBox.Show("Please enter a valid cost.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCost.Focus()
            Return
        End If

        Dim reorderLevel As Integer
        If Not Integer.TryParse(txtReorderLevel.Text, reorderLevel) OrElse reorderLevel < 0 Then
            MessageBox.Show("Please enter a valid reorder level.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtReorderLevel.Focus()
            Return
        End If

        Dim quantity As Integer
        If Not Integer.TryParse(txtQuantity.Text, quantity) OrElse quantity < 0 Then
            MessageBox.Show("Please enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.Focus()
            Return
        End If

        If cboCategory.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCategory.Focus()
            Return
        End If

        Dim selectedCategory As CategoryItem = DirectCast(cboCategory.SelectedItem, CategoryItem)
        If selectedCategory.Id = 0 Then
            MessageBox.Show("Please create a category first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Set properties
        Me.ProductNamee = txtProductName.Text.Trim()
        Me.Price = price
        Me.Cost = cost
        Me.ReorderLevel = reorderLevel
        Me.CategoryId = selectedCategory.Id
        Me.Quantity = quantity
        Me.ExpiryDate = dtpExpiryDate.Value.Date

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ' Public method to check if in edit mode
    Public ReadOnly Property IsEditMode As Boolean
        Get
            Return _isEditMode
        End Get
    End Property

    ' Public method to get product ID (for update operations)
    Public ReadOnly Property ProductId As Integer
        Get
            Return _productId
        End Get
    End Property
End Class
