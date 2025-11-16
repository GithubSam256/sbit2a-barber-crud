<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class checkoutform
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Checkout1 = New Checkout()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' Checkout1
        ' 
        Checkout1.BackColor = Color.FromArgb(CByte(205), CByte(180), CByte(90))
        Checkout1.Location = New Point(0, 0)
        Checkout1.Name = "Checkout1"
        Checkout1.Padding = New Padding(5)
        Checkout1.Size = New Size(1136, 702)
        Checkout1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.FromArgb(CByte(205), CByte(180), CByte(90))
        Label1.Font = New Font("Segoe UI Semibold", 27.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(1079, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(45, 50)
        Label1.TabIndex = 2
        Label1.Text = "X"
        ' 
        ' checkoutform
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1136, 702)
        Controls.Add(Label1)
        Controls.Add(Checkout1)
        FormBorderStyle = FormBorderStyle.None
        Name = "checkoutform"
        StartPosition = FormStartPosition.CenterScreen
        Text = "checkoutform"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Checkout1 As Checkout
    Friend WithEvents Label1 As Label
End Class
