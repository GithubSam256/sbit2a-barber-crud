<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        MainPanel = New Panel()
        scrollpanel = New Panel()
        DashBoard31 = New DashBoard3()
        DashBoard21 = New DashBoard2()
        navbar = New Panel()
        Label2 = New Label()
        Label1 = New Label()
        sidebar = New Panel()
        SideBar1 = New SideBar()
        DashBoard1 = New DashBoard()
        MainPanel.SuspendLayout()
        scrollpanel.SuspendLayout()
        navbar.SuspendLayout()
        sidebar.SuspendLayout()
        SuspendLayout()
        ' 
        ' MainPanel
        ' 
        MainPanel.Controls.Add(scrollpanel)
        MainPanel.Controls.Add(navbar)
        MainPanel.Controls.Add(sidebar)
        MainPanel.Dock = DockStyle.Fill
        MainPanel.Location = New Point(0, 0)
        MainPanel.Name = "MainPanel"
        MainPanel.Size = New Size(1366, 768)
        MainPanel.TabIndex = 0
        ' 
        ' scrollpanel
        ' 
        scrollpanel.AutoScroll = True
        scrollpanel.Controls.Add(DashBoard1)
        scrollpanel.Controls.Add(DashBoard31)
        scrollpanel.Controls.Add(DashBoard21)
        scrollpanel.Location = New Point(230, 66)
        scrollpanel.Name = "scrollpanel"
        scrollpanel.Size = New Size(1159, 702)
        scrollpanel.TabIndex = 1
        ' 
        ' DashBoard31
        ' 
        DashBoard31.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        DashBoard31.Location = New Point(0, 1336)
        DashBoard31.Name = "DashBoard31"
        DashBoard31.Padding = New Padding(5)
        DashBoard31.Size = New Size(1136, 668)
        DashBoard31.TabIndex = 2
        ' 
        ' DashBoard21
        ' 
        DashBoard21.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        DashBoard21.Location = New Point(0, 668)
        DashBoard21.Name = "DashBoard21"
        DashBoard21.Padding = New Padding(5)
        DashBoard21.Size = New Size(1136, 668)
        DashBoard21.TabIndex = 1
        ' 
        ' navbar
        ' 
        navbar.BackColor = Color.FromArgb(CByte(46), CByte(27), CByte(26))
        navbar.Controls.Add(Label2)
        navbar.Controls.Add(Label1)
        navbar.Location = New Point(230, 0)
        navbar.Name = "navbar"
        navbar.Size = New Size(1366, 66)
        navbar.TabIndex = 0
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.White
        Label2.Location = New Point(9, 16)
        Label2.Name = "Label2"
        Label2.Size = New Size(212, 32)
        Label2.TabIndex = 2
        Label2.Text = "Barber - SBIT-2A "
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI Semibold", 27.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(1087, 6)
        Label1.Name = "Label1"
        Label1.Size = New Size(45, 50)
        Label1.TabIndex = 1
        Label1.Text = "X"
        ' 
        ' sidebar
        ' 
        sidebar.BackColor = SystemColors.ActiveCaption
        sidebar.Controls.Add(SideBar1)
        sidebar.Dock = DockStyle.Left
        sidebar.Location = New Point(0, 0)
        sidebar.Name = "sidebar"
        sidebar.Size = New Size(230, 768)
        sidebar.TabIndex = 0
        ' 
        ' SideBar1
        ' 
        SideBar1.BackColor = Color.FromArgb(CByte(46), CByte(27), CByte(26))
        SideBar1.ForeColor = Color.FromArgb(CByte(248), CByte(203), CByte(46))
        SideBar1.Location = New Point(0, 0)
        SideBar1.Name = "SideBar1"
        SideBar1.Size = New Size(230, 768)
        SideBar1.TabIndex = 0
        ' 
        ' DashBoard1
        ' 
        DashBoard1.BackColor = Color.FromArgb(CByte(205), CByte(180), CByte(90))
        DashBoard1.Location = New Point(0, 0)
        DashBoard1.Name = "DashBoard1"
        DashBoard1.Padding = New Padding(5)
        DashBoard1.Size = New Size(1136, 668)
        DashBoard1.TabIndex = 3
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1366, 768)
        Controls.Add(MainPanel)
        FormBorderStyle = FormBorderStyle.None
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        MainPanel.ResumeLayout(False)
        scrollpanel.ResumeLayout(False)
        navbar.ResumeLayout(False)
        navbar.PerformLayout()
        sidebar.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents MainPanel As Panel
    Friend WithEvents navbar As Panel
    Friend WithEvents sidebar As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents scrollpanel As Panel
    Friend WithEvents DashBoard21 As DashBoard2
    Friend WithEvents DashBoard31 As DashBoard3
    Friend WithEvents SideBar1 As SideBar
    Friend WithEvents DashBoard1 As DashBoard

End Class
