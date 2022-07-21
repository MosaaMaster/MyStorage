Public Class Reports
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        'اضافة عناصر لتقارير الزبائن 
        ListBox1.Items.Add("")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()
        'اضافة عناصر لتقارير المواد 
        ListBox1.Items.Add("")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ListBox1.Items.Clear()
        'اضافة عناصر لتقارير الصندوق 
        ListBox1.Items.Add("")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ListBox1.Items.Clear()
        'اضافة عناصر لتقارير الأرباح 
        ListBox1.Items.Add("")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
    End Sub
End Class