Public Class other_activities
    Private Sub ComboBox2_Leave(sender As Object, e As EventArgs) Handles ComboBox2.Leave
        ComboBox2.Items.Add(ComboBox2.Text)
    End Sub

End Class