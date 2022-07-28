Public Class Management
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        materials_management.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        people.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        passwords.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        other_activities.ShowDialog()
    End Sub

End Class