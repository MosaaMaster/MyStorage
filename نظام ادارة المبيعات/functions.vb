Imports System.Data.SqlClient
Module functions
    Dim sqlconn As New SqlConnection("server=DESKTOP-GKVLA13 ;database=sales_management;integrated security =true")
    Dim sqlcom As New SqlCommand("", sqlconn)

    '---------------------Runcommand-----------------------
    'داله تقوم بدخال البيانات او ارجاع البيانات او تحديدث البيانات من خلال اعطائها جمله س كو ال
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

    '-----------------ClearData-------------------------------

    'داله تقوم بحذف جميع بيانات الفورم من الفورم فقط ليقوم المستخدم بدخال بينات جديد
    Sub ClearData(fo As Form)
        For Each c As Control In fo.Controls
            If TypeOf c Is TextBox Then
                c.Text = ""

            End If
            If TypeOf c Is ComboBox Then
                c.Text = ""


            End If
        Next
    End Sub
    'غلق الادخال لكل الفورمة
    Sub Enabled_Text_fulse(f As Form)
        For Each c As Control In f.Controls
            If TypeOf c Is TextBox Then
                c.Enabled = False

            End If

        Next
    End Sub
    'تفعيل الأدخال لكل الفورمة
    Sub Enabled_Text_true(f As Form)

        For Each c As Control In f.Controls

            If TypeOf c Is TextBox Then

                c.Enabled = True

            End If

        Next
    End Sub

    '------------------------Get_Table-----------------------------------------
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
    'داله تقوم بجلب اخر ادي الى الشخص مع زيادتها بمقدار واحد لانشاء ايدي جديد 
    Function GetAutoNumber(Table_Name As String, ColName As String) As String
        Dim str As String = "select max(" & ColName & ") +1 from " & Table_Name

        Dim AutoNumber As String
        Dim tbl As New DataTable
        tbl = Get_Table(str)
        ' AutoNumber = tbl.Rows(0)(0)
        If tbl.Rows(0)(0) Is DBNull.Value Then
            AutoNumber = "1"
        Else
            AutoNumber = tbl.Rows(0)(0)

        End If
        Return AutoNumber

    End Function
    'sql data reader نجيب سطر للرقم ونزيدة بواحد عن طريق الدالة
    Function GetAutoNumber1(Table_Name As String, ColName As String) As Integer

        Dim r As SqlDataReader
        Dim num As Integer
        Try
            sqlconn.Open()
            Dim q As String
            q = "select max(" & ColName & ") as n from " & Table_Name
            sqlcom = New SqlCommand(q, sqlconn)
            r = sqlcom.ExecuteReader

            While (r.Read)
                If (r.IsDBNull(0) = True) Then
                    num = 0
                Else
                    num = r.GetInt32("n")
                End If

            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If sqlconn.State = ConnectionState.Open Then
                sqlconn.Close()
            End If

        End Try

        Return num + 1
    End Function

    '---------------------------GetTable---------------------
    'داله تقوم بجلب اي جدول من قاعده
    'البيانات من خلال تحديد
    'اسم الجدول فقط سوفه ترجع جميع البيانات 
    'الملخزونه في ذالك الجدول
    'select *  from Name_Table;
    Function GetTable(selectcommand As String) As DataTable
        Try
            Dim tb As New DataTable()
            If sqlconn.State = ConnectionState.Closed Then
                sqlconn.Open()
                sqlcom.CommandText = selectcommand
                tb.Load(sqlcom.ExecuteReader())
                Return tb

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

    'دالة استرجاع اسماء عامود معين
    Function GetCoumnNames(col As String, table As String) As DataTable
        Dim dt As DataTable = functions.GetTable("select " & col & " from [dbo].[" & table & "] ")
        Return dt
    End Function

End Module
