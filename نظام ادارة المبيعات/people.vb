Imports System.Data.SqlClient
Public Class people
    'ايجاد اسم السيرفر
    Dim ServerName As String = System.Net.Dns.GetHostName()
    Dim sqlconn As New SqlConnection("server= " & ServerName & " ;database=sales_management;integrated security =true")
    Dim sqlcom As New SqlCommand("", sqlconn)

    ' يقوم بخذ جميع بيانات الفورم ورسالها اله قاعده الينانات لخزن جميع المعلومات
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox1.Text = Trim("مجهز") Then

            functions.Runcommand("insert into supplier(su_id,name,debt_t,statee,address,notes,phone_num )values(" & TextBox1.Text & ",'" & TextBox2.Text & "'," & TextBox3.Text & ",'" & ComboBox2.Text & "','" & TextBox5.Text & "','" & TextBox7.Text & "','" & TextBox6.Text & "' )", "add elemant....")
            functions.ClearData(Me)
            ' TextBox1.Text = GetAutoNumber("supplier", "su_id")
        ElseIf ComboBox1.Text = Trim("مشتري جملة") Then


            functions.Runcommand("insert into customers(cu_id,name,debt,statee,address,notes,phone_num )values(" & TextBox1.Text & ",'" & TextBox2.Text & "'," & TextBox3.Text & ",'" & ComboBox2.Text & "','" & TextBox5.Text & "','" & TextBox7.Text & "','" & TextBox6.Text & "' )", "add elemant....")
            functions.ClearData(Me)
            ' TextBox1.Text = GetAutoNumber("customers", "cu_id")
        End If

    End Sub

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

        functions.Enabled_Text_true(Me)

        If ComboBox1.Text = Trim("مجهز") Then

            Button1.Text = "حفظ المجهز"
            TextBox1.Text = functions.GetAutoNumber("supplier", "su_id") 'سوفه يقوم بجلب اخر قيمه وزياده بمقدار واحد لينشاء ادي جديدمختلف عن السابق برقم واحد
            'اذا لم يضغط المستخدم على زر التعديل لا داعي لأسترجاع البيانات 
            'اي اسماءالمجهزين للكومبو بوكس الخاص بالتعديل
            If (ComboBox3.Visible = True) Then
                Dim dt As DataTable = functions.GetTable("select name from [dbo].[supplier] ") 'انشاء متغير يحمل حميع الاسماء 
                ComboBox3.DataSource = dt 'عرض جميع الاسماء في الكمبو بوكس
                ComboBox3.DisplayMember = "name"
            Else

            End If


        ElseIf ComboBox1.Text = Trim("مشتري جملة") Then
            Button1.Text = "حفظ الزبون"
            'نفس عمل الكود اسابق ولاكن اذه اختار المستخدم مشتريات جمله 

            TextBox1.Text = functions.GetAutoNumber("customers", "cu_id")
            'اذا لم يضغط المستخدم على زر التعديل لا داعي لأسترجاع البيانات 
            'اي اسماءالمجهزين للكومبو بوكس الخاص بالتعديل
            If (ComboBox3.Visible = True) Then
                Dim dt As DataTable = functions.GetTable("select name from [dbo].[customers] ")
                ComboBox3.DataSource = dt
                ComboBox3.DisplayMember = "name"
            End If
        ElseIf ComboBox1.Text = Trim("زبون توصيل") Then
            Button1.Text = "حفظ الزبون"
            'نفس عمل الكود اسابق ولاكن اذه اختار المستخدم مشتريات جمله 

            TextBox1.Text = functions.GetAutoNumber("delivery_customers", "de_id")
            'اذا لم يضغط المستخدم على زر التعديل لا داعي لأسترجاع البيانات 
            'اي اسماءالمجهزين للكومبو بوكس الخاص بالتعديل
            If (ComboBox3.Visible = True) Then

                ComboBox3.DataSource = functions.GetCoumnNames("name", "delivery_customers")
                ComboBox3.DisplayMember = "name"
            End If
        End If
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        functions.ClearData(Me) 'داله تقوم بحذف جميع البيانات دخل الفورم فقط 
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

            functions.Runcommand("Update  supplier SET name = '" & TextBox2.Text & "',phone_num='" & TextBox6.Text & "',address='" & TextBox5.Text & "',debt_t='" & TextBox3.Text & "',statee='" & ComboBox2.Text & "',notes='" & TextBox7.Text & "' where su_id = '" & TextBox1.Text & " ' ", "   updata elemant in supplier....")

            'عنده اختيار "مشتري جمله" يقوم بسترجاع اسماء المجهزين ومن بعدهانقوم بالتعديل 
        ElseIf ComboBox1.Text = Trim("مشتري جملة") Then

            functions.Runcommand("Update  customers SET name = '" & TextBox2.Text & "',phone_num='" & TextBox6.Text & "',address='" & TextBox5.Text & "',debt='" & TextBox3.Text & "',statee='" & ComboBox2.Text & "',notes='" & TextBox7.Text & "' where cu_id = '" & TextBox1.Text & " ' ", "   updata elemant in coustomer....")

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
        functions.Enabled_Text_fulse(Me)
        Button1.Text = ""
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