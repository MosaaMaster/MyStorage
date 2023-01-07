Imports System.Data.SqlClient
Public Class Reports


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
            If sqlconn.State = ConnectionState.Closed = ConnectionState.Open Then
                sqlconn.Close()
            End If
        End Try

    End Sub


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