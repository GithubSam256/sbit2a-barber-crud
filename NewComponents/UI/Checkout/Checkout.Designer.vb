<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Checkout
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
        CartPanel = New Panel()
        CheckoutBtn = New Button()
        GrandTotalLbl = New Label()
        Label1 = New Label()
        CartTable = New DataGridView()
        TextBox1 = New TextBox()
        Panel1 = New Panel()
        ViewPetTable = New DataGridView()
        Label17 = New Label()
        Panel8.SuspendLayout()
        CartPanel.SuspendLayout()
        CType(CartTable, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(ViewPetTable, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.FromArgb(CByte(205), CByte(180), CByte(90))
        Panel8.Controls.Add(CartPanel)
        Panel8.Controls.Add(TextBox1)
        Panel8.Controls.Add(Panel1)
        Panel8.Controls.Add(Label17)
        Panel8.Location = New Point(8, 8)
        Panel8.Name = "Panel8"
        Panel8.Padding = New Padding(5)
        Panel8.Size = New Size(1120, 686)
        Panel8.TabIndex = 5
        ' 
        ' CartPanel
        ' 
        CartPanel.BackColor = Color.FromArgb(CByte(245), CByte(228), CByte(164))
        CartPanel.Controls.Add(CheckoutBtn)
        CartPanel.Controls.Add(GrandTotalLbl)
        CartPanel.Controls.Add(Label1)
        CartPanel.Controls.Add(CartTable)
        CartPanel.Location = New Point(609, 45)
        CartPanel.Name = "CartPanel"
        CartPanel.Padding = New Padding(5)
        CartPanel.Size = New Size(503, 633)
        CartPanel.TabIndex = 3
        ' 
        ' CheckoutBtn
        ' 
        CheckoutBtn.Location = New Point(8, 581)
        CheckoutBtn.Name = "CheckoutBtn"
        CheckoutBtn.Size = New Size(487, 40)
        CheckoutBtn.TabIndex = 3
        CheckoutBtn.Text = "Checkout"
        CheckoutBtn.UseVisualStyleBackColor = True
        ' 
        ' GrandTotalLbl
        ' 
        GrandTotalLbl.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GrandTotalLbl.ForeColor = Color.FromArgb(CByte(46), CByte(27), CByte(26))
        GrandTotalLbl.Location = New Point(290, 544)
        GrandTotalLbl.Name = "GrandTotalLbl"
        GrandTotalLbl.Size = New Size(191, 25)
        GrandTotalLbl.TabIndex = 2
        GrandTotalLbl.Text = "$123,456"
        GrandTotalLbl.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(46), CByte(27), CByte(26))
        Label1.Location = New Point(8, 544)
        Label1.Name = "Label1"
        Label1.Size = New Size(108, 25)
        Label1.TabIndex = 1
        Label1.Text = "GrandTotal:"
        ' 
        ' CartTable
        ' 
        CartTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        CartTable.Location = New Point(7, 8)
        CartTable.Name = "CartTable"
        CartTable.Size = New Size(488, 533)
        CartTable.TabIndex = 0
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(136, 11)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(362, 31)
        TextBox1.TabIndex = 1
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(245), CByte(228), CByte(164))
        Panel1.Controls.Add(ViewPetTable)
        Panel1.Location = New Point(8, 45)
        Panel1.Name = "Panel1"
        Panel1.Padding = New Padding(5)
        Panel1.Size = New Size(595, 633)
        Panel1.TabIndex = 2
        ' 
        ' ViewPetTable
        ' 
        ViewPetTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        ViewPetTable.Location = New Point(7, 8)
        ViewPetTable.Name = "ViewPetTable"
        ViewPetTable.Size = New Size(580, 617)
        ViewPetTable.TabIndex = 0
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.ForeColor = Color.White
        Label17.Location = New Point(15, 6)
        Label17.Name = "Label17"
        Label17.Size = New Size(117, 32)
        Label17.TabIndex = 0
        Label17.Text = "Checkout"
        ' 
        ' Checkout
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(205), CByte(180), CByte(90))
        Controls.Add(Panel8)
        Name = "Checkout"
        Padding = New Padding(5)
        Size = New Size(1136, 702)
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        CartPanel.ResumeLayout(False)
        CartPanel.PerformLayout()
        CType(CartTable, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        CType(ViewPetTable, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ViewPetTable As DataGridView
    Friend WithEvents CartPanel As Panel
    Friend WithEvents CartTable As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents GrandTotalLbl As Label
    Friend WithEvents CheckoutBtn As Button

End Class
