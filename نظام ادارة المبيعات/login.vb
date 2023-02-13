
Public Class login
    Private Sub Guna2TextBox1_Leave(sender As Object, e As EventArgs) Handles Guna2TextBox1.Leave
        Dim User As String = functions.getOneValue("user_name", "Users", "user_name", Guna2TextBox1.Text, "string")
        If (User = "") Then

            MsgBox("المستخدم غير موجود")
            Guna2TextBox1.Clear()
            Guna2TextBox1.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim User As String = functions.getOneValue("user_name", "Users", "user_name", Guna2TextBox1.Text, "string")

        Try

            Dim pasw As String = functions.getOneValue("password", "Users", "user_name", Guna2TextBox1.Text, "string")
            If (pasw <> Guna2TextBox2.Text) Then
                MessageBox.Show("كلمة السر خاطئة")
                Guna2TextBox2.Focus()
                Exit Sub
            End If
            Dim licenses As String = functions.getOneValue("licenses", "Users", "user_name", Guna2TextBox1.Text, "string")
            MsgBox("مرحباً :" & User,, "سجلت الدخول بصيغة " & licenses)

            If (licenses = "أدمن") Then
                Me.Hide()
                Form1.Show()
            ElseIf (licenses = "مستخدم") Then
                Me.Hide()
                Form1.Button1.Visible = False
                Form1.Button4.Visible = False
                Form1.Button5.Visible = False
                Form1.Button6.Visible = False
                Form1.Show()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        'If TextBox1.Text =
        '    If TextBox1.Text = "اسم المستخدم " And TextBox2.Text = "رمز " Then
        '    Me.Hide()
        '    'الوصول فقط للمبيعات 
        '    Sales.ShowDialog()
        '    retail.ShowDialog()
        'ElseIf TextBox1.Text = "" Then
        '    MsgBox("الرجاء ادخل الاسم")
        'ElseIf TextBox2.Text = "" Then
        '    MsgBox("الرجاء ادخل الكلمه السريه ")
        'Else
        '    MsgBox("الرجاء ادخل المعلومات الصحيحة ")
        '        TextBox1.Text = ""
        '        TextBox2.Text = ""
        '        TextBox1.Focus()
        '    End If

        'ElseIf textbox2.Text = "Administrative" Then
        '    If TextBox1.Text = "اسم الادمن " And TextBox2.Text = "رمز " Then
        '        Me.Hide()
        '        'الوصول لجميع الفورمات
        '        Form1.ShowDialog()
        '    ElseIf TextBox1.Text = "" Then
        '        MsgBox("الرجاء ادخل الاسم")
        '    ElseIf TextBox2.Text = "" Then
        '        MsgBox("الرجاء ادخل الكلمه السريه ")
        '    Else
        '        MsgBox("الرجاء ادخل المعلومات الصحيحة ")
        '        TextBox1.Text = ""
        '        TextBox2.Text = ""
        '        TextBox1.Focus()
        '    End If
        'End If

    End Sub

    'عند التأشير بالماوس
    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs) Handles PictureBox1.MouseHover
        'اضهار الباسوورد
        Guna2TextBox2.PasswordChar = ""
    End Sub
    'عندما يغادر المؤشر الباسوورد 
    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        'اخفاء الباسوورد
        Guna2TextBox2.PasswordChar = "#"
    End Sub
    Private Sub Guna2TextBox2_GotFocus(sender As Object, e As EventArgs) Handles Guna2TextBox2.GotFocus
        If (Guna2TextBox2.Text <> "") Then
            PictureBox1.Visible = True
        End If
    End Sub

    Private Sub Guna2TextBox2_LostFocus(sender As Object, e As EventArgs) Handles Guna2TextBox2.LostFocus
        PictureBox1.Visible = False
    End Sub

    Private Sub Guna2TextBox2_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox2.TextChanged
        If (Guna2TextBox2.Text <> "") Then
            PictureBox1.Visible = True
        Else
            PictureBox1.Visible = False
        End If
    End Sub
End Class