Public Class passwords

    Private Sub passwords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Visible = False
        Guna2ComboBox1.Items.Add("أدمن")
        Guna2ComboBox1.Items.Add("مستخدم")
        Guna2TextBox2.MaxLength = 8
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (Guna2TextBox1.Text = "") Then
            MsgBox("الرجاء ادخل الاسم")
            Exit Sub
        End If
        If (Guna2TextBox2.Text = "") Then
            MsgBox("الرجاء ادخل كلمة السر ")
            Exit Sub
        End If
        If (Guna2ComboBox1.Text = "") Then
            MsgBox("الرجاء اختيار نوع المستخدم")
            Exit Sub
        End If
        functions.Runcommand("insert into Users(password,user_name,licenses)values('" & Guna2TextBox2.Text & "','" & Guna2TextBox1.Text & "','" & Guna2ComboBox1.Text & "')", "تمت العمليه بنجاح")
        Guna2TextBox1.Clear()
        Guna2TextBox2.Clear()
        Guna2ComboBox1.Text = ""
    End Sub


    Private Sub TextBox1_Leave(sender As Object, e As EventArgs)

        'عنده مايقوم المستخدم بختيار "المجهز" يبحث
        'عن الاسم هل موجود او لا ضمن قاعده البيانات
        Try

            Dim user As String = functions.getOneValue("user_name", "Users", "user_name", Guna2TextBox1.Text, "string")

            If (user <> "") Then
                MessageBox.Show("الاسم موجود سابقا يرجا ادخال اسم جديد", "خطأ الاسم", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Guna2TextBox1.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub TextBox2_GotFocus(sender As Object, e As EventArgs)
        If (Guna2TextBox2.Text <> "") Then
            PictureBox1.Visible = True
        End If
    End Sub

    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs)
        PictureBox1.Visible = False
    End Sub


    'عند التأشير بالماوس
    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs) Handles PictureBox1.MouseHover
        'اضهار الباسوورد
        Guna2TextBox2.PasswordChar = ""
    End Sub
    'عندما يغادر المؤشر الباسوورد 
    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        'اخفاء الباسوورد
        Guna2TextBox2.PasswordChar = "*"
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox1.TextChanged
        If (Guna2TextBox2.Text <> "") Then
            PictureBox1.Visible = True
        Else
            PictureBox1.Visible = False
        End If
    End Sub


End Class