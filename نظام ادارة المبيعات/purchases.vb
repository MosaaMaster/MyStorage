Imports System.IO

Class purchases

    Dim pictureinfo() As String = {""}
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Label12.Visible = True
        Guna2ComboBox6.Visible = True
        Guna2ComboBox6.DataSource = functions.GetCoumnNames("list_num", "purchases")
        Guna2ComboBox6.DisplayMember = "list_num"

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For x As Integer = 0 To Guna2DataGridView1.Rows.Count - 2
            For y = 0 To 3
                If (Guna2DataGridView1.Rows(x).Cells(y).Value Is Nothing) Then
                    MessageBox.Show("الرجاء اكمال معلومات المواد", "نقص مدخلات", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next
        Next
        functions.Runcommand("insert into purchases(list_num,date,list_type,name,payment_type,material_type,country_source,notes,total_price)values(" & Guna2TextBox2.Text & ",'" & Guna2TextBox1.Text & "','" & Guna2ComboBox1.Text & "','" & Guna2ComboBox2.Text & "','" & Guna2ComboBox3.Text & "','" & Guna2ComboBox4.Text & "','" & Guna2ComboBox5.Text & "' , '" & Guna2TextBox3.Text & "' , '" & Guna2TextBox4.Text & "')", "add elemant....")

        For i As Integer = 0 To Guna2DataGridView1.Rows.Count - 2

            'Dim bmp As Bitmap = DataGridView1.Rows(i).Cells(4).Value
            'Dim img As Image = DataGridView1.Rows(i).Cells(4).Value
            'Dim ms As New MemoryStream()
            'img.Save(ms, Image.Jpeg)
            'Dim data As Byte() = ms.ToArray()
            functions.Runcommand("insert into purchases_items(model_code,quantity,price,total_price,ico,list_num) values ('" & Guna2DataGridView1.Rows(i).Cells(0).Value & "' ,' " & Guna2DataGridView1.Rows(i).Cells(1).Value & " ',' " & Guna2DataGridView1.Rows(i).Cells(2).Value & " ', ' " & Guna2DataGridView1.Rows(i).Cells(3).Value & " ' ,  '" & pictureinfo(i) & " '  , " & Guna2TextBox2.Text & " )", "add elemant....")
            functions.Runcommand("insert into materials(model,quantity,price,image,type) values('" & Guna2DataGridView1.Rows(i).Cells(0).Value & "', ' " & Guna2DataGridView1.Rows(i).Cells(1).Value & " ' , ' " & Guna2DataGridView1.Rows(i).Cells(2).Value & " ' , '" & pictureinfo(i) & " ' , ' " & Guna2ComboBox4.Text & " ' )", "add elemant....")

        Next
        c = 0
        total_sum = 0
    End Sub
    Dim c As Integer = 0
    Private Sub Guna2DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellClick
        ' Check if the cell clicked is a DataGridViewImageColumn

        Try
            Dim cellValue(3) As Object
            For i = 0 To 3
                cellValue(i) = Guna2DataGridView1.Rows(e.RowIndex).Cells(i).Value
            Next

            'اذا كان التحديد على زر الحذف
            If (e.ColumnIndex = -1) Then
                If (e.RowIndex > -1) Then
                    If (cellValue(3) Is Nothing = False And cellValue(0) Is Nothing And cellValue(1) Is Nothing And cellValue(0) Is Nothing) Then


                    End If
                    'MessageBox.Show("hello", "hi",)
                    ' MessageBox.Show("هل انت متأكد من رغبتك بحذف السطر المحدد؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) As dialog.result

                    'تحديد السطر بناء على المدخل
                    Dim selectedRowIndex As Integer = Guna2DataGridView1.SelectedRows(0).Index
                    'اذا لم يكن السطر المحدد اصغر من الصفر
                    If Not selectedRowIndex < 0 Then
                        'حذف السطر المحدد
                        Dim d As DialogResult = MessageBox.Show("هل انت متأكد من رغبتك بحذف السطر المحدد؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If (d = DialogResult.Yes) Then
                            Guna2DataGridView1.Rows.RemoveAt(selectedRowIndex)
                        End If
                    End If
                End If
                'DataGridView1.Rows.RemoveAt(DataGridView1.SelectedRows(0).Index)
            Else
                'اذا تم النقر على الصورة
                If Guna2DataGridView1.Columns(e.ColumnIndex).Name = "Column5" Then
                    ' The cell clicked is a DataGridViewImageColumn with the name "ImageColumn"
                    ' You can now access the cell value and do something with it
                    'لا حاجة لها
                    'Dim cellValue As Object = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                    ' Do something with the cellValue here
                    'مربع حوار تصفح الملفات
                    Dim openFileDialog As New OpenFileDialog()
                    'فلترة النتائج للصور فقط
                    openFileDialog.Filter = "Image files |*.jpg;*.jpeg;*.png"
                    openFileDialog.Title = "Select an image file"
                    If openFileDialog.ShowDialog() = DialogResult.OK Then

                        Dim filePath As String = openFileDialog.FileName
                        'اخذ مسار واسم ونوع الصورة
                        ' MsgBox(DataGridView1.Rows.Count,, "عدد الأسطر")

                        ReDim Preserve pictureinfo(Guna2DataGridView1.Rows.Count - 1)
                        pictureinfo(e.RowIndex) = filePath
                        'If Not DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is DBNull.Value Then

                        '    MsgBox("c = " & c)
                        'Else
                        '    MsgBox("c = " & c)
                        '    c += 1
                        'End If
                        PictureBox1.ImageLocation = filePath
                        'لوحة الكترونية
                        Dim bitmap As New Bitmap(filePath)
                        'تثبيت قيمة اللوحة الالكترونية داخل مربع الصورة
                        Guna2DataGridView1(e.ColumnIndex, e.RowIndex).Value = bitmap
                        Guna2DataGridView1.Refresh()
                    End If
                ElseIf (Guna2DataGridView1.Columns(e.ColumnIndex).Name = "Column1") Then

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

    Private Sub purchases_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button4.Visible = False
        Guna2DataGridView1.RowHeadersVisible = True 'اضهار زر الحذف
        Guna2DataGridView1.MultiSelect = False
        Column4.ReadOnly = True 'اغلاق تعديل المبلغ الكلي
        Label12.Visible = False
        Guna2ComboBox6.Visible = False

        Guna2TextBox2.Text = functions.GetAutoNumber1("purchases", "list_num")
        Guna2TextBox1.Text = Date.Today
        'انشاء متغير يحمل حميع الاسماء 
        Guna2ComboBox2.DataSource = functions.GetCoumnNames("name", "supplier") 'عرض جميع الاسماء في الكمبو بوكس
        Guna2ComboBox2.DisplayMember = "name"
        Guna2ComboBox2.Text = ""
        'اضهار مسار البرنامج
        ' MsgBox(Application.StartupPath)

        pictureinfo(0) = ""
        'now we will discuess this
        'DataGridView1.Columns("").DefaultCellStyle.DropDownStyle = ComboBoxStyle.DropDown
        'DataGridView1.Columns(2). = FlatStyle.Popup
        'DataGridView1.Columns(Column2).AutoComplete = True
    End Sub
    Dim total_sum As Integer = 0
    Private Sub Guna2DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellValueChanged
        If (e.RowIndex > -1) Then
            ' Make sure the column index is the one you want to sum
            If e.ColumnIndex = Column3.Index Then
                ' Get the value of the two columns you want to sum

                'MsgBox(e.ColumnIndex)

                Dim value2 As Double = Guna2DataGridView1.Rows(e.RowIndex).Cells(1).Value
                Dim value1 As Double = Guna2DataGridView1.Rows(e.RowIndex).Cells(2).Value
                ' Add the values together
                Dim sum As Double = value1 * value2
                total_sum += sum
                Guna2TextBox4.Text = total_sum
                ' Set the value of the third column to the sum
                Guna2DataGridView1.Rows(e.RowIndex).Cells(Column4.Index).Value = sum
            End If
        End If
    End Sub

    'Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    '    Dim r As SqlDataReader
    '    Try
    '        sqlconn.Open()
    '        Dim q As String
    '        q = "select ico from purchases_items where list_num = 31 "
    '        sqlcom = New SqlCommand(q, sqlconn)
    '        r = sqlcom.ExecuteReader
    '        While r.Read
    '            PictureBox1.ImageLocation = r.GetString("ico")
    '            'MsgBox(r.GetString("ico"))
    '            'Dim imageData As Byte() = DirectCast(r("ico"), Byte())
    '            'Dim ms As New MemoryStream(imageData)
    '            'Dim img As Image = Image.FromStream(ms)

    '            'Dim imageData As Byte() = DirectCast(r("ico"), Byte())
    '            'Dim ms As New MemoryStream(imageData)
    '            'Dim img As Image = Image.FromStream(ms)
    '            'MsgBox(32)

    '            'Dim imageData As Byte() = DirectCast(r("ico"), Byte())
    '            'Dim converter As New ImageConverter()
    '            'Dim img As Image = DirectCast(Converter.ConvertFrom(imageData), Image)
    '            'Dim imageData As Byte() = DirectCast(r("ico"), Byte())
    '            'Dim converter As New ImageConverter()
    '            'Dim img As Bitmap = DirectCast(converter.ConvertFrom(imageData), Bitmap)
    '            'Dim productImageByte As Byte() = r.GetSqlBinary("ico")
    '            'MsgBox(1)
    '            'If productImageByte IsNot Nothing Then
    '            '    Using productImageStream As Stream = New System.IO.MemoryStream(productImageByte)
    '            '        PictureBox1.Image = Image.FromStream(productImageStream)
    '            '    End Using
    '            'End If
    '            'PictureBox1.Image = img

    '        End While
    '        '    sqlconn.Open()
    '        '    Dim command As New SqlCommand
    '        '    command.Connection = sqlconn
    '        '    command.CommandText = "select ico from purchases_items where list_num = 29 "
    '        '    Dim productImageByte As Byte() = TryCast(command.ExecuteScalar, Byte())
    '        '    MsgBox(1)
    '        '    If productImageByte IsNot Nothing Then
    '        '        MsgBox(2)
    '        '        Using productImageStream As Stream = New System.IO.MemoryStream(productImageByte)
    '        '            MsgBox(3)
    '        '            PictureBox1.Image = Image.FromStream(productImageStream)
    '        '            MsgBox(4)
    '        '        End Using
    '        '    End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)

    '    Finally

    '    End Try
    'End Sub

    Private Sub Guna2DataGridView1_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellMouseEnter
        If (e.RowIndex > -1 And e.ColumnIndex = 4) Then
            'MsgBox(e.RowIndex,, e.ColumnIndex)
            If (pictureinfo(0) <> "") Then
                If (e.RowIndex < pictureinfo.Length) Then
                    If (Guna2DataGridView1.Columns(e.ColumnIndex).Name = "Column5") Then
                        If (Not Guna2DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is DBNull.Value) Then
                            ' MsgBox(e.RowIndex,, e.ColumnIndex)
                            PictureBox1.ImageLocation = pictureinfo(e.RowIndex)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Guna2ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Guna2ComboBox1.SelectedIndexChanged
        If (Guna2ComboBox1.Text = "استرجاع") Then
            Label10.Visible = True
            Guna2ComboBox6.Visible = True
        ElseIf (Guna2ComboBox1.Text = "شراء") Then
            Label10.Visible = False
            Guna2ComboBox6.Visible = False
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        functions.Runcommand("Update  purchases SET list_num = '" & Guna2ComboBox6.Text & "',date ='" & Guna2TextBox1.Text & "',list_type='" & Guna2ComboBox1.Text & "',name='" & Guna2ComboBox2.Text & "',payment_type='" & Guna2ComboBox3.Text & "',material_type='" & Guna2ComboBox4.Text & "',country_source='" & Guna2ComboBox5.Text & "',notes='" & Guna2TextBox3.Text & "',total_price='" & Guna2TextBox4.Text & "' where list_num = '" & Guna2ComboBox6.Text & " ' ", "   updata elemant in supplier....")
        'حذف المواد المشترات عند التحديث
        functions.Runcommand("DELETE FROM purchases_items WHERE list_num = " & Guna2ComboBox6.Text)
        For i As Integer = 0 To Guna2DataGridView1.Rows.Count - 2


            'يحتاج الى عمل مفتاح رئيسي للجدول من اجل استرجاع التسلسل 
            'للمفتاح الرئيسي عبر المفتاح الأجنبي وذالك لتحديث البيانات
            'للمواد المشتراة حسب قائمة الشراء المذكورة
            'وايظاً تحديث المواد
            'functions.Runcommand("Update purchases_items SET list_num = '" & Guna2TextBox5.Text & " '(model_code,quantity,price,total_price,ico,list_num) values ('" & Guna2DataGridView1.Rows(i).Cells(0).Value & "' ,' " & Guna2DataGridView1.Rows(i).Cells(1).Value & " ',' " & Guna2DataGridView1.Rows(i).Cells(2).Value & " ', ' " & Guna2DataGridView1.Rows(i).Cells(3).Value & " ' ,  '" & pictureinfo(i) & " '  , " & Guna2TextBox2.Text & " )", "add elemant....")
            'اضافة المواد المشترات بعد الحذف لاكمال التعديل
            'تمت هذه الحركة في حالة تم الغاء احد المواد المشتراة
            functions.Runcommand("insert into purchases_items(model_code,quantity,price,total_price,ico,list_num) values ('" & Guna2DataGridView1.Rows(i).Cells(0).Value & "' ,' " & Guna2DataGridView1.Rows(i).Cells(1).Value & " ',' " & Guna2DataGridView1.Rows(i).Cells(2).Value & " ', ' " & Guna2DataGridView1.Rows(i).Cells(3).Value & " ' ,  '" & pictureinfo(i) & " '  , " & Guna2ComboBox6.Text & " )", "add elemant....")

            functions.Runcommand("Update materials SET model = '" & Guna2DataGridView1.Rows(i).Cells(0).Value & "',quantity = ' " & Guna2DataGridView1.Rows(i).Cells(1).Value & " ' ,price = ' " & Guna2DataGridView1.Rows(i).Cells(2).Value & " ' ,image = '" & pictureinfo(i) & " ' ,type = ' " & Guna2ComboBox4.Text & " ' ", " تم تحديث المواد")
            'quantity,price,image,type
        Next
        Dim s As String = Guna2ComboBox2.Text
        MsgBox(s)
        Dim num As String = functions.getOneValue("name", "purchases", "name", Guna2ComboBox2.Text, "string")
        MsgBox(num)

    End Sub


    Private Sub Guna2TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim openFileDialog As New OpenFileDialog()
        'فلترة النتائج للصور فقط
        openFileDialog.Filter = "Image files |*.jpg;*.jpeg;*.png"
        openFileDialog.Title = "Select and image file"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            'استرجاع المسار الكامل مع الأسم

            Dim filePath As String = openFileDialog.FileName

            Button5.BackgroundImage = Image.FromFile(filePath)
            Button5.BackgroundImageLayout = ImageLayout.Zoom
            Button5.FlatAppearance.BorderSize = 0
            Button5.Text = ""
            Button6.Visible = True
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim result As DialogResult = MessageBox.Show("هل تريد حذف الوصل المحدد؟", "تأكيد الحذف", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If result = DialogResult.OK Then
            Button5.BackgroundImage = Nothing
            Button5.FlatAppearance.BorderSize = 1
            Button5.Text = "اضافة وصل المجهز (اختياري"
            Button6.Visible = False

        End If

    End Sub

    Private Sub Button5_MouseHover(sender As Object, e As EventArgs) Handles Button5.MouseHover
        If (Button5.Text = "") Then
            PictureBox1.Image = Button5.BackgroundImage
        End If
    End Sub

    Private Sub Button5_MouseLeave(sender As Object, e As EventArgs) Handles Button5.MouseLeave
        PictureBox1.Image = Nothing
    End Sub

    Private Sub Guna2DataGridView1_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles Guna2DataGridView1.CellValidating
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
            For Each row As DataGridViewRow In Guna2DataGridView1.Rows
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

    'Private Sub Button7_Click(sender As Object, e As EventArgs)
    '    Dim printerName As String = ""
    '    Dim printDocument As New Printing.PrintDocument()
    '    Dim printDialog As New PrintDialog()

    '    ' Show the print dialog to select the printer
    '    If printDialog.ShowDialog() = DialogResult.OK Then
    '        printDocument.PrinterSettings = printDialog.PrinterSettings
    '        printerName = printDocument.PrinterSettings.PrinterName
    '    End If

    '    ' Use the printer name in your code
    '    MessageBox.Show("Printer name: " & printerName)
    'End Sub


    'Private Sub DataGridView1_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellLeave
    '    If DataGridView1.SelectedRows.Count > 0 Then
    '        If (DataGridView1.Rows(DataGridView1.SelectedRows(0).Index).Cells(1).Value Is Nothing Or DataGridView1.Rows(DataGridView1.SelectedRows(0).Index).Cells(2).Value Is Nothing) Then

    '        Else
    '            DataGridView1.Rows(DataGridView1.SelectedRows(0).Index).Cells(3).Value = DataGridView1.Rows(DataGridView1.SelectedRows(0).Index).Cells(1).Value + DataGridView1.Rows(DataGridView1.SelectedRows(0).Index).Cells(2).Value
    '            MsgBox(DataGridView1.Rows(DataGridView1.SelectedRows(0).Index).Cells(3).Value)
    '        End If
    '    End If
    '    If (DataGridView1.Columns(e.ColumnIndex).Name = "Column4") Then

    '    End If
    'End Sub
End Class