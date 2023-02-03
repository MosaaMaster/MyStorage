Imports System.Data.SqlClient
Public Class people
    'ايجاد اسم السيرفر
    Dim ServerName As String = System.Net.Dns.GetHostName()

    Dim sqlconn As New SqlConnection("server= " & ServerName & "\SQLEXPRESS ;database=sales_management;integrated security =true")
    Dim sqlcom As New SqlCommand("", sqlconn)

    ' يقوم بخذ جميع بيانات الفورم ورسالها اله قاعده الينانات لخزن جميع المعلومات
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Guna2ComboBox1.Text = Trim("مجهز") Then

            functions.Runcommand("insert into supplier(su_id,name,debt_t,statee,address,notes,phone_num )values(" & Guna2TextBox1.Text & ",'" & Guna2TextBox2.Text & "'," & Guna2TextBox3.Text & ",'" & Guna2ComboBox2.Text & "','" & Guna2TextBox5.Text & "','" & Guna2TextBox7.Text & "','" & Guna2TextBox6.Text & "' )", "add elemant....")
            functions.ClearData(Me)
            ' TextBox1.Text = GetAutoNumber("supplier", "su_id")
        ElseIf Guna2ComboBox1.Text = Trim("مشتري جملة") Then


            functions.Runcommand("insert into customers(cu_id,name,debt,statee,address,notes,phone_num )values(" & Guna2TextBox1.Text & ",'" & Guna2TextBox2.Text & "'," & Guna2TextBox3.Text & ",'" & Guna2ComboBox2.Text & "','" & Guna2TextBox5.Text & "','" & Guna2TextBox7.Text & "','" & Guna2TextBox6.Text & "' )", "add elemant....")
            functions.ClearData(Me)
            ' TextBox1.Text = GetAutoNumber("customers", "cu_id")
        End If

    End Sub

    '------------------comboBox1_changed-------------------------

    'زر التعديل
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        'عرض الاسماء الكاملة وزر التحديث 
        Guna2ComboBox3.Enabled = True
        Guna2ComboBox3.Visible = True
        Button4.Visible = True
        Guna2ComboBox2.SelectedIndex = -1
        Guna2ComboBox3.SelectedIndex = -1



        If Guna2ComboBox1.Text = Trim("مجهز") Then

            Button1.Text = "حفظ المجهز"
            'سوفه يقوم بجلب اخر قيمه وزياده بمقدار واحد لينشاء ادي جديدمختلف عن السابق برقم واحد
            'اذا لم يضغط المستخدم على زر التعديل لا داعي لأسترجاع البيانات 
            'اي اسماءالمجهزين للكومبو بوكس الخاص بالتعديل
            'If (Guna2ComboBox3.Visible = True) Then
            Dim dt As DataTable = functions.GetTable("select name from [dbo].[supplier] ") 'انشاء متغير يحمل حميع الاسماء 
            Guna2ComboBox3.DisplayMember = "name"
            Guna2ComboBox3.DataSource = dt 'عرض جميع الاسماء في الكمبو بوكس
            'Else

            'End If
            Guna2ComboBox3.SelectedIndex = -1
            Guna2ComboBox2.SelectedIndex = -1

            functions.ClearData(Me)


        ElseIf Guna2ComboBox1.Text = Trim("مشتري جملة") Then
            Button1.Text = "حفظ الزبون"
            'اذا لم يضغط المستخدم على زر التعديل لا داعي لأسترجاع البيانات 
            'اي اسماءالمجهزين للكومبو بوكس الخاص بالتعديل

            Dim dt As DataTable = functions.GetTable("select name from [dbo].[customers] ")
                Guna2ComboBox3.DataSource = dt
                Guna2ComboBox3.DisplayMember = "name"

        ElseIf Guna2ComboBox1.Text = Trim("زبون توصيل") Then
            Button1.Text = "حفظ الزبون"
            'نفس عمل الكود اسابق ولاكن اذه اختار المستخدم مشتريات جمله 

            'اذا لم يضغط المستخدم على زر التعديل لا داعي لأسترجاع البيانات 
            'اي اسماءالمجهزين للكومبو بوكس الخاص بالتعديل
            If (Guna2ComboBox3.Visible = True) Then

                Guna2ComboBox3.DataSource = functions.GetCoumnNames("name", "delivery_customers")
                Guna2ComboBox3.DisplayMember = "name"
            End If
        End If

    End Sub
    'عندما يقوم المستخدم بتحديد نوع الشخص المضاف هل هو مجهز او مبيعات جمله 
    Private Sub Guna2ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Guna2ComboBox1.SelectedIndexChanged


        functions.Enabled_Text_true(Me)

        If Guna2ComboBox1.Text = Trim("مجهز") Then

            Button1.Text = "حفظ المجهز"
            Guna2TextBox1.Text = functions.GetAutoNumber("supplier", "su_id") 'سوفه يقوم بجلب اخر قيمه وزياده بمقدار واحد لينشاء ادي جديدمختلف عن السابق برقم واحد
            'اذا لم يضغط المستخدم على زر التعديل لا داعي لأسترجاع البيانات 
            'اي اسماءالمجهزين للكومبو بوكس الخاص بالتعديل
            If (Guna2ComboBox3.Visible = True) Then
                Dim dt As DataTable = functions.GetTable("select name from [dbo].[supplier] ") 'انشاء متغير يحمل حميع الاسماء 
                Guna2ComboBox3.DisplayMember = "name"
                Guna2ComboBox3.DataSource = dt 'عرض جميع الاسماء في الكمبو بوكس
                Guna2ComboBox3.SelectedIndex = -1
                Guna2ComboBox2.SelectedIndex = -1

                functions.ClearData(Me)
            End If



        ElseIf Guna2ComboBox1.Text = Trim("مشتري جملة") Then
                Button1.Text = "حفظ الزبون"
                'نفس عمل الكود اسابق ولاكن اذه اختار المستخدم مشتريات جمله 

                Guna2TextBox1.Text = functions.GetAutoNumber("customers", "cu_id")
            'اذا لم يضغط المستخدم على زر التعديل لا داعي لأسترجاع البيانات 
            'اي اسماءالمجهزين للكومبو بوكس الخاص بالتعديل
            If (Guna2ComboBox3.Visible = True) Then
                Dim dt As DataTable = functions.GetTable("select name from [dbo].[customers] ")
                Guna2ComboBox3.DataSource = dt
                Guna2ComboBox3.DisplayMember = "name"
                Guna2ComboBox3.SelectedIndex = -1
                Guna2ComboBox2.SelectedIndex = -1

                functions.ClearData(Me)
            End If

        ElseIf Guna2ComboBox1.Text = Trim("زبون توصيل") Then
                Button1.Text = "حفظ الزبون"
            'نفس عمل الكود اسابق ولاكن اذه اختار المستخدم زبون توصيل 

            Guna2TextBox1.Text = functions.GetAutoNumber("delivery_customers", "de_id")
            'اذا لم يضغط المستخدم على زر التعديل لا داعي لأسترجاع البيانات 
            'اي اسماءالمجهزين للكومبو بوكس الخاص بالتعديل
            If (Guna2ComboBox3.Visible = True) Then

                Guna2ComboBox3.DataSource = functions.GetCoumnNames("name", "delivery_customers")
                Guna2ComboBox3.DisplayMember = "name"
                Guna2ComboBox3.SelectedIndex = -1
                Guna2ComboBox2.SelectedIndex = -1

                functions.ClearData(Me)
            End If
        End If
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        functions.ClearData(Me) 'داله تقوم بحذف جميع البيانات دخل الفورم فقط 
    End Sub


    'عنده مايقوم المستخدم بتحديد
    'اسم من الكمبو بوكس ليقوم بالتعديل عله بيانات
    'الشخص يقوم بسترجاع جميع بينات الشخص ليستطيع التعديل عليها  
    Private Sub Guna2ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Guna2ComboBox3.SelectedIndexChanged
        MsgBox(1)

        If Guna2ComboBox1.Text = Trim("مجهز") Then
            Dim r As SqlDataReader
            Try
                sqlconn.Open()
                Dim q As String
                q = "select * from [dbo].[supplier] where name='" & Guna2ComboBox3.Text & "'"
                sqlcom = New SqlCommand(q, sqlconn)
                r = sqlcom.ExecuteReader
                While r.Read
                    Guna2TextBox1.Text = r.GetInt32("su_id")
                    Guna2TextBox2.Text = r.GetString("name")

                    Guna2TextBox3.Text = r.GetDecimal("debt_t")

                    Guna2ComboBox2.Text = r.GetString("statee")
                    Guna2TextBox5.Text = r.GetString("address")
                    Guna2TextBox6.Text = r.GetString("phone_num")
                    Guna2TextBox7.Text = r.GetString("notes")


                End While
                sqlconn.Close()

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        ElseIf Guna2ComboBox1.Text = Trim("مشتري جملة") Then

            Dim r As SqlDataReader
            Try
                sqlconn.Open()
                Dim q As String
                q = "select * from customers where name='" & Guna2ComboBox3.Text & "'"
                sqlcom = New SqlCommand(q, sqlconn)
                r = sqlcom.ExecuteReader
                While r.Read
                    Guna2TextBox1.Text = r.GetInt32("cu_id")
                    Guna2TextBox2.Text = r.GetString("name")
                    Guna2TextBox3.Text = r.GetDecimal("debt")
                    Guna2ComboBox2.Text = r.GetString("statee")
                    Guna2TextBox5.Text = r.GetString("address")
                    Guna2TextBox6.Text = r.GetString("phone_num")
                    Guna2TextBox7.Text = r.GetString("notes")


                End While
                sqlconn.Close()

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

        End If

    End Sub
    'يقوم بتحديث البيانات السابقه من خلال اختيار
    'الاسم من الاسماء السابقه  ثم يقوم بسترجاع جميع
    'البيانات ومن ثم نقوم بتعديل عله الابيانات وادخالها مر


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'عنده اختيار المجهز يقوم بسترجاع اسماء المجهزين ومن بعدهانقوم بالتعديل 
        If Guna2ComboBox1.Text = Trim("مجهز") Then

            functions.Runcommand("Update  supplier SET name = '" & Guna2TextBox2.Text & "',phone_num='" & Guna2TextBox6.Text & "',address='" & Guna2TextBox5.Text & "',debt_t='" & Guna2TextBox3.Text & "',statee='" & Guna2ComboBox2.Text & "',notes='" & Guna2TextBox7.Text & "' where su_id = '" & Guna2TextBox1.Text & " ' ", "   updata elemant in supplier....")

            'عنده اختيار "مشتري جمله" يقوم بسترجاع اسماء المجهزين ومن بعدهانقوم بالتعديل 
        ElseIf Guna2ComboBox1.Text = Trim("مشتري جملة") Then

            functions.Runcommand("Update  customers SET name = '" & Guna2TextBox2.Text & "',phone_num='" & Guna2TextBox6.Text & "',address='" & Guna2TextBox5.Text & "',debt='" & Guna2TextBox3.Text & "',statee='" & Guna2ComboBox2.Text & "',notes='" & Guna2TextBox7.Text & "' where cu_id = '" & Guna2TextBox1.Text & " ' ", "   updata elemant in coustomer....")

        End If

        ' بعد التحديث على بيانات الشخص نرجع نخفي ازرار التعديل
        Guna2ComboBox3.Enabled = False
        Guna2ComboBox3.Visible = False
        Button4.Visible = False
    End Sub

    Private Sub people_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim ServerName As String = System.Net.Dns.GetHostName()
        'MsgBox(ServerName)
        'اخفاء الامور الخاصة بتعديل البيانات عند فتح الفورمة
        Guna2ComboBox3.Enabled = False
        Guna2ComboBox3.Visible = False
        Button4.Visible = False
        Guna2TextBox3.Text = 0
        functions.Enabled_Text_fulse(Me)
        Button1.Text = ""
    End Sub


    'عند مغادرت حقل ادخال
    'الاسم يقوم بالبحث عن الاسم الموجود  داخل الحقل اذه كان ضمن الاسماء الموجوده
    'سابقا يقوم برفضه اما اذه كان غير موجود يقوم بستقبال الاسم الجديد  
    Private Sub TextBox2_Leave(sender As Object, e As EventArgs)
        Dim cmd As SqlCommand
        Dim rd As SqlDataReader
        'عنده مايقوم المستخدم بختيار "المجهز" يبحث
        'عن الاسم هل موجود او لا ضمن قاعده البيانات

        If Guna2ComboBox1.Text = "مجهز" Then
            Try
                sqlconn.Open()
                cmd = New SqlCommand("select name from [dbo].[supplier] where name='" & Guna2TextBox2.Text & "'")
                cmd.Connection = sqlconn
                rd = cmd.ExecuteReader
                If (rd.Read) Then
                    MsgBox("الاسم موجود سابقا يرجا ادخال اسم جديد")
                    Guna2TextBox2.Text = ""
                    Guna2TextBox2.Focus()
                    Guna2TextBox2.BackColor = Color.Red

                Else
                    Guna2TextBox2.BackColor = Color.Green
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
                cmd = New SqlCommand("select name from [dbo].[customers] where name='" & Guna2TextBox2.Text & "'")
                cmd.Connection = sqlconn
                rd = cmd.ExecuteReader
                If (rd.Read) Then
                    MsgBox("الاسم موجود سابقا يرجا ادخال اسم جديد")
                    Guna2TextBox2.Text = ""
                    Guna2TextBox2.Focus()
                    Guna2TextBox2.BackColor = Color.Red

                Else
                    Guna2TextBox2.BackColor = Color.Green
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            sqlconn.Close()

        End If

    End Sub

    Private Sub Guna2TextBox3_Leave(sender As Object, e As EventArgs) Handles Guna2TextBox3.Leave
        If (Guna2TextBox3.Text = "") Then
            Guna2TextBox3.Text = 0
        End If
    End Sub

    Private Sub Guna2ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles Guna2ComboBox1.SelectedIndexChanged

    End Sub
End Class