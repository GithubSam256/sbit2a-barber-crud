Imports sbit2a_barber_crud.SideBar

Public Class Form1
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        home.Show()
        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler SideBar1.showgifclicked, AddressOf showgif
        InitializeDatabase()
    End Sub


    Public Sub showgif(controlsToShow As List(Of ControlWithLocation))
        ' Clear previous controls
        scrollpanel.Controls.Clear()

        ' Add new controls with their locations
        For Each item In controlsToShow
            item.Control.Location = item.Location
            item.Control.Dock = DockStyle.None
            scrollpanel.Controls.Add(item.Control)
        Next
    End Sub


End Class
