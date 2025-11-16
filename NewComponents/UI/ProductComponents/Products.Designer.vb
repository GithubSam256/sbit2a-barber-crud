<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Product
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Panel8 = New Panel()
        Label1 = New Label()
        Button1 = New Button()
        TextBox1 = New TextBox()
        Panel1 = New Panel()
        PetTable = New DataGridView()
        Label17 = New Label()
        Panel8.SuspendLayout()
        Panel1.SuspendLayout()
        CType(PetTable, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.FromArgb(CByte(205), CByte(180), CByte(90))
        Panel8.Controls.Add(Label1)
        Panel8.Controls.Add(Button1)
        Panel8.Controls.Add(TextBox1)
        Panel8.Controls.Add(Panel1)
        Panel8.Controls.Add(Label17)
        Panel8.Location = New Point(0, 0)
        Panel8.Name = "Panel8"
        Panel8.Padding = New Padding(5)
        Panel8.Size = New Size(1136, 702)
        Panel8.TabIndex = 5
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(677, 12)
        Label1.Name = "Label1"
        Label1.Size = New Size(75, 30)
        Label1.TabIndex = 4
        Label1.Text = "Search"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(458, 641)
        Button1.Name = "Button1"
        Button1.Size = New Size(232, 53)
        Button1.TabIndex = 3
        Button1.Text = "Add Products"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(758, 13)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(362, 29)
        TextBox1.TabIndex = 1
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(245), CByte(228), CByte(164))
        Panel1.Controls.Add(PetTable)
        Panel1.Location = New Point(8, 48)
        Panel1.Name = "Panel1"
        Panel1.Padding = New Padding(5)
        Panel1.Size = New Size(1120, 587)
        Panel1.TabIndex = 2
        ' 
        ' PetTable
        ' 
        PetTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        PetTable.Location = New Point(8, 8)
        PetTable.Name = "PetTable"
        PetTable.Size = New Size(1104, 571)
        PetTable.TabIndex = 0
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.ForeColor = Color.White
        Label17.Location = New Point(15, 6)
        Label17.Name = "Label17"
        Label17.Size = New Size(109, 32)
        Label17.TabIndex = 0
        Label17.Text = "Products"
        ' 
        ' Product
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(26), CByte(34), CByte(44))
        Controls.Add(Panel8)
        Name = "Product"
        Padding = New Padding(5)
        Size = New Size(1136, 702)
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        Panel1.ResumeLayout(False)
        CType(PetTable, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents PetTable As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label

End Class
