Public Class Reports

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        'اضافة عناصر لتقارير الزبائن 
        ListBox1.Items.Add("اضهار معلومات زبائن الجملة")
        ListBox1.Items.Add("اضهار معلومات زبائن التوصيل")
        ListBox1.Items.Add("اضهار معلومات المجهزين")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()
        'اضافة عناصر لتقارير المواد 
        ListBox1.Items.Add("اضهار كافة معلومات المواد")
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
    Public report As String = ""
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then

            If (ListBox1.SelectedItem = "اضهار معلومات زبائن الجملة") Then
                report = "اضهار معلومات زبائن الجملة"

            ElseIf (ListBox1.SelectedItem = "اضهار معلومات زبائن التوصيل") Then
                report = "اضهار معلومات زبائن التوصيل"
            ElseIf (ListBox1.SelectedItem = "اضهار معلومات المجهزين") Then
                report = "اضهار معلومات المجهزين"
            End If
            If (ListBox1.SelectedItem = "اضهار كافة معلومات المواد") Then
                report = "اضهار كافة معلومات المواد"
            End If
            ReportsResult.Show()
        End If
    End Sub

End Class