Public Class SideBar

    Public Event showgifclicked(ByVal controlsToShow As List(Of ControlWithLocation))

    Public Class ControlWithLocation
        Public Property Control As UserControl
        Public Property Location As Point

        Public Sub New(ctrl As UserControl, loc As Point)
            Control = ctrl
            Location = loc
        End Sub
    End Class

    Public Sub ContentLoader(ParamArray controlsToLoad() As ControlWithLocation)

        Dim controls As New List(Of ControlWithLocation)(controlsToLoad)

        RaiseEvent showgifclicked(controls)
    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        ContentLoader(
         New ControlWithLocation(New DashBoard(), New Point(0, 0)),
         New ControlWithLocation(New DashBoard2(), New Point(0, 668)),
        New ControlWithLocation(New DashBoard3(), New Point(0, 1336)))

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        ContentLoader(
         New ControlWithLocation(New Product(), New Point(0, 0)))
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        ContentLoader(
         New ControlWithLocation(New Transactions(), New Point(0, 0)))
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ContentLoader(
         New ControlWithLocation(New Category(), New Point(0, 0)))
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        ContentLoader(
         New ControlWithLocation(New Alert(), New Point(0, 0)))
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        ContentLoader(
        New ControlWithLocation(New Checkout(), New Point(0, 0)))
    End Sub

End Class
