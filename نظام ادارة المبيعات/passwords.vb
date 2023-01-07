Imports System.Data.SqlClient
Public Class passwords
    Dim sqlconn As New SqlConnection("server=DESKTOP-GKVLA13 ;database=sales_management;integrated security =true")
    Dim sqlcom As New SqlCommand("", sqlconn)

    Sub Runcommand(sqlcommand As String, Optional message As String = "")
        Try
            If sqlconn.State = ConnectionState.Closed Then
                sqlconn.Open()
                MsgBox("1")
                sqlcom.CommandText = sqlcommand
                MsgBox("2")
                sqlcom.ExecuteNonQuery()
                MsgBox("3")
                If message <> "" Then
                    MsgBox(message)
                End If


            End If


        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            If sqlconn.State = ConnectionState.Open Then
                sqlconn.Close()
            End If
        End Try

    End Sub
    Private Sub passwords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Visible = False
        ComboBox1.Items.Add("أدمن")
        ComboBox1.Items.Add("مستخدم")
        TextBox2.MaxLength = 8
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox1.Text = "") Then
            MsgBox("الرجاء ادخل الاسم")
            Exit Sub
        End If
        If (TextBox2.Text = "") Then
            MsgBox("الرجاء ادخل كلمة السر ")
            Exit Sub
        End If
        If (ComboBox1.Text = "") Then
            MsgBox("الرجاء اختيار نوع المستخدم")
            Exit Sub
        End If
        Runcommand("insert into Users(password,user_name,licenses)values('" & TextBox2.Text & "','" & TextBox1.Text & "','" & ComboBox1.Text & "')", "تمت العمليه بنجاح")
        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox1.Text = ""
    End Sub


    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        Dim cmd As SqlCommand
        Dim rd As SqlDataReader
        'عنده مايقوم المستخدم بختيار "المجهز" يبحث
        'عن الاسم هل موجود او لا ضمن قاعده البيانات
        Try
            sqlconn.Open()
            cmd = New SqlCommand("select user_name from [dbo].[Users] where user_name ='" & TextBox1.Text & "'")
            cmd.Connection = sqlconn
            rd = cmd.ExecuteReader
            If (rd.Read) Then
                MessageBox.Show("الاسم موجود سابقا يرجا ادخال اسم جديد", "خطأ الاسم", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox1.Focus()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If sqlconn.State = ConnectionState.Open Then
                sqlconn.Close()
            End If
        End Try

    End Sub

    Private Sub TextBox2_GotFocus(sender As Object, e As EventArgs) Handles TextBox2.GotFocus
        If (TextBox2.Text <> "") Then
            PictureBox1.Visible = True
        End If
    End Sub

    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles TextBox2.LostFocus
        PictureBox1.Visible = False
    End Sub


    'عند التأشير بالماوس
    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs) Handles PictureBox1.MouseHover
        'اضهار الباسوورد
        TextBox2.PasswordChar = ""
    End Sub
    'عندما يغادر المؤشر الباسوورد 
    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        'اخفاء الباسوورد
        TextBox2.PasswordChar = "*"
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If (TextBox2.Text <> "") Then
            PictureBox1.Visible = True
        Else
            PictureBox1.Visible = False
        End If
    End Sub
End Class