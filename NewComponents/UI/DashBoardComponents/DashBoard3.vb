Public Class DashBoard3
    Private Sub DashBoard3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CardDataLoader.LoadDailyCardData(DailyData1, DailyData2, DailyData3, DailyData4)
        CardDataLoader.LoadWeeklyCardData(WeeklyData1, WeeklyData2, WeeklyData3, WeeklyData4)
    End Sub
End Class
