<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SideBar
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SideBar))
        FlowLayoutPanel1 = New FlowLayoutPanel()
        Button1 = New Button()
        Button6 = New Button()
        Button2 = New Button()
        Button7 = New Button()
        Button10 = New Button()
        Button11 = New Button()
        Label1 = New Label()
        FlowLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.BackColor = Color.FromArgb(CByte(46), CByte(27), CByte(26))
        FlowLayoutPanel1.Controls.Add(Button1)
        FlowLayoutPanel1.Controls.Add(Button6)
        FlowLayoutPanel1.Controls.Add(Button2)
        FlowLayoutPanel1.Controls.Add(Button7)
        FlowLayoutPanel1.Controls.Add(Button10)
        FlowLayoutPanel1.Controls.Add(Button11)
        FlowLayoutPanel1.Location = New Point(14, 69)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(201, 696)
        FlowLayoutPanel1.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Button1.ForeColor = Color.White
        Button1.Image = CType(resources.GetObject("Button1.Image"), Image)
        Button1.ImageAlign = ContentAlignment.MiddleLeft
        Button1.Location = New Point(3, 3)
        Button1.Name = "Button1"
        Button1.Size = New Size(198, 49)
        Button1.TabIndex = 0
        Button1.Text = "DashBoard"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button6
        ' 
        Button6.FlatAppearance.BorderSize = 0
        Button6.FlatStyle = FlatStyle.Flat
        Button6.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Button6.ForeColor = Color.White
        Button6.Image = CType(resources.GetObject("Button6.Image"), Image)
        Button6.ImageAlign = ContentAlignment.MiddleLeft
        Button6.Location = New Point(3, 58)
        Button6.Name = "Button6"
        Button6.Size = New Size(198, 49)
        Button6.TabIndex = 3
        Button6.Text = "Categories"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Button2.ForeColor = Color.White
        Button2.Image = CType(resources.GetObject("Button2.Image"), Image)
        Button2.ImageAlign = ContentAlignment.MiddleLeft
        Button2.Location = New Point(3, 113)
        Button2.Name = "Button2"
        Button2.Size = New Size(188, 49)
        Button2.TabIndex = 1
        Button2.Text = "Products"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button7
        ' 
        Button7.FlatAppearance.BorderSize = 0
        Button7.FlatStyle = FlatStyle.Flat
        Button7.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Button7.ForeColor = Color.White
        Button7.Image = CType(resources.GetObject("Button7.Image"), Image)
        Button7.ImageAlign = ContentAlignment.MiddleLeft
        Button7.Location = New Point(3, 168)
        Button7.Name = "Button7"
        Button7.Size = New Size(240, 49)
        Button7.TabIndex = 4
        Button7.Text = "Transactions"
        Button7.UseVisualStyleBackColor = True
        ' 
        ' Button10
        ' 
        Button10.FlatAppearance.BorderSize = 0
        Button10.FlatStyle = FlatStyle.Flat
        Button10.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Button10.ForeColor = Color.White
        Button10.Image = CType(resources.GetObject("Button10.Image"), Image)
        Button10.ImageAlign = ContentAlignment.MiddleLeft
        Button10.Location = New Point(3, 223)
        Button10.Name = "Button10"
        Button10.Size = New Size(240, 49)
        Button10.TabIndex = 7
        Button10.Text = "Product Alerts"
        Button10.UseVisualStyleBackColor = True
        ' 
        ' Button11
        ' 
        Button11.FlatAppearance.BorderSize = 0
        Button11.FlatStyle = FlatStyle.Flat
        Button11.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Button11.ForeColor = Color.White
        Button11.Image = CType(resources.GetObject("Button11.Image"), Image)
        Button11.ImageAlign = ContentAlignment.MiddleLeft
        Button11.Location = New Point(3, 278)
        Button11.Name = "Button11"
        Button11.Size = New Size(198, 49)
        Button11.TabIndex = 8
        Button11.Text = "Checkout"
        Button11.UseVisualStyleBackColor = True
        Button11.Visible = False
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.FromArgb(CByte(46), CByte(27), CByte(26))
        Label1.Font = New Font("Bauhaus 93", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(0, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(230, 66)
        Label1.TabIndex = 9
        Label1.Text = "Pet Shop Menu"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' SideBar
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(46), CByte(27), CByte(26))
        Controls.Add(FlowLayoutPanel1)
        Controls.Add(Label1)
        ForeColor = Color.FromArgb(CByte(248), CByte(203), CByte(46))
        Name = "SideBar"
        Size = New Size(230, 768)
        FlowLayoutPanel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Label1 As Label

End Class
