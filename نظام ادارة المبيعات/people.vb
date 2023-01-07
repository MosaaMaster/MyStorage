Imports System.Data.SqlClient
Public Class people
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
    Sub ClearData()
        For Each c As Control In Panel1.Controls
            If TypeOf c Is TextBox Then
                c.Text = ""

            End If
            If TypeOf c Is ComboBox Then
                c.Text = ""


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
    ' يقوم بخذ جميع بيانات الفورم ورسالها اله قاعده الينانات لخزن جميع المعلومات
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox1.Text = Trim("مجهز") Then

            Runcommand("insert into supplier(su_id,name,debt_t,statee,address,notes,phone_num )values(" & TextBox1.Text & ",'" & TextBox2.Text & "'," & TextBox3.Text & ",'" & ComboBox2.Text & "','" & TextBox5.Text & "','" & TextBox7.Text & "','" & TextBox6.Text & "' )", "add elemant....")
            ClearData()
            ' TextBox1.Text = GetAutoNumber("supplier", "su_id")
        ElseIf ComboBox1.Text = Trim("مشتري جملة") Then


            Runcommand("insert into customers(cu_id,name,debt,statee,address,notes,phone_num )values(" & TextBox1.Text & ",'" & TextBox2.Text & "'," & TextBox3.Text & ",'" & ComboBox2.Text & "','" & TextBox5.Text & "','" & TextBox7.Text & "','" & TextBox6.Text & "' )", "add elemant....")
            ClearData()
            ' TextBox1.Text = GetAutoNumber("customers", "cu_id")
        End If

    End Sub
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
    '------------------comboBox1_changed-------------------------

    'زر التعديل
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'عرض الاسماء الكاملة وزر التحديث 
        ComboBox3.Enabled = True
        ComboBox3.Visible = True
        Button4.Visible = True

    End Sub
    'عندما يقوم المستخدم بتحديد نوع الشخص المضاف هل هو مجهز او مبيعات جمله 
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Enabled_Text_true()
        If ComboBox1.Text = Trim("مجهز") Then

            TextBox1.Text = GetAutoNumber("supplier", "su_id") 'سوفه يقوم بجلب اخر قيمه وزياده بمقدار واحد لينشاء ادي جديدمختلف عن السابق برقم واحد
            'اذا لم يضغط المستخدم على زر التعديل لا داعي لأسترجاع البيانات 
            'اي اسماءالمجهزين للكومبو بوكس الخاص بالتعديل
            If (ComboBox3.Visible = True) Then
                Dim dt As DataTable = GetTable("select name from [dbo].[supplier] ") 'انشاء متغير يحمل حميع الاسماء 
                ComboBox3.DataSource = dt 'عرض جميع الاسماء في الكمبو بوكس
                ComboBox3.DisplayMember = "name"
            Else

            End If

        ElseIf ComboBox1.Text = Trim("مشتري جملة") Then
            'نفس عمل الكود اسابق ولاكن اذه اختار المستخدم مشتريات جمله 

            TextBox1.Text = GetAutoNumber("customers", "cu_id")
            'اذا لم يضغط المستخدم على زر التعديل لا داعي لأسترجاع البيانات 
            'اي اسماءالمجهزين للكومبو بوكس الخاص بالتعديل
            If (ComboBox3.Visible = True) Then
                Dim dt As DataTable = GetTable("select name from [dbo].[customers] ")
                ComboBox3.DataSource = dt
                ComboBox3.DisplayMember = "name"
            Else

            End If
        End If
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ClearData() 'داله تقوم بحذف جميع البيانات دخل الفورم فقط 
    End Sub


    'عنده مايقوم المستخدم بتحديد
    'اسم من الكمبو بوكس ليقوم بالتعديل عله بيانات
    'الشخص يقوم بسترجاع جميع بينات الشخص ليستطيع التعديل عليها  
    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox1.Text = Trim("مجهز") Then
            Dim r As SqlDataReader
            Try
                sqlconn.Open()
                Dim q As String
                q = "select * from [dbo].[supplier] where name='" & ComboBox3.Text & "'"
                sqlcom = New SqlCommand(q, sqlconn)
                r = sqlcom.ExecuteReader
                While r.Read
                    TextBox1.Text = r.GetInt32("su_id")
                    TextBox2.Text = r.GetString("name")

                    TextBox3.Text = r.GetDecimal("debt_t")

                    ComboBox2.Text = r.GetString("statee")
                    TextBox5.Text = r.GetString("address")
                    TextBox6.Text = r.GetString("phone_num")
                    TextBox7.Text = r.GetString("notes")


                End While
                sqlconn.Close()

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        ElseIf ComboBox1.Text = Trim("مشتري جملة") Then

            Dim r As SqlDataReader
            Try
                sqlconn.Open()
                Dim q As String
                q = "select * from customers where name='" & ComboBox3.Text & "'"
                sqlcom = New SqlCommand(q, sqlconn)
                r = sqlcom.ExecuteReader
                While r.Read
                    TextBox1.Text = r.GetInt32("cu_id")
                    TextBox2.Text = r.GetString("name")
                    TextBox3.Text = r.GetDecimal("debt")
                    ComboBox2.Text = r.GetString("statee")
                    TextBox5.Text = r.GetString("address")
                    TextBox6.Text = r.GetString("phone_num")
                    TextBox7.Text = r.GetString("notes")


                End While
                sqlconn.Close()

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try



        End If





    End Sub
    'يقوم بتحديث البيانات السابقه من خلال اختيار
    'الاسم من الاسماء السابقه  ثم يقوم بسترجاع جميع
    'البيانات ومن ثم نقوم بتعديل عله الابيانات وادخالها مره ثانيه
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'عنده اختيار المجهز يقوم بسترجاع اسماء المجهزين ومن بعدهانقوم بالتعديل 
        If ComboBox1.Text = Trim("مجهز") Then

            Runcommand("Update  supplier SET name = '" & TextBox2.Text & "',phone_num='" & TextBox6.Text & "',address='" & TextBox5.Text & "',debt_t='" & TextBox3.Text & "',statee='" & ComboBox2.Text & "',notes='" & TextBox7.Text & "' where su_id = '" & TextBox1.Text & " ' ", "   updata elemant in supplier....")

            'عنده اختيار "مشتري جمله" يقوم بسترجاع اسماء المجهزين ومن بعدهانقوم بالتعديل 
        ElseIf ComboBox1.Text = Trim("مشتري جملة") Then

            Runcommand("Update  customers SET name = '" & TextBox2.Text & "',phone_num='" & TextBox6.Text & "',address='" & TextBox5.Text & "',debt='" & TextBox3.Text & "',statee='" & ComboBox2.Text & "',notes='" & TextBox7.Text & "' where cu_id = '" & TextBox1.Text & " ' ", "   updata elemant in coustomer....")

        End If

        ' بعد التحديث على بيانات الشخص نرجع نخفي ازرار التعديل
        ComboBox3.Enabled = False
        ComboBox3.Visible = False
        Button4.Visible = False
    End Sub

    Private Sub people_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'اخفاء الامور الخاصة بتعديل البيانات عند فتح الفورمة
        ComboBox3.Enabled = False
        ComboBox3.Visible = False
        Button4.Visible = False
        TextBox3.Text = 0
        Enabled_Text_fulse()
    End Sub
    Sub Enabled_Text_fulse()
        For Each c As Control In Panel1.Controls
            If TypeOf c Is TextBox Then
                c.Enabled = False

            End If

        Next
    End Sub
    Sub Enabled_Text_true()
        For Each c As Control In Panel1.Controls
            If TypeOf c Is TextBox Then
                c.Enabled = True

            End If

        Next
    End Sub

    'عند مغادرت حقل ادخال
    'الاسم يقوم بالبحث عن الاسم الموجود  داخل الحقل اذه كان ضمن الاسماء الموجوده
    'سابقا يقوم برفضه اما اذه كان غير موجود يقوم بستقبال الاسم الجديد  
    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        Dim cmd As SqlCommand
        Dim rd As SqlDataReader
        'عنده مايقوم المستخدم بختيار "المجهز" يبحث
        'عن الاسم هل موجود او لا ضمن قاعده البيانات

        If ComboBox1.Text = "مجهز" Then
            Try
                sqlconn.Open()
                cmd = New SqlCommand("select name from [dbo].[supplier] where name='" & TextBox2.Text & "'")
                cmd.Connection = sqlconn
                rd = cmd.ExecuteReader
                If (rd.Read) Then
                    MsgBox("الاسم موجود سابقا يرجا ادخال اسم جديد")
                    TextBox2.Text = ""
                    TextBox2.Focus()
                    TextBox2.BackColor = Color.Red

                Else
                    TextBox2.BackColor = Color.Green
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            sqlconn.Close()

        Else
            'عنده مايقوم المستخدم بختيار "مشتري جمله"  يبحث
            ' عن الاسم هل موجود او لا ضمن قاعده البيانات
            'اذه كان الاسم  موجود سوفه يقوم برفض الاسم لا يجوز تكرار اسماء في قاعده البيانات 
            Try
                sqlconn.Open()
                cmd = New SqlCommand("select name from [dbo].[customers] where name='" & TextBox2.Text & "'")
                cmd.Connection = sqlconn
                rd = cmd.ExecuteReader
                If (rd.Read) Then
                    MsgBox("الاسم موجود سابقا يرجا ادخال اسم جديد")
                    TextBox2.Text = ""
                    TextBox2.Focus()
                    TextBox2.BackColor = Color.Red

                Else
                    TextBox2.BackColor = Color.Green
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            sqlconn.Close()



        End If






    End Sub

    Private Sub TextBox3_Leave(sender As Object, e As EventArgs) Handles TextBox3.Leave
        If (TextBox3.Text = "") Then
            TextBox3.Text = 0
        End If
    End Sub
End Class

