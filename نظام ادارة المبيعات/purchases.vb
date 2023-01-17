Imports System.Data.SqlClient
Class purchases
    Dim sqlconn As New SqlConnection("server=DESKTOP-GKVLA13 ;database=sales_management;integrated security =true")
    Dim sqlcom As New SqlCommand("", sqlconn)


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Label10.Visible = True
        TextBox5.Visible = True

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        functions.Runcommand("insert into purchases(list_num,date,list_type,name)values(" & TextBox2.Text & ",'" & TextBox1.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "' )", "add elemant....")
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' Check if the cell clicked is a DataGridViewImageColumn
        Try
            Dim cellValue(3) As Object
            For i = 0 To 3
                cellValue(i) = DataGridView1.Rows(e.RowIndex).Cells(i).Value
            Next

            'اذا كان التحديد على زر الحذف
            If (e.ColumnIndex = -1) Then
                If (cellValue(3) Is Nothing = False And cellValue(0) Is Nothing And cellValue(1) Is Nothing And cellValue(0) Is Nothing) Then


                End If
                'MessageBox.Show("hello", "hi",)
                ' MessageBox.Show("هل انت متأكد من رغبتك بحذف السطر المحدد؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) As dialog.result

                'تحديد السطر بناء على المدخل
                Dim selectedRowIndex As Integer = DataGridView1.SelectedRows(0).Index
                'اذا لم يكن السطر المحدد اصغر من الصفر
                If Not selectedRowIndex < 0 Then
                    'حذف السطر المحدد
                    DataGridView1.Rows.RemoveAt(selectedRowIndex)
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
                        'لوحة الكترونية
                        Dim bitmap As New Bitmap(filePath)
                        'تثبيت قيمة اللوحة الالكترونية داخل مربع الصورة
                        DataGridView1(e.ColumnIndex, e.RowIndex).Value = bitmap
                        DataGridView1.Refresh()
                    End If
                End If
            End If
        Catch ex As Exception
            If (ex.Message = "Uncommitted new row cannot be deleted.") Then
                MsgBox("لا يمكن حذف سطر لا توجد فيه بيانات")
            Else
                MsgBox(ex.Message)
            End If
        Finally
            'If sqlconn.State = ConnectionState.Open Then
            '    sqlconn.Close()
            'End If
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

    End Sub

End Class