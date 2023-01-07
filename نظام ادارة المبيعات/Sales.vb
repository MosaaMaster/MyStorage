Imports System.Data.SqlClient
Public Class Sales

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

    'استرجاع جدول
    'استرجاع سطر من جدول معين
    Function Get_Table(selectcommand As String) As DataTable
        Try
            Dim Table As New DataTable
            If sqlconn.State = ConnectionState.Closed Then
                sqlconn.Open()
                sqlcom.CommandText = selectcommand
                Table.Load(sqlcom.ExecuteReader)
                Return Table
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return New DataTable

        Finally
            If sqlconn.State = ConnectionState.Open Then
                sqlconn.Close()

            End If

        End Try

    End Function
    Function GetAutoNumber(Table_Name As String, ColName As String) As String
        Dim str As String = "select max(" & ColName & ") +1 from " & Table_Name
        Dim AutoNumber As String
        Dim tbl As New DataTable
        tbl = Get_Table(str)


        If tbl.Rows(0)(0) Is DBNull.Value Then
            AutoNumber = "1"
        Else
            AutoNumber = tbl.Rows(0)(0)

        End If

        Return AutoNumber

    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        TextBox1.Text = GetAutoNumber("sales", "list_num")
        Runcommand("insert into sales(list_num,sale_type,date,name,payment_type,money_type,notes) values('" & TextBox1.Text & "','" & "جملة" & "','" & TextBox2.Text & "','" & ComboBox2.Text & "','" & ComboBox1.Text & "', '" & "دولار" & "' , '" & TextBox5.Text & "')", "add item to database")
        'Dim get_table As New DataTable
        'get_table.Load(sqlcom.ExecuteReader)
    End Sub

    Private Sub Sales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Text = Date.Today
        Dim dt As DataTable = Get_Table("select name from [dbo].[customers] ")
        ComboBox2.DataSource = dt
        ComboBox2.DisplayMember = "name"


    End Sub

    Private Sub ComboBox2_Leave(sender As Object, e As EventArgs) Handles ComboBox2.Leave
        ' ComboBox2.Items.Add(ComboBox2.Text)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'DataGridView1.Columns()

        DataGridView1.DataSource = Get_Table("select * from matirials ")
        'Dim r As SqlDataReader
        'Try
        '    sqlconn.Open()
        '    Dim q As String
        '    q = "select model from materials where model='" & DataGridView1.Rows(1).Cells.ToString & "'"
        '    sqlcom = New SqlCommand(q, sqlconn)
        '    r = sqlcom.ExecuteReader
        '    While r.Read

        '        TextBox6.Text = r.GetDecimal("quanteity")

        '    End While
        '    sqlconn.Close()

        'Catch ex As Exception
        '    MsgBox(ex.Message)

        'End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim a As OpenFileDialog
        'a.Filter("jpg |.jfif")

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        'Dim r As SqlDataReader
        'Dim name As String
        'name = "select debt from customers where name = '" & ComboBox2.Text & "'"

        'TextBox4.Text = r.GetDecimal("debt")

        Dim r As SqlDataReader
        Try
            sqlconn.Open()
            Dim q As String
            q = "select debt from customers where name='" & ComboBox2.Text & "'"
            sqlcom = New SqlCommand(q, sqlconn)
            r = sqlcom.ExecuteReader
            While r.Read

                TextBox4.Text = r.GetDecimal("debt")

            End While
            sqlconn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
End Class