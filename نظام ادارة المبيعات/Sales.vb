Imports System.IO

Public Class Sales
    'استرجاع جدول

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Guna2TextBox1.Text = functions.GetAutoNumber1("sales", "list_num")
        Runcommand("insert into sales(list_num,sale_type,date,name,payment_type,money_type,notes,bill_cost,discount) values('" & Guna2TextBox1.Text & "','" & "جملة" & "','" & Guna2TextBox2.Text & "','" & Guna2ComboBox2.Text & "','" & Guna2ComboBox1.Text & "', '" & "دولار" & "' , '" & Guna2TextBox5.Text & " ' , " & total_sum & " , ' " & TextBox8.Text & " ' )", "add item to database")
        For i As Integer = 0 To DataGridView1.Rows.Count - 2
            MsgBox(1)
            functions.Runcommand("insert into sales_items(model_code,quantity,price,total_price,ico,list_num) values ('" & DataGridView1.Rows(i).Cells(0).Value & "' ,' " & DataGridView1.Rows(i).Cells(1).Value & " ',' " & DataGridView1.Rows(i).Cells(2).Value & " ', ' " & DataGridView1.Rows(i).Cells(3).Value & " ' , ' " & DataGridView1.Rows(i).Cells(4).Value.ToString() & " '  , ' " & Guna2TextBox1.Text & " ' )", "add elemant....")
            MsgBox(2)
            functions.Runcommand("UPDATE materials set quantity = quantity -  " & Val(DataGridView1.Rows(i).Cells(1).Value.ToString()) & "  WHERE model = '" & DataGridView1.Rows(i).Cells(0).Value.ToString() & "'", "Update quantity....")

        Next
        total_sum = 0
        'Dim get_table As New DataTable
        'get_table.Load(sqlcom.ExecuteReader)
    End Sub

    Private Sub Sales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2TextBox2.Text = Date.Today
        Dim dt As DataTable = Get_Table("select name from [dbo].[customers] ")
        Guna2ComboBox2.DataSource = dt
        Guna2ComboBox2.DisplayMember = "name"

        Guna2TextBox1.Text = functions.GetAutoNumber1("sales", "list_num")
        'اضافة رموز المواد للقائمة المنسدلة للداتا كرد فيو
        Column2.DataSource = functions.GetCoumnNames("model", "materials")
        Column2.DisplayMember = "model"
        ' Set the DataSource property of the DataGridViewComboBoxColumn
        'DataGridView1.Columns("DataGridViewComboBoxColumn").DataSource = functions.GetCoumnNames("model", "materials")

        '' Set the DisplayMember and ValueMember properties of the DataGridViewComboBoxColumn
        'Column2.DisplayMember = "your_display_column"
        'DataGridView1.Columns("DataGridViewComboBoxColumn1").ValueMember = "your_value_column"

    End Sub
    Dim total_sum As Double = 0
    Dim mg As String = ""
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged

        ' Make sure the column index is the one you want to sum
        If e.ColumnIndex = Column2.Index Then
            If (e.RowIndex > -1) Then
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
                ' Add the values together
                Dim sum As Double = value1 * value2
                total_sum += sum
                Guna2TextBox7.Text = total_sum
                ' Set the value of the third column to the sum
                DataGridView1.Rows(e.RowIndex).Cells(Column5.Index).Value = sum
            End If
        End If
    End Sub
    Private Sub ComboBox2_Leave(sender As Object, e As EventArgs)
        ' ComboBox2.Items.Add(ComboBox2.Text)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        'DataGridView1.Columns()

        'DataGridView1.DataSource = Get_Table("select * from matirials ")
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
        'Dim a As OpenFileDialog
        'a.Filter("jpg |.jfif")
        'اذا كان التحديد على زر الحذف
        Try

            If (e.RowIndex >= 0) Then
                If (e.ColumnIndex = -1) Then

                    ' Dim d As DialogResult = MessageBox.Show("هل انت متأكد من رغبتك بحذف السطر المحدد؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    MsgBox("يتم الحذف")
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
                        Guna2TextBox6.Text = functions.getOneValue("quantity", "materials", "model", DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString(), "int")

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

    Private Sub Guna2ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Guna2ComboBox2.SelectedIndexChanged
        'Dim r As SqlDataReader
        'Dim name As String
        'name = "select debt from customers where name = '" & ComboBox2.Text & "'"

        'TextBox4.Text = r.GetDecimal("debt")
        'TextBox3.Text = functions.GetAutoNumber1("customers", "cu_id")
        'Dim r As SqlDataReader
        'Try
        '    sqlconn.Open()
        '    Dim q As String
        '    q = "select debt,cu_id from customers where name='" & ComboBox2.Text & "'"
        '    sqlcom = New SqlCommand(q, sqlconn)
        '    r = sqlcom.ExecuteReader
        '    While r.Read

        '        TextBox4.Text = r.GetDecimal("debt")
        '        TextBox3.Text = r.GetInt32("cu_id")
        '    End While
        '    sqlconn.Close()

        'Catch ex As Exception
        '    MsgBox(ex.Message)

        'Finally
        '    If sqlconn.State = ConnectionState.Open Then
        '        sqlconn.Close()

        '    End If
        'End Try
        'استرجاع دين الزبون
        Guna2TextBox4.Text = functions.getOneValue("debt", "customers", "name", Guna2ComboBox2.Text, "decimal")
        'استرجاع رقم الزبون
        Guna2TextBox3.Text = functions.getOneValue("cu_id", "customers", "name", Guna2ComboBox2.Text, "int")
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


End Class