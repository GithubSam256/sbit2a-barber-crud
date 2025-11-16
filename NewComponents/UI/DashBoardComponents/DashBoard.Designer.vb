<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DashBoard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DashBoard))
        FlowLayoutPanel1 = New FlowLayoutPanel()
        Panel1 = New Panel()
        FlowLayoutPanel2 = New FlowLayoutPanel()
        Label1 = New Label()
        TotalProduct = New Label()
        Label3 = New Label()
        Panel2 = New Panel()
        FlowLayoutPanel3 = New FlowLayoutPanel()
        Label5 = New Label()
        TotalSales = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Panel3 = New Panel()
        FlowLayoutPanel4 = New FlowLayoutPanel()
        Label9 = New Label()
        TotalCost = New Label()
        Label11 = New Label()
        Label12 = New Label()
        Panel4 = New Panel()
        FlowLayoutPanel5 = New FlowLayoutPanel()
        Label13 = New Label()
        TotalProfit = New Label()
        Label15 = New Label()
        Label16 = New Label()
        BarContainer = New FlowLayoutPanel()
        barcomponent = New Panel()
        Panel5 = New Panel()
        Panel6 = New Panel()
        Panel7 = New Panel()
        FlowLayoutPanel6 = New FlowLayoutPanel()
        FlowLayoutPanel7 = New FlowLayoutPanel()
        Label18 = New Label()
        Label19 = New Label()
        Label20 = New Label()
        Label21 = New Label()
        Label22 = New Label()
        Label23 = New Label()
        Label24 = New Label()
        Label25 = New Label()
        Label26 = New Label()
        Label17 = New Label()
        Panel8 = New Panel()
        BarChart = New Panel()
        FlowLayoutPanel8 = New FlowLayoutPanel()
        Label27 = New Label()
        Label28 = New Label()
        Label29 = New Label()
        Label30 = New Label()
        Panel9 = New Panel()
        Label35 = New Label()
        PieChart = New Panel()
        FlowLayoutPanel1.SuspendLayout()
        Panel1.SuspendLayout()
        FlowLayoutPanel2.SuspendLayout()
        Panel2.SuspendLayout()
        FlowLayoutPanel3.SuspendLayout()
        Panel3.SuspendLayout()
        FlowLayoutPanel4.SuspendLayout()
        Panel4.SuspendLayout()
        FlowLayoutPanel5.SuspendLayout()
        BarContainer.SuspendLayout()
        FlowLayoutPanel7.SuspendLayout()
        Panel8.SuspendLayout()
        FlowLayoutPanel8.SuspendLayout()
        Panel9.SuspendLayout()
        SuspendLayout()
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.BackColor = Color.FromArgb(CByte(205), CByte(180), CByte(90))
        FlowLayoutPanel1.Controls.Add(Panel1)
        FlowLayoutPanel1.Controls.Add(Panel2)
        FlowLayoutPanel1.Controls.Add(Panel3)
        FlowLayoutPanel1.Controls.Add(Panel4)
        FlowLayoutPanel1.Location = New Point(0, 0)
        FlowLayoutPanel1.Margin = New Padding(20)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Padding = New Padding(0, 10, 0, 10)
        FlowLayoutPanel1.Size = New Size(1136, 184)
        FlowLayoutPanel1.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(46), CByte(27), CByte(26))
        Panel1.Controls.Add(FlowLayoutPanel2)
        Panel1.Location = New Point(5, 15)
        Panel1.Margin = New Padding(5)
        Panel1.Name = "Panel1"
        Panel1.Padding = New Padding(15, 10, 15, 10)
        Panel1.Size = New Size(264, 150)
        Panel1.TabIndex = 0
        ' 
        ' FlowLayoutPanel2
        ' 
        FlowLayoutPanel2.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        FlowLayoutPanel2.Controls.Add(Label1)
        FlowLayoutPanel2.Controls.Add(TotalProduct)
        FlowLayoutPanel2.Controls.Add(Label3)
        FlowLayoutPanel2.Location = New Point(17, 12)
        FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        FlowLayoutPanel2.Size = New Size(228, 124)
        FlowLayoutPanel2.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        Label1.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Image = CType(resources.GetObject("Label1.Image"), Image)
        Label1.ImageAlign = ContentAlignment.MiddleLeft
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(225, 52)
        Label1.TabIndex = 0
        ' 
        ' TotalProduct
        ' 
        TotalProduct.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        TotalProduct.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TotalProduct.ForeColor = Color.White
        TotalProduct.Location = New Point(3, 52)
        TotalProduct.Name = "TotalProduct"
        TotalProduct.Size = New Size(225, 37)
        TotalProduct.TabIndex = 1
        TotalProduct.Text = "$3.456"
        TotalProduct.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label3
        ' 
        Label3.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        Label3.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.White
        Label3.Location = New Point(3, 89)
        Label3.Name = "Label3"
        Label3.Size = New Size(118, 37)
        Label3.TabIndex = 2
        Label3.Text = "Total Products"
        Label3.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(46), CByte(27), CByte(26))
        Panel2.Controls.Add(FlowLayoutPanel3)
        Panel2.Location = New Point(284, 13)
        Panel2.Margin = New Padding(10, 3, 10, 3)
        Panel2.Name = "Panel2"
        Panel2.Padding = New Padding(15, 10, 15, 10)
        Panel2.Size = New Size(264, 150)
        Panel2.TabIndex = 1
        ' 
        ' FlowLayoutPanel3
        ' 
        FlowLayoutPanel3.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        FlowLayoutPanel3.Controls.Add(Label5)
        FlowLayoutPanel3.Controls.Add(TotalSales)
        FlowLayoutPanel3.Controls.Add(Label7)
        FlowLayoutPanel3.Controls.Add(Label8)
        FlowLayoutPanel3.Location = New Point(16, 13)
        FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        FlowLayoutPanel3.Size = New Size(233, 124)
        FlowLayoutPanel3.TabIndex = 2
        ' 
        ' Label5
        ' 
        Label5.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        Label5.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.White
        Label5.Image = CType(resources.GetObject("Label5.Image"), Image)
        Label5.ImageAlign = ContentAlignment.MiddleLeft
        Label5.Location = New Point(3, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(225, 52)
        Label5.TabIndex = 0
        ' 
        ' TotalSales
        ' 
        TotalSales.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        TotalSales.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TotalSales.ForeColor = Color.White
        TotalSales.Location = New Point(3, 52)
        TotalSales.Name = "TotalSales"
        TotalSales.Size = New Size(225, 37)
        TotalSales.TabIndex = 1
        TotalSales.Text = "$3.456"
        TotalSales.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label7
        ' 
        Label7.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        Label7.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.White
        Label7.Location = New Point(3, 89)
        Label7.Name = "Label7"
        Label7.Size = New Size(118, 37)
        Label7.TabIndex = 2
        Label7.Text = "Total Sales"
        Label7.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label8
        ' 
        Label8.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        Label8.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = Color.FromArgb(CByte(0), CByte(191), CByte(99))
        Label8.Location = New Point(127, 89)
        Label8.Name = "Label8"
        Label8.Size = New Size(103, 37)
        Label8.TabIndex = 3
        Label8.Text = "0.45%"
        Label8.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(46), CByte(27), CByte(26))
        Panel3.Controls.Add(FlowLayoutPanel4)
        Panel3.Location = New Point(568, 13)
        Panel3.Margin = New Padding(10, 3, 10, 3)
        Panel3.Name = "Panel3"
        Panel3.Padding = New Padding(15, 10, 15, 10)
        Panel3.Size = New Size(264, 150)
        Panel3.TabIndex = 2
        ' 
        ' FlowLayoutPanel4
        ' 
        FlowLayoutPanel4.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        FlowLayoutPanel4.Controls.Add(Label9)
        FlowLayoutPanel4.Controls.Add(TotalCost)
        FlowLayoutPanel4.Controls.Add(Label11)
        FlowLayoutPanel4.Controls.Add(Label12)
        FlowLayoutPanel4.Location = New Point(16, 11)
        FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        FlowLayoutPanel4.Size = New Size(233, 124)
        FlowLayoutPanel4.TabIndex = 2
        ' 
        ' Label9
        ' 
        Label9.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        Label9.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.White
        Label9.Image = CType(resources.GetObject("Label9.Image"), Image)
        Label9.ImageAlign = ContentAlignment.MiddleLeft
        Label9.Location = New Point(3, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(225, 52)
        Label9.TabIndex = 0
        ' 
        ' TotalCost
        ' 
        TotalCost.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        TotalCost.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TotalCost.ForeColor = Color.White
        TotalCost.Location = New Point(3, 52)
        TotalCost.Name = "TotalCost"
        TotalCost.Size = New Size(225, 37)
        TotalCost.TabIndex = 1
        TotalCost.Text = "$3.456"
        TotalCost.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label11
        ' 
        Label11.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        Label11.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.White
        Label11.Location = New Point(3, 89)
        Label11.Name = "Label11"
        Label11.Size = New Size(118, 37)
        Label11.TabIndex = 2
        Label11.Text = "Total Cost"
        Label11.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label12
        ' 
        Label12.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        Label12.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label12.ForeColor = Color.FromArgb(CByte(0), CByte(191), CByte(99))
        Label12.Location = New Point(127, 89)
        Label12.Name = "Label12"
        Label12.Size = New Size(103, 37)
        Label12.TabIndex = 3
        Label12.Text = "0.45%"
        Label12.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.FromArgb(CByte(46), CByte(27), CByte(26))
        Panel4.Controls.Add(FlowLayoutPanel5)
        Panel4.Location = New Point(852, 13)
        Panel4.Margin = New Padding(10, 3, 10, 3)
        Panel4.Name = "Panel4"
        Panel4.Padding = New Padding(15, 10, 15, 10)
        Panel4.Size = New Size(269, 150)
        Panel4.TabIndex = 3
        ' 
        ' FlowLayoutPanel5
        ' 
        FlowLayoutPanel5.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        FlowLayoutPanel5.Controls.Add(Label13)
        FlowLayoutPanel5.Controls.Add(TotalProfit)
        FlowLayoutPanel5.Controls.Add(Label15)
        FlowLayoutPanel5.Controls.Add(Label16)
        FlowLayoutPanel5.Location = New Point(18, 12)
        FlowLayoutPanel5.Name = "FlowLayoutPanel5"
        FlowLayoutPanel5.Size = New Size(233, 124)
        FlowLayoutPanel5.TabIndex = 2
        ' 
        ' Label13
        ' 
        Label13.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        Label13.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.ForeColor = Color.White
        Label13.Image = CType(resources.GetObject("Label13.Image"), Image)
        Label13.ImageAlign = ContentAlignment.MiddleLeft
        Label13.Location = New Point(3, 0)
        Label13.Name = "Label13"
        Label13.Size = New Size(225, 52)
        Label13.TabIndex = 0
        ' 
        ' TotalProfit
        ' 
        TotalProfit.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        TotalProfit.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TotalProfit.ForeColor = Color.White
        TotalProfit.Location = New Point(3, 52)
        TotalProfit.Name = "TotalProfit"
        TotalProfit.Size = New Size(225, 37)
        TotalProfit.TabIndex = 1
        TotalProfit.Text = "$3.456"
        TotalProfit.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label15
        ' 
        Label15.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        Label15.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label15.ForeColor = Color.White
        Label15.Location = New Point(3, 89)
        Label15.Name = "Label15"
        Label15.Size = New Size(118, 37)
        Label15.TabIndex = 2
        Label15.Text = "Total Profit"
        Label15.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label16
        ' 
        Label16.BackColor = Color.FromArgb(CByte(70), CByte(64), CByte(57))
        Label16.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label16.ForeColor = Color.FromArgb(CByte(0), CByte(191), CByte(99))
        Label16.Location = New Point(127, 89)
        Label16.Name = "Label16"
        Label16.Size = New Size(103, 37)
        Label16.TabIndex = 3
        Label16.Text = "0.45%"
        Label16.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' BarContainer
        ' 
        BarContainer.BackColor = Color.FromArgb(CByte(36), CByte(48), CByte(63))
        BarContainer.Controls.Add(barcomponent)
        BarContainer.Controls.Add(Panel5)
        BarContainer.Controls.Add(Panel6)
        BarContainer.Controls.Add(Panel7)
        BarContainer.Controls.Add(FlowLayoutPanel6)
        BarContainer.Location = New Point(71, 369)
        BarContainer.Name = "BarContainer"
        BarContainer.Size = New Size(429, 323)
        BarContainer.TabIndex = 1
        BarContainer.Visible = False
        ' 
        ' barcomponent
        ' 
        barcomponent.Location = New Point(10, 10)
        barcomponent.Margin = New Padding(10)
        barcomponent.Name = "barcomponent"
        barcomponent.Size = New Size(86, 406)
        barcomponent.TabIndex = 0
        ' 
        ' Panel5
        ' 
        Panel5.Location = New Point(116, 10)
        Panel5.Margin = New Padding(10)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(86, 404)
        Panel5.TabIndex = 1
        ' 
        ' Panel6
        ' 
        Panel6.Location = New Point(222, 10)
        Panel6.Margin = New Padding(10)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(86, 406)
        Panel6.TabIndex = 2
        ' 
        ' Panel7
        ' 
        Panel7.Location = New Point(328, 10)
        Panel7.Margin = New Padding(10)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(86, 406)
        Panel7.TabIndex = 3
        ' 
        ' FlowLayoutPanel6
        ' 
        FlowLayoutPanel6.Location = New Point(3, 429)
        FlowLayoutPanel6.Name = "FlowLayoutPanel6"
        FlowLayoutPanel6.Size = New Size(200, 100)
        FlowLayoutPanel6.TabIndex = 4
        ' 
        ' FlowLayoutPanel7
        ' 
        FlowLayoutPanel7.Controls.Add(Label18)
        FlowLayoutPanel7.Controls.Add(Label19)
        FlowLayoutPanel7.Controls.Add(Label20)
        FlowLayoutPanel7.Controls.Add(Label21)
        FlowLayoutPanel7.Controls.Add(Label22)
        FlowLayoutPanel7.Controls.Add(Label23)
        FlowLayoutPanel7.Controls.Add(Label24)
        FlowLayoutPanel7.Controls.Add(Label25)
        FlowLayoutPanel7.Controls.Add(Label26)
        FlowLayoutPanel7.Location = New Point(13, 369)
        FlowLayoutPanel7.Name = "FlowLayoutPanel7"
        FlowLayoutPanel7.Size = New Size(55, 323)
        FlowLayoutPanel7.TabIndex = 4
        FlowLayoutPanel7.Visible = False
        ' 
        ' Label18
        ' 
        Label18.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label18.ForeColor = Color.White
        Label18.Location = New Point(3, 0)
        Label18.Margin = New Padding(3, 0, 3, 10)
        Label18.Name = "Label18"
        Label18.Padding = New Padding(0, 0, 0, 10)
        Label18.Size = New Size(52, 27)
        Label18.TabIndex = 0
        Label18.Text = "- 100"
        ' 
        ' Label19
        ' 
        Label19.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label19.ForeColor = Color.White
        Label19.Location = New Point(3, 37)
        Label19.Margin = New Padding(3, 0, 3, 10)
        Label19.Name = "Label19"
        Label19.Padding = New Padding(0, 0, 0, 10)
        Label19.Size = New Size(52, 27)
        Label19.TabIndex = 1
        Label19.Text = "- 100"
        ' 
        ' Label20
        ' 
        Label20.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label20.ForeColor = Color.White
        Label20.Location = New Point(3, 74)
        Label20.Margin = New Padding(3, 0, 3, 10)
        Label20.Name = "Label20"
        Label20.Padding = New Padding(0, 0, 0, 10)
        Label20.Size = New Size(52, 27)
        Label20.TabIndex = 2
        Label20.Text = "- 100"
        ' 
        ' Label21
        ' 
        Label21.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label21.ForeColor = Color.White
        Label21.Location = New Point(3, 111)
        Label21.Margin = New Padding(3, 0, 3, 10)
        Label21.Name = "Label21"
        Label21.Padding = New Padding(0, 0, 0, 10)
        Label21.Size = New Size(52, 27)
        Label21.TabIndex = 3
        Label21.Text = "- 100"
        ' 
        ' Label22
        ' 
        Label22.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label22.ForeColor = Color.White
        Label22.Location = New Point(3, 148)
        Label22.Margin = New Padding(3, 0, 3, 10)
        Label22.Name = "Label22"
        Label22.Padding = New Padding(0, 0, 0, 10)
        Label22.Size = New Size(52, 27)
        Label22.TabIndex = 4
        Label22.Text = "- 100"
        ' 
        ' Label23
        ' 
        Label23.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label23.ForeColor = Color.White
        Label23.Location = New Point(3, 185)
        Label23.Margin = New Padding(3, 0, 3, 10)
        Label23.Name = "Label23"
        Label23.Padding = New Padding(0, 0, 0, 10)
        Label23.Size = New Size(52, 27)
        Label23.TabIndex = 5
        Label23.Text = "- 100"
        ' 
        ' Label24
        ' 
        Label24.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label24.ForeColor = Color.White
        Label24.Location = New Point(3, 222)
        Label24.Margin = New Padding(3, 0, 3, 10)
        Label24.Name = "Label24"
        Label24.Padding = New Padding(0, 0, 0, 10)
        Label24.Size = New Size(52, 27)
        Label24.TabIndex = 6
        Label24.Text = "- 100"
        ' 
        ' Label25
        ' 
        Label25.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label25.ForeColor = Color.White
        Label25.Location = New Point(3, 259)
        Label25.Margin = New Padding(3, 0, 3, 10)
        Label25.Name = "Label25"
        Label25.Padding = New Padding(0, 0, 0, 10)
        Label25.Size = New Size(52, 27)
        Label25.TabIndex = 7
        Label25.Text = "- 100"
        ' 
        ' Label26
        ' 
        Label26.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label26.ForeColor = Color.White
        Label26.Location = New Point(3, 296)
        Label26.Margin = New Padding(3, 0, 3, 10)
        Label26.Name = "Label26"
        Label26.Padding = New Padding(0, 0, 0, 10)
        Label26.Size = New Size(52, 27)
        Label26.TabIndex = 8
        Label26.Text = "- 100"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Segoe UI Semibold", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.ForeColor = Color.White
        Label17.Location = New Point(30, 8)
        Label17.Name = "Label17"
        Label17.Size = New Size(147, 32)
        Label17.TabIndex = 0
        Label17.Text = "Stock Status"
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.FromArgb(CByte(46), CByte(27), CByte(26))
        Panel8.Controls.Add(BarChart)
        Panel8.Controls.Add(FlowLayoutPanel8)
        Panel8.Controls.Add(Label17)
        Panel8.Controls.Add(BarContainer)
        Panel8.Controls.Add(FlowLayoutPanel7)
        Panel8.Location = New Point(578, 202)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(548, 453)
        Panel8.TabIndex = 5
        ' 
        ' BarChart
        ' 
        BarChart.Location = New Point(31, 49)
        BarChart.Name = "BarChart"
        BarChart.Size = New Size(490, 385)
        BarChart.TabIndex = 6
        ' 
        ' FlowLayoutPanel8
        ' 
        FlowLayoutPanel8.Controls.Add(Label27)
        FlowLayoutPanel8.Controls.Add(Label28)
        FlowLayoutPanel8.Controls.Add(Label29)
        FlowLayoutPanel8.Controls.Add(Label30)
        FlowLayoutPanel8.Location = New Point(85, 709)
        FlowLayoutPanel8.Name = "FlowLayoutPanel8"
        FlowLayoutPanel8.Size = New Size(419, 46)
        FlowLayoutPanel8.TabIndex = 5
        FlowLayoutPanel8.Visible = False
        ' 
        ' Label27
        ' 
        Label27.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label27.ForeColor = Color.White
        Label27.Image = CType(resources.GetObject("Label27.Image"), Image)
        Label27.ImageAlign = ContentAlignment.MiddleLeft
        Label27.Location = New Point(3, 0)
        Label27.Margin = New Padding(3, 0, 3, 10)
        Label27.Name = "Label27"
        Label27.Padding = New Padding(0, 0, 0, 10)
        Label27.Size = New Size(97, 46)
        Label27.TabIndex = 9
        Label27.Text = "Total"
        Label27.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label28
        ' 
        Label28.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label28.ForeColor = Color.White
        Label28.Image = CType(resources.GetObject("Label28.Image"), Image)
        Label28.ImageAlign = ContentAlignment.MiddleLeft
        Label28.Location = New Point(106, 0)
        Label28.Margin = New Padding(3, 0, 3, 10)
        Label28.Name = "Label28"
        Label28.Padding = New Padding(0, 0, 0, 10)
        Label28.Size = New Size(97, 46)
        Label28.TabIndex = 10
        Label28.Text = "Low"
        Label28.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label29
        ' 
        Label29.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label29.ForeColor = Color.White
        Label29.Image = CType(resources.GetObject("Label29.Image"), Image)
        Label29.ImageAlign = ContentAlignment.MiddleLeft
        Label29.Location = New Point(209, 0)
        Label29.Margin = New Padding(3, 0, 3, 10)
        Label29.Name = "Label29"
        Label29.Padding = New Padding(0, 0, 0, 10)
        Label29.Size = New Size(97, 46)
        Label29.TabIndex = 11
        Label29.Text = "OOS"
        Label29.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label30
        ' 
        Label30.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label30.ForeColor = Color.White
        Label30.Image = CType(resources.GetObject("Label30.Image"), Image)
        Label30.ImageAlign = ContentAlignment.MiddleLeft
        Label30.Location = New Point(312, 0)
        Label30.Margin = New Padding(3, 0, 3, 10)
        Label30.Name = "Label30"
        Label30.Padding = New Padding(0, 0, 0, 10)
        Label30.Size = New Size(97, 46)
        Label30.TabIndex = 12
        Label30.Text = "Exp"
        Label30.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel9
        ' 
        Panel9.BackColor = Color.FromArgb(CByte(46), CByte(27), CByte(26))
        Panel9.Controls.Add(Label35)
        Panel9.Controls.Add(PieChart)
        Panel9.Location = New Point(10, 202)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(548, 453)
        Panel9.TabIndex = 6
        ' 
        ' Label35
        ' 
        Label35.AutoSize = True
        Label35.Font = New Font("Segoe UI Semibold", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label35.ForeColor = Color.White
        Label35.Location = New Point(25, 8)
        Label35.Name = "Label35"
        Label35.Size = New Size(222, 32)
        Label35.TabIndex = 0
        Label35.Text = "Top Category Sales"
        ' 
        ' PieChart
        ' 
        PieChart.Location = New Point(26, 49)
        PieChart.Name = "PieChart"
        PieChart.Size = New Size(495, 386)
        PieChart.TabIndex = 6
        ' 
        ' DashBoard
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(205), CByte(180), CByte(90))
        Controls.Add(Panel9)
        Controls.Add(Panel8)
        Controls.Add(FlowLayoutPanel1)
        Name = "DashBoard"
        Padding = New Padding(5)
        Size = New Size(1136, 668)
        FlowLayoutPanel1.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        FlowLayoutPanel2.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        FlowLayoutPanel3.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        FlowLayoutPanel4.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        FlowLayoutPanel5.ResumeLayout(False)
        BarContainer.ResumeLayout(False)
        FlowLayoutPanel7.ResumeLayout(False)
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        FlowLayoutPanel8.ResumeLayout(False)
        Panel9.ResumeLayout(False)
        Panel9.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents TotalProduct As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents TotalSales As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents FlowLayoutPanel4 As FlowLayoutPanel
    Friend WithEvents Label9 As Label
    Friend WithEvents TotalCost As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents FlowLayoutPanel5 As FlowLayoutPanel
    Friend WithEvents Label13 As Label
    Friend WithEvents TotalProfit As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents BarContainer As FlowLayoutPanel
    Friend WithEvents barcomponent As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents FlowLayoutPanel7 As FlowLayoutPanel
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents FlowLayoutPanel6 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel8 As FlowLayoutPanel
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label35 As Label
    Friend WithEvents PieChart As Panel
    Friend WithEvents BarChart As Panel

End Class
