<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Alert
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
        Panel2 = New Panel()
        ExpTable = New DataGridView()
        SearchBar = New TextBox()
        Panel1 = New Panel()
        StockTable = New DataGridView()
        Label17 = New Label()
        Panel8.SuspendLayout()
        Panel2.SuspendLayout()
        CType(ExpTable, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(StockTable, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.FromArgb(CByte(205), CByte(180), CByte(90))
        Panel8.Controls.Add(Panel2)
        Panel8.Controls.Add(SearchBar)
        Panel8.Controls.Add(Panel1)
        Panel8.Controls.Add(Label17)
        Panel8.Location = New Point(8, 8)
        Panel8.Name = "Panel8"
        Panel8.Padding = New Padding(5)
        Panel8.Size = New Size(1120, 686)
        Panel8.TabIndex = 5
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(245), CByte(228), CByte(164))
        Panel2.Controls.Add(ExpTable)
        Panel2.Location = New Point(8, 368)
        Panel2.Name = "Panel2"
        Panel2.Padding = New Padding(5)
        Panel2.Size = New Size(1104, 310)
        Panel2.TabIndex = 3
        ' 
        ' ExpTable
        ' 
        ExpTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        ExpTable.Location = New Point(16, 2)
        ExpTable.Name = "ExpTable"
        ExpTable.Size = New Size(1088, 300)
        ExpTable.TabIndex = 0
        ' 
        ' SearchBar
        ' 
        SearchBar.Location = New Point(181, 8)
        SearchBar.Multiline = True
        SearchBar.Name = "SearchBar"
        SearchBar.Size = New Size(423, 31)
        SearchBar.TabIndex = 1
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(245), CByte(228), CByte(164))
        Panel1.Controls.Add(StockTable)
        Panel1.Location = New Point(8, 45)
        Panel1.Name = "Panel1"
        Panel1.Padding = New Padding(5)
        Panel1.Size = New Size(1104, 310)
        Panel1.TabIndex = 2
        ' 
        ' StockTable
        ' 
        StockTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        StockTable.Location = New Point(8, 7)
        StockTable.Name = "StockTable"
        StockTable.Size = New Size(1088, 300)
        StockTable.TabIndex = 0
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Segoe UI Semibold", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.ForeColor = Color.White
        Label17.Location = New Point(15, 6)
        Label17.Name = "Label17"
        Label17.Size = New Size(160, 32)
        Label17.TabIndex = 0
        Label17.Text = "Product Alert"
        ' 
        ' Alert
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(205), CByte(180), CByte(90))
        Controls.Add(Panel8)
        Name = "Alert"
        Padding = New Padding(5)
        Size = New Size(1136, 702)
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        Panel2.ResumeLayout(False)
        CType(ExpTable, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        CType(StockTable, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents SearchBar As TextBox
    Friend WithEvents StockTable As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ExpTable As DataGridView

End Class
