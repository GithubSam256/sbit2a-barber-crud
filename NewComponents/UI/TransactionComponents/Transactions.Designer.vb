<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Transactions
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
        SearchBar1 = New TextBox()
        Label1 = New Label()
        Panel2 = New Panel()
        ViewRestocksTable = New DataGridView()
        SearchBar = New TextBox()
        Panel1 = New Panel()
        ViewSalesTable = New DataGridView()
        Label17 = New Label()
        Panel8.SuspendLayout()
        Panel2.SuspendLayout()
        CType(ViewRestocksTable, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(ViewSalesTable, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.FromArgb(CByte(205), CByte(180), CByte(90))
        Panel8.Controls.Add(SearchBar1)
        Panel8.Controls.Add(Label1)
        Panel8.Controls.Add(Panel2)
        Panel8.Controls.Add(SearchBar)
        Panel8.Controls.Add(Panel1)
        Panel8.Controls.Add(Label17)
        Panel8.Location = New Point(8, 8)
        Panel8.Name = "Panel8"
        Panel8.Padding = New Padding(5)
        Panel8.Size = New Size(1120, 738)
        Panel8.TabIndex = 5
        ' 
        ' SearchBar1
        ' 
        SearchBar1.Location = New Point(220, 369)
        SearchBar1.Multiline = True
        SearchBar1.Name = "SearchBar1"
        SearchBar1.Size = New Size(384, 31)
        SearchBar1.TabIndex = 5
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(8, 366)
        Label1.Name = "Label1"
        Label1.Size = New Size(214, 32)
        Label1.TabIndex = 4
        Label1.Text = "Product Purchases"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(245), CByte(228), CByte(164))
        Panel2.Controls.Add(ViewRestocksTable)
        Panel2.Location = New Point(8, 410)
        Panel2.Margin = New Padding(5)
        Panel2.Name = "Panel2"
        Panel2.Padding = New Padding(5)
        Panel2.Size = New Size(1104, 316)
        Panel2.TabIndex = 3
        ' 
        ' ViewRestocksTable
        ' 
        ViewRestocksTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        ViewRestocksTable.Location = New Point(8, 8)
        ViewRestocksTable.Name = "ViewRestocksTable"
        ViewRestocksTable.Size = New Size(1088, 300)
        ViewRestocksTable.TabIndex = 0
        ' 
        ' SearchBar
        ' 
        SearchBar.Location = New Point(182, 8)
        SearchBar.Multiline = True
        SearchBar.Name = "SearchBar"
        SearchBar.Size = New Size(422, 31)
        SearchBar.TabIndex = 1
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(245), CByte(228), CByte(164))
        Panel1.Controls.Add(ViewSalesTable)
        Panel1.Location = New Point(8, 45)
        Panel1.Margin = New Padding(5)
        Panel1.Name = "Panel1"
        Panel1.Padding = New Padding(5)
        Panel1.Size = New Size(1104, 315)
        Panel1.TabIndex = 2
        ' 
        ' ViewSalesTable
        ' 
        ViewSalesTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        ViewSalesTable.Location = New Point(8, 7)
        ViewSalesTable.Name = "ViewSalesTable"
        ViewSalesTable.Size = New Size(1088, 300)
        ViewSalesTable.TabIndex = 0
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Segoe UI Semibold", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.ForeColor = Color.White
        Label17.Location = New Point(15, 6)
        Label17.Name = "Label17"
        Label17.Size = New Size(161, 32)
        Label17.TabIndex = 0
        Label17.Text = "Product Sales"
        ' 
        ' Transactions
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(205), CByte(180), CByte(90))
        Controls.Add(Panel8)
        Name = "Transactions"
        Padding = New Padding(5)
        Size = New Size(1136, 756)
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        Panel2.ResumeLayout(False)
        CType(ViewRestocksTable, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        CType(ViewSalesTable, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents SearchBar As TextBox
    Friend WithEvents ViewSalesTable As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ViewRestocksTable As DataGridView
    Friend WithEvents SearchBar1 As TextBox
    Friend WithEvents Label1 As Label

End Class
