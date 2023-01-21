Public Class MoneyBox
    Dim bond_no = {1, 1, 1, 1, 1}


    'Dim sqlconn As New SqlConnection("server=DESKTOP-GKVLA13 ;database=sales_management;integrated security =true")
    'Dim sqlcom As New SqlCommand("", sqlconn)

    '---------------------Runcommand-----------------------
    'Sub Runcommand(sqlcommand As String, Optional message As String = "")
    '    Try
    '        If sqlconn.State = ConnectionState.Closed Then
    '            sqlconn.Open()

    '            sqlcom.CommandText = sqlcommand
    '            sqlcom.ExecuteNonQuery()
    '            If message <> "" Then
    '                MsgBox(message)
    '            End If


    '        End If


    '    Catch ex As Exception
    '        MsgBox(ex.Message)

    '    Finally
    '        If sqlconn.State = ConnectionState.Closed = ConnectionState.Open Then
    '            sqlconn.Close()
    '        End If
    '    End Try

    'End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        TextBox2.Text = Date.Today
        If ComboBox1.Text = "قبض" Then
            ComboBox3.Visible = True
            Label16.Visible = True
            ComboBox2.Visible = True
            Label4.Visible = True
            Label18.Visible = True
            TextBox12.Visible = True
            Label14.Visible = True
            TextBox10.Visible = True
            Label15.Visible = True
            TextBox11.Visible = True
            Label19.Visible = True
            TextBox13.Visible = True
            Label6.Visible = True
            Label7.Visible = True
            Label8.Visible = True
            Label11.Visible = True
            Label12.Visible = True
            Label13.Visible = True
            TextBox4.Visible = True
            TextBox5.Visible = True
            TextBox8.Visible = True
            TextBox9.Visible = True
            ComboBox2.Items.Clear()

            ComboBox2.Items.Add("ذمم عملاء")
            ComboBox2.Items.Add("ايرادات عامة")
            ComboBox2.Items.Add("ذمم شركاء")
            TextBox6.Clear()
            TextBox7.Clear()
            TextBox1.Text = bond_no(0)
        ElseIf ComboBox1.Text = "صرف" Then
            ComboBox3.Visible = True
            Label16.Visible = True
            ComboBox2.Visible = True
            Label4.Visible = True
            Label18.Visible = False
            TextBox12.Visible = False
            Label14.Visible = False
            TextBox10.Visible = False
            Label15.Visible = True
            TextBox11.Visible = True
            Label19.Visible = False
            TextBox13.Visible = False
            Label6.Visible = False
            Label7.Visible = False
            Label8.Visible = False
            Label11.Visible = False
            Label12.Visible = False
            Label13.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox8.Visible = False
            TextBox9.Visible = False
            ComboBox2.Items.Clear()
            ' ComboBox2.SelectedIndex = -1
            ComboBox2.Items.Add("مصاريف عامة")
            ComboBox2.Items.Add("ذمم عملاء")
            ComboBox2.Items.Add("ذمم شركاء")
            ComboBox2.Items.Add("مصاريف استيراد")
            TextBox6.Clear()
            TextBox7.Clear()
            TextBox11.Clear()
            TextBox1.Text = bond_no(1)


        ElseIf ComboBox1.Text = "شراء دولار" Then
            ComboBox3.Visible = False
            Label16.Visible = False
            ComboBox2.Visible = False
            Label4.Visible = False
            Label18.Visible = False
            TextBox12.Visible = False
            Label14.Visible = False
            TextBox10.Visible = False
            Label15.Visible = False
            TextBox11.Visible = False
            Label19.Visible = False
            TextBox13.Visible = False
            Label6.Visible = False
            Label7.Visible = False
            Label8.Visible = False
            Label11.Visible = False
            Label12.Visible = False
            Label13.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox8.Visible = False
            TextBox9.Visible = False
            TextBox6.Clear()
            TextBox7.Clear()
            TextBox1.Text = bond_no(2)

        ElseIf ComboBox1.Text = "بيع دولار" Then
            ComboBox3.Visible = False
            Label16.Visible = False
            ComboBox2.Visible = False
            Label4.Visible = False
            Label18.Visible = False
            TextBox12.Visible = False
            Label14.Visible = False
            TextBox10.Visible = False
            Label15.Visible = False
            TextBox11.Visible = False
            Label19.Visible = False
            TextBox13.Visible = False
            Label6.Visible = False
            Label7.Visible = False
            Label8.Visible = False
            Label11.Visible = False
            Label12.Visible = False
            Label13.Visible = False
            TextBox4.Visible = False
            TextBox5.Visible = False
            TextBox8.Visible = False
            TextBox9.Visible = False
            TextBox6.Clear()
            TextBox7.Clear()
            TextBox1.Text = bond_no(3)
        ElseIf ComboBox1.Text = "سماح" Then
            ComboBox2.Visible = False
            Label4.Visible = False
            Label18.Visible = False
            TextBox12.Visible = False
            Label19.Visible = False
            TextBox13.Visible = False
            ComboBox3.Visible = True
            Label16.Visible = True
            TextBox6.Clear()
            TextBox7.Clear()
            TextBox1.Text = bond_no(4)
        End If

    End Sub



    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If ComboBox1.Text = "بيع دولار" Then
            TextBox7.Text = Val(TextBox6.Text) * Val(TextBox14.Text)
        ElseIf ComboBox1.Text = "قبض" Then
            TextBox8.Text = Val(TextBox4.Text) - Val(TextBox6.Text)
        End If
    End Sub


    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged
        If ComboBox1.Text = "قبض" And ComboBox2.Text = "ذمم عملاء" Then
            TextBox8.Text = Val(TextBox4.Text) - Val(TextBox11.Text)
        End If
    End Sub
    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        If ComboBox1.Text = "شراء دولار" Then
            TextBox6.Text = Val(TextBox7.Text) / Val(TextBox14.Text)
        ElseIf ComboBox1.Text = "صرف" Or ComboBox1.Text = "قبض" Then
            TextBox11.Text = Val(TextBox7.Text) / Val(TextBox14.Text)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If ComboBox1.Text = "قبض" Then


            'bond_no(0) += 1
            TextBox1.Text = 1



        ElseIf ComboBox1.Text = "صرف" Then
            bond_no(1) += 1
        ElseIf ComboBox1.Text = "شراء دولار" Then
            bond_no(2) += 1
        ElseIf ComboBox1.Text = "بيع دولار" Then
            bond_no(3) += 1
        ElseIf ComboBox1.Text = "سماح" Then
            bond_no(4) += 1
        End If
        TextBox1.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox2.Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

        If ComboBox2.Text = ("مصاريف عامة") Then
            Label16.Text = "تبويب المصروفات"
        ElseIf ComboBox2.Text = ("ذمم عملاء") Then
            Label16.Text = "اسم الزبون"
        ElseIf ComboBox2.Text = ("ذمم شركاء") Then
            Label16.Text = "اسم الشريك"
        ElseIf ComboBox2.Text = ("مصاريف استيراد") Then
            Label16.Text = "تبويب المصاريف"
        ElseIf ComboBox2.Text = "ايرادات عامة" Then
            Label16.Text = "تبويب الايرادات"
        End If

        'If ComboBox2.Text = "مصاريف عامة" Then
        '    ComboBox3.Items.Add(ComboBox3.Text)
        'End If

    End Sub

    Private Sub MoneyBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ComboBox2.DataSource = functions.GetCoumnNames("cu_id", "customers")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Runcommand("insert into money_box(now_dinar)values(" & TextBox3.Text & ")", "insert  mo_id ")
    End Sub
End Class
