Imports System.IO

Public Class retail
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        functions.Runcommand("insert into sales(list_num,sale_type,name,date,payment_type,money_type,bill_cost,discount,note )values(" & Guna2TextBox30.Text & ",'" & "نقدي" & "','" & Guna2ComboBox11.Text & "','" & Guna2TextBox29.Text & "','" & Guna2ComboBox12.Text & "','" & Guna2ComboBox10.Text & "','" & Guna2TextBox26.Text & "'," & Guna2TextBox25.Text & ",'" & Guna2TextBox27.Text & "')", "add item")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        functions.Runcommand("insert into sales(list_num,sale_type,name,date,payment_type,money_type,bill_cost,discount,note )values(" & Guna2TextBox30.Text & ",'" & "توصيل" & "','" & Guna2ComboBox11.Text & "','" & Guna2TextBox29.Text & "','" & Guna2ComboBox12.Text & "','" & Guna2ComboBox10.Text & "','" & Guna2TextBox26.Text & "'," & Guna2TextBox25.Text & ",'" & Guna2TextBox27.Text & "')", "add item")
        functions.Runcommand("insert into delivery(delivery_num,company_name,book_num)values(" & Guna2TextBox22.Text & ",'" & Guna2ComboBox9.Text & "'," & Guna2TextBox21.Text & ")", "add item")
    End Sub

    Private Sub Guna2ComboBox11_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Guna2ComboBox11.SelectedIndexChanged
        ' functions.GetCoumnNames()

        'Dim r As SqlDataReader
        'Try
        '    sqlconn.Open()
        '    Dim q As String
        '    q = "select * from [dbo].[customers] where name='" & ComboBox11.Text & "'"
        '    sqlcom = New SqlCommand(q, sqlconn)
        '    r = sqlcom.ExecuteReader
        '    While r.Read
        'TextBox28.Text = r.GetInt32("cu_id")
        ' TextBox2.Text = r.GetString("name")
        Guna2TextBox28.Text = functions.getOneValue("cu_id", "customers", "name", Guna2ComboBox11.Text, "int")
        ' TextBox3.Text = r.GetDecimal("debt_t")

        ' ComboBox2.Text = r.GetString("statee")
        'extBox23.Text = r.GetString("address")
        Guna2TextBox23.Text = functions.getOneValue("address", "customers", "name", Guna2ComboBox11.Text, "string")

        ' TextBox24.Text = r.GetString("phone_num")
        Guna2TextBox24.Text = functions.getOneValue("phone_num", "customers", "name", Guna2ComboBox11.Text, "string")

        ' TextBox7.Text = r.GetString("notes")


        '    End While
        '    sqlconn.Close()

        'Catch ex As Exception
        '    MsgBox(ex.Message)

        'End Try


    End Sub
    'Private Sub tabPage2_click(ByVal sender As Object, ByVal e As EventArgs) Handles TabPage2.

    '    MessageBox.Show("Tabpage2 is Clicked")

    'End Sub



    Private Sub tabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab Is TabPage2 Then
            'MessageBox.Show("Tabpage2 is selected")
            Guna2ComboBox11.DataSource = functions.GetCoumnNames("name", "customers")
            Guna2ComboBox11.DisplayMember = "name"
            Guna2TextBox30.Text = functions.GetAutoNumber1("Sales", "list_num")

            Guna2ComboBox11.Text = ""
            Guna2TextBox23.Text = ""
            Guna2TextBox24.Text = ""
            Guna2TextBox28.Text = ""
            ''''''
            '''
        ElseIf TabControl1.SelectedTab Is TabPage1 Then
            Guna2TextBox20.Text = functions.GetAutoNumber1("Sales", "list_num")
        End If
    End Sub

    Dim total_sum As Double = 0
    Dim mg As String = ""
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        'التأكد من الضغط على المكان الصحيح
        If (e.RowIndex > -1) Then
            ' Make sure the column index is the one you want to sum
            If e.ColumnIndex = Column2.Index Then

                ' MsgBox(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString())
                'تحميل الصورة حسب موقعها مع ملاحضة لا يمكن تحميل الصور المرقمة عربي
                mg = functions.getOneValue("image", "materials", "model", DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString(), "string")
                'MsgBox(mg)
                If File.Exists(mg) Then
                    DataGridView1.Rows(e.RowIndex).Cells(4).Value = Image.FromFile(mg)
                End If
                'TextBox6.Text = functions.getOneValue("quantity", "materials", "model", DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString(), "int")
                ' Column6.Image = Image.FromFile("C: \Users\lenovo\Pictures\Saved Pictures\emoji.png")
            End If

            If e.ColumnIndex = Column4.Index Then
                ' Get the value of the two columns you want to sum

                'MsgBox(e.ColumnIndex)

                Dim value2 As Double = DataGridView1.Rows(e.RowIndex).Cells(1).Value
                Dim value1 As Double = DataGridView1.Rows(e.RowIndex).Cells(2).Value
                'التأكد من وجود الكمية والسعر 
                If (value1 <> 0 And value2 <> 0) Then
                    ' Add the values together
                    Dim sum As Double = value1 * value2
                    total_sum += sum
                    Guna2TextBox16.Text = total_sum
                    ' Set the value of the third column to the sum
                    DataGridView1.Rows(e.RowIndex).Cells(Column5.Index).Value = sum
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'Dim a As OpenFileDialog
        'a.Filter("jpg |.jfif")
        'اذا كان التحديد على زر الحذف
        Try

            If (e.RowIndex >= 0) Then
                If (e.ColumnIndex = -1) Then

                    ' Dim d As DialogResult = MessageBox.Show("هل انت متأكد من رغبتك بحذف السطر المحدد؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    'MsgBox("يتم الحذف")
                    'تحديد السطر بناء على المدخل
                    Dim selectedRowIndex As Integer = DataGridView1.SelectedRows(0).Index
                    'اذا لم يكن السطر المحدد اصغر من الصفر
                    If Not selectedRowIndex < 0 Then
                        'حذف السطر المحدد
                        Dim d As DialogResult = MessageBox.Show("هل انت متأكد من رغبتك بحذف السطر المحدد؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If (d = DialogResult.Yes) Then
                            DataGridView1.Rows.RemoveAt(selectedRowIndex)
                        End If
                    End If
                Else
                    'التحقق من اذا كان السطر لا يحتوي بيانات
                    If Not DataGridView1.Rows(e.RowIndex).Cells(0).Value Is Nothing Then
                        ' Handle the case when the user did not select any value
                        Guna2TextBox1.Text = functions.getOneValue("quantity", "materials", "model", DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString(), "int")

                    Else
                        'اضهار كمية المادة عند تحديد سطر المادة
                        ' TextBox6.Text = functions.getOneValue("quantity", "materials", "model", DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString(), "int")

                    End If
                    'TextBox6.Text = functions.getOneValue("quantity", "materials", "model", DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString(), "int")
                End If
            End If
        Catch ex As Exception
            If (ex.Message = "Uncommitted new row cannot be deleted.") Then
                MsgBox("لا يمكن حذف سطر لا توجد فيه بيانات")
            Else
                MsgBox(ex.Message)
            End If

        End Try
    End Sub

    Private Sub DataGridView1_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellMouseEnter
        'Dim mg2 As String = mg
        'If (e.RowIndex > -1 And e.ColumnIndex = 4) Then
        '    'MsgBox(e.RowIndex,, e.ColumnIndex)
        '    If (mg <> "") Then
        '        'If (e.RowIndex < pictureinfo.Length) Then
        '        If (DataGridView1.Columns(e.ColumnIndex).Name = "Column6") Then
        '            If (Not DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is DBNull.Value) Then
        '                ' MsgBox(e.RowIndex,, e.ColumnIndex)
        '                PictureBox1.ImageLocation = mg2
        '            End If
        '        End If
        '        'End If
        '    End If
        'End If

        If e.ColumnIndex = 4 AndAlso e.RowIndex >= 0 Then
            Dim image As Image = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            PictureBox1.Image = image
        End If
        'PictureBox1.Image = Nothing
        ' PictureBox1.Refresh()
    End Sub

    Private Sub DataGridView1_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellMouseLeave
        If e.ColumnIndex = Column6.Index Then
            PictureBox1.Image = Nothing
        End If
    End Sub

    'قائمة البيع للتوصيل

    Private Sub DataGridView2_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellValueChanged
        'التأكد من الضغط على المكان الصحيح
        If (e.RowIndex > -1) Then
            ' Make sure the column index is the one you want to sum
            If e.ColumnIndex = deliveryColumn2.Index Then

                ' MsgBox(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString())
                'تحميل الصورة حسب موقعها مع ملاحضة لا يمكن تحميل الصور المرقمة عربي
                mg = functions.getOneValue("image", "materials", "model", DataGridView2.Rows(e.RowIndex).Cells(0).Value.ToString(), "string")
                'MsgBox(mg)
                If File.Exists(mg) Then
                    DataGridView2.Rows(e.RowIndex).Cells(4).Value = Image.FromFile(mg)
                End If
                'TextBox6.Text = functions.getOneValue("quantity", "materials", "model", DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString(), "int")
                ' Column6.Image = Image.FromFile("C: \Users\lenovo\Pictures\Saved Pictures\emoji.png")
            End If

            If e.ColumnIndex = deliveryColumn4.Index Then
                ' Get the value of the two columns you want to sum

                'MsgBox(e.ColumnIndex)

                Dim value2 As Double = DataGridView2.Rows(e.RowIndex).Cells(1).Value
                Dim value1 As Double = DataGridView2.Rows(e.RowIndex).Cells(2).Value
                'التأكد من وجود الكمية والسعر 
                If (value1 <> 0 And value2 <> 0) Then
                    ' Add the values together
                    Dim sum As Double = value1 * value2
                    total_sum += sum
                    Guna2TextBox26.Text = total_sum
                    ' Set the value of the third column to the sum
                    DataGridView2.Rows(e.RowIndex).Cells(deliveryColumn5.Index).Value = sum
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        'Dim a As OpenFileDialog
        'a.Filter("jpg |.jfif")
        'اذا كان التحديد على زر الحذف
        Try

            If (e.RowIndex >= 0) Then
                If (e.ColumnIndex = -1) Then

                    ' Dim d As DialogResult = MessageBox.Show("هل انت متأكد من رغبتك بحذف السطر المحدد؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    'MsgBox("يتم الحذف")
                    'تحديد السطر بناء على المدخل
                    Dim selectedRowIndex As Integer = DataGridView2.SelectedRows(0).Index
                    'اذا لم يكن السطر المحدد اصغر من الصفر
                    If Not selectedRowIndex < 0 Then
                        'حذف السطر المحدد
                        Dim d As DialogResult = MessageBox.Show("هل انت متأكد من رغبتك بحذف السطر المحدد؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If (d = DialogResult.Yes) Then
                            DataGridView2.Rows.RemoveAt(selectedRowIndex)
                        End If
                    End If
                Else
                    'التحقق من اذا كان السطر لا يحتوي بيانات
                    If Not DataGridView2.Rows(e.RowIndex).Cells(0).Value Is Nothing Then
                        ' Handle the case when the user did not select any value
                        Guna2TextBox2.Text = functions.getOneValue("quantity", "materials", "model", DataGridView2.Rows(e.RowIndex).Cells(0).Value.ToString(), "int")

                    Else
                        'اضهار كمية المادة عند تحديد سطر المادة
                        ' TextBox6.Text = functions.getOneValue("quantity", "materials", "model", DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString(), "int")

                    End If
                    'TextBox6.Text = functions.getOneValue("quantity", "materials", "model", DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString(), "int")
                End If
            End If
        Catch ex As Exception
            If (ex.Message = "Uncommitted new row cannot be deleted.") Then
                MsgBox("لا يمكن حذف سطر لا توجد فيه بيانات")
            Else
                MsgBox(ex.Message)
            End If

        End Try
    End Sub

    Private Sub DataGridView2_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellMouseEnter
        'Dim mg2 As String = mg
        'If (e.RowIndex > -1 And e.ColumnIndex = 4) Then
        '    'MsgBox(e.RowIndex,, e.ColumnIndex)
        '    If (mg <> "") Then
        '        'If (e.RowIndex < pictureinfo.Length) Then
        '        If (DataGridView1.Columns(e.ColumnIndex).Name = "Column6") Then
        '            If (Not DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is DBNull.Value) Then
        '                ' MsgBox(e.RowIndex,, e.ColumnIndex)
        '                PictureBox1.ImageLocation = mg2
        '            End If
        '        End If
        '        'End If
        '    End If
        'End If

        If e.ColumnIndex = 4 AndAlso e.RowIndex >= 0 Then
            Dim image As Image = DataGridView2.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            PictureBox2.Image = image
        End If
        'PictureBox1.Image = Nothing
        ' PictureBox1.Refresh()
    End Sub

    Private Sub DataGridView2_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellMouseLeave
        If e.ColumnIndex = Column6.Index Then
            PictureBox2.Image = Nothing
        End If
    End Sub
    Private Sub retail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2TextBox19.Text = Date.Now
        Guna2TextBox29.Text = Date.Now
        'اضافة رموز المواد للقائمة المنسدلة للداتا كرد فيو للمباشر
        Column2.DataSource = functions.GetCoumnNames("model", "materials")
        Column2.DisplayMember = "model"

        'اضافة رموز المواد للقائمة المنسدلة للداتا كرد فيو للتوصيل
        deliveryColumn2.DataSource = functions.GetCoumnNames("model", "materials")
        deliveryColumn2.DisplayMember = "model"

        Guna2TextBox20.Text = functions.GetAutoNumber1("Sales", "list_num")

        Column5.ReadOnly = True 'اغلاق تعديل المبلغ الكلي
        deliveryColumn5.ReadOnly = True 'اغلاق تعديل المبلغ الكلي

    End Sub

    'منع المدخلات الخطأ وتكرار نفس المادة لقائمة المفرد
    Private Sub DataGridView1_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
        'عامود الكمية والسعر
        If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Then 'check if it is column 2
            'If Not Guna2DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing Then
            Dim value As String = e.FormattedValue.ToString()
            'اذا لم تكن الخلية فارغة
            If (value <> "") Then
                Dim num As Double
                'اذا لم يكن المدخل رقم صحيح او عشري
                If Not Double.TryParse(value, num) Then
                    'منع الحدث
                    e.Cancel = True 'cancel the cell edit
                    MessageBox.Show("الرجاء ادخال ارقام فقط", "ادخال خاطئ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'Guna2DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing
                End If
            End If
        ElseIf e.ColumnIndex = 0 Then
            Dim newValue = e.FormattedValue.ToString()

            ' Check if the new value already exists in the column
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow AndAlso row.Index <> e.RowIndex AndAlso row.Cells(0).Value.ToString() = newValue Then
                    e.Cancel = True ' Cancel the cell validation
                    MessageBox.Show("لا يمكن تكرار رمز المادة لنفس القائمة", "الرمز مستخدم", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            Next

            ' Clear the error message if the new value is unique
            'Guna2DataGridView1.Rows(e.RowIndex).Cells(0).ErrorText = ""
        End If

    End Sub

    'منع المدخلات الخطأ وتكرار نفس المادة لقائمة التوصيل
    Private Sub DataGridView2_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DataGridView2.CellValidating
        'عامود الكمية والسعر
        If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Then 'check if it is column 2
            'If Not Guna2DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing Then
            Dim value As String = e.FormattedValue.ToString()
            'اذا لم تكن الخلية فارغة
            If (value <> "") Then
                Dim num As Double
                'اذا لم يكن المدخل رقم صحيح او عشري
                If Not Double.TryParse(value, num) Then
                    'منع الحدث
                    e.Cancel = True 'cancel the cell edit
                    MessageBox.Show("الرجاء ادخال ارقام فقط", "ادخال خاطئ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'Guna2DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing
                End If
            End If
        ElseIf e.ColumnIndex = 0 Then
            Dim newValue = e.FormattedValue.ToString()

            ' Check if the new value already exists in the column
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow AndAlso row.Index <> e.RowIndex AndAlso row.Cells(0).Value.ToString() = newValue Then
                    e.Cancel = True ' Cancel the cell validation
                    MessageBox.Show("لا يمكن تكرار رمز المادة لنفس القائمة", "الرمز مستخدم", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            Next

            ' Clear the error message if the new value is unique
            'Guna2DataGridView1.Rows(e.RowIndex).Cells(0).ErrorText = ""
        End If

    End Sub

    'لا حاجة لهذه الخطوة السبب انه صندوق النص التابع لمكتبة غونا يعرض بشكل افظل
    'Private Sub Guna2TextBox27_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox27.TextChanged
    '    If (Guna2TextBox27.Text.Length > 50) Then
    '        Guna2TextBox27.Multiline = True
    '    End If
    'End Sub

End Class