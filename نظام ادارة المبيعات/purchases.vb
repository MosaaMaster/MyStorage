Imports System.IO

Class purchases

    Dim pictureinfo() As String = {""}
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Label10.Visible = True
        TextBox5.Visible = True

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        functions.Runcommand("insert into purchases(list_num,date,list_type,name,payment_type,material_type,country_source,notes,total_price)values(" & TextBox2.Text & ",'" & TextBox1.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & ComboBox4.Text & "','" & ComboBox5.Text & "' , '" & TextBox3.Text & "' , '" & TextBox4.Text & "')", "add elemant....")
        For i As Integer = 0 To DataGridView1.Rows.Count - 2

            'Dim bmp As Bitmap = DataGridView1.Rows(i).Cells(4).Value
            'Dim img As Image = DataGridView1.Rows(i).Cells(4).Value
            'Dim ms As New MemoryStream()
            'img.Save(ms, Image.Jpeg)
            'Dim data As Byte() = ms.ToArray()
            functions.Runcommand("insert into purchases_items(model_code,quantity,price,total_price,ico,list_num) values ('" & DataGridView1.Rows(i).Cells(0).Value & "' ,' " & DataGridView1.Rows(i).Cells(1).Value & " ',' " & DataGridView1.Rows(i).Cells(2).Value & " ', ' " & DataGridView1.Rows(i).Cells(3).Value & " ' ,  '" & pictureinfo(i) & " '  , " & TextBox2.Text & " )", "add elemant....")
            functions.Runcommand("insert into materials(model,quantity,price,image,type) values('" & DataGridView1.Rows(i).Cells(0).Value & "', ' " & DataGridView1.Rows(i).Cells(1).Value & " ' , ' " & DataGridView1.Rows(i).Cells(2).Value & " ' , '" & pictureinfo(i) & " ' , ' " & ComboBox4.Text & " ' )", "add elemant....")

        Next
        c = 0
        total_sum = 0
    End Sub
    Dim c As Integer = 0
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' Check if the cell clicked is a DataGridViewImageColumn

        Try
            Dim cellValue(3) As Object
            For i = 0 To 3
                cellValue(i) = DataGridView1.Rows(e.RowIndex).Cells(i).Value
            Next

            'اذا كان التحديد على زر الحذف
            If (e.ColumnIndex = -1) Then
                If (e.RowIndex > -1) Then
                    If (cellValue(3) Is Nothing = False And cellValue(0) Is Nothing And cellValue(1) Is Nothing And cellValue(0) Is Nothing) Then


                    End If
                    'MessageBox.Show("hello", "hi",)
                    ' MessageBox.Show("هل انت متأكد من رغبتك بحذف السطر المحدد؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) As dialog.result

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
                End If
                'DataGridView1.Rows.RemoveAt(DataGridView1.SelectedRows(0).Index)
            Else
                'اذا تم النقر على الصورة
                If DataGridView1.Columns(e.ColumnIndex).Name = "Column6" Then
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

                        ReDim Preserve pictureinfo(DataGridView1.Rows.Count - 1)
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
                        DataGridView1(e.ColumnIndex, e.RowIndex).Value = bitmap
                        DataGridView1.Refresh()
                    End If
                ElseIf (DataGridView1.Columns(e.ColumnIndex).Name = "Column2") Then

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

        DataGridView1.MultiSelect = False
        TextBox2.Text = functions.GetAutoNumber1("purchases", "list_num")
        TextBox1.Text = Date.Today
        'انشاء متغير يحمل حميع الاسماء 
        ComboBox2.DataSource = functions.GetCoumnNames("name", "supplier") 'عرض جميع الاسماء في الكمبو بوكس
        ComboBox2.DisplayMember = "name"
        ComboBox2.Text = ""
        'اضهار مسار البرنامج
        ' MsgBox(Application.StartupPath)

        pictureinfo(0) = ""
        'now we will discuess this
        'DataGridView1.Columns("").DefaultCellStyle.DropDownStyle = ComboBoxStyle.DropDown
        'DataGridView1.Columns(2). = FlatStyle.Popup
        'DataGridView1.Columns(Column2).AutoComplete = True
    End Sub
    Dim total_sum As Integer = 0
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If (e.RowIndex > -1) Then
            ' Make sure the column index is the one you want to sum
            If e.ColumnIndex = Column4.Index Then
                ' Get the value of the two columns you want to sum

                'MsgBox(e.ColumnIndex)

                Dim value2 As Double = DataGridView1.Rows(e.RowIndex).Cells(1).Value
                Dim value1 As Double = DataGridView1.Rows(e.RowIndex).Cells(2).Value
                ' Add the values together
                Dim sum As Double = value1 * value2
                total_sum += sum
                TextBox4.Text = total_sum
                ' Set the value of the third column to the sum
                DataGridView1.Rows(e.RowIndex).Cells(Column5.Index).Value = sum
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

    Private Sub DataGridView1_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellMouseEnter
        If (e.RowIndex > -1 And e.ColumnIndex = 4) Then
            'MsgBox(e.RowIndex,, e.ColumnIndex)
            If (pictureinfo(0) <> "") Then
                If (e.RowIndex < pictureinfo.Length) Then
                    If (DataGridView1.Columns(e.ColumnIndex).Name = "Column6") Then
                        If (Not DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Is DBNull.Value) Then
                            ' MsgBox(e.RowIndex,, e.ColumnIndex)
                            PictureBox1.ImageLocation = pictureinfo(e.RowIndex)
                        End If
                    End If
                End If
            End If
        End If
    End Sub


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