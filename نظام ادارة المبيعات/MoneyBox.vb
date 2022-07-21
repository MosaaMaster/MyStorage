Public Class MoneyBox
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "قبض" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("ذمم عملاء")
            ComboBox2.Items.Add("ايردات عامة")
            ComboBox2.Items.Add("ذمم شركاء")
        End If
    End Sub

End Class