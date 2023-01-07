Imports System.Data.SqlClient
Public Class login
    Dim sqlconn As New SqlConnection("server=DESKTOP-GKVLA13 ;database=sales_management;integrated security =true")
    Dim sqlcom As New SqlCommand("", sqlconn)

    Sub Runcommand(sqlcommand As String, Optional message As String = "")
        Try
            If sqlconn.State = ConnectionState.Closed Then
                sqlconn.Open()

                sqlcom.CommandText = sqlcommand
                sqlcom.ExecuteNonQuery()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim r As SqlDataReader
        Try
            sqlconn.Open()
            Dim q As String
            q = "select * From [dbo].[Users] where user_name ='" & TextBox1.Text & "' "
            sqlcom = New SqlCommand(q, sqlconn)
            r = sqlcom.ExecuteReader
            Dim noUser As Boolean = True
            While r.Read
                noUser = False

                If (r.GetString("password") <> TextBox2.Text) Then
                        MessageBox.Show("كلمة السر خاطئة")
                        TextBox2.Focus()
                        Exit Sub
                    End If
                    MsgBox(r.GetString("licenses"))

                If (r.GetString("licenses") = "أدمن") Then
                    Me.Hide()
                    Form1.Show()
                ElseIf (r.GetString("licenses") = "مستخدم") Then
                    Me.Hide()
                    Form1.Button1.Visible = False
                    Form1.Button4.Visible = False
                    Form1.Button5.Visible = False
                    Form1.Button6.Visible = False
                    Form1.Show()
                End If
            End While

            If (noUser) Then
                MsgBox("المستخدم غير موجود")
                TextBox1.Clear()
                TextBox1.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            If sqlconn.State = ConnectionState.Open Then
                sqlconn.Close()
            End If
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
        TextBox2.PasswordChar = ""
    End Sub
    'عندما يغادر المؤشر الباسوورد 
    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        'اخفاء الباسوورد
        TextBox2.PasswordChar = "#"
    End Sub
    Private Sub TextBox2_GotFocus(sender As Object, e As EventArgs) Handles TextBox2.GotFocus
        If (TextBox2.Text <> "") Then
            PictureBox1.Visible = True
        End If
    End Sub

    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles TextBox2.LostFocus
        PictureBox1.Visible = False
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If (TextBox2.Text <> "") Then
            PictureBox1.Visible = True
        Else
            PictureBox1.Visible = False
        End If
    End Sub
End Class