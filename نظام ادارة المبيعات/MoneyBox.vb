Public Class MoneyBox
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "قبض" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("ذمم عملاء")
            ComboBox2.Items.Add("توصيل")
            ComboBox2.Items.Add("ايردات عامة")
            ComboBox2.Items.Add("ذمم شركاء")
        ElseIf ComboBox1.Text = "صرف" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("مصاريف عامة")
            ComboBox2.Items.Add("ذمم مجهزين")
            ComboBox2.Items.Add("ذمم شركاء")
            ComboBox2.Items.Add("مصاريف استيراد")

        End If

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If (ComboBox2.Text = "ذمم عملاء") Then
            Label5.Text = "الزبون"
        ElseIf (ComboBox2.Text = "توصيل") Then
            Label5.Text = "شركة التوصيل"
            TextBox5.Visible = True
            Label13.Visible = True
        ElseIf (combobox2.Text = "مصاريف استيراد") Then
            Label5.Text = "تبويب المصاريف"
            TextBox5.Visible = True
            Label13.Text = "رقم القائمة"
            Label13.Visible = True

        End If

    End Sub
End Class
