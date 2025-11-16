<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DashBoard2
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
        TextBox1 = New TextBox()
        Panel1 = New Panel()
        ViewPetTable = New DataGridView()
        Label17 = New Label()
        Panel8.SuspendLayout()
        Panel1.SuspendLayout()
        CType(ViewPetTable, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.FromArgb(CByte(205), CByte(180), CByte(90))
        Panel8.Controls.Add(TextBox1)
        Panel8.Controls.Add(Panel1)
        Panel8.Controls.Add(Label17)
        Panel8.Location = New Point(8, 8)
        Panel8.Name = "Panel8"
        Panel8.Padding = New Padding(5)
        Panel8.Size = New Size(1120, 652)
        Panel8.TabIndex = 5
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(189, 11)
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
        Panel1.Size = New Size(1104, 599)
        Panel1.TabIndex = 2
        ' 
        ' ViewPetTable
        ' 
        ViewPetTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        ViewPetTable.Location = New Point(7, 8)
        ViewPetTable.Name = "ViewPetTable"
        ViewPetTable.Size = New Size(1089, 583)
        ViewPetTable.TabIndex = 0
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.ForeColor = Color.White
        Label17.Location = New Point(15, 6)
        Label17.Name = "Label17"
        Label17.Size = New Size(168, 32)
        Label17.TabIndex = 0
        Label17.Text = "View Products"
        ' 
        ' DashBoard2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(205), CByte(180), CByte(90))
        Controls.Add(Panel8)
        Name = "DashBoard2"
        Padding = New Padding(5)
        Size = New Size(1136, 668)
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        Panel1.ResumeLayout(False)
        CType(ViewPetTable, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ViewPetTable As DataGridView

End Class
