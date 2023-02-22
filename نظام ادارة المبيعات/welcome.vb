Public Class welcome

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(4) ' increment value of progressbar 10 by 10
        Label4.Text = "%" & ProgressBar1.Value + 10
        If ProgressBar1.Value = 100 Then
            Timer1.Stop()
            login.Show()
            Me.Hide()
        End If
        Label1.Text = DateString
        Label2.Text = TimeOfDay
    End Sub

    Private Sub welcome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.White
        Timer1.Interval = 100
    End Sub
End Class