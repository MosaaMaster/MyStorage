Public Class ReportsResult
    Private Sub ReportsResult_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Reports.report = "اضهار معلومات زبائن الجملة") Then
            Me.Text = "كافة معلومات زبائن الجملة"
            DataGridView1.DataSource = functions.GetTable("select * from customers")
        ElseIf (Reports.report = "اضهار معلومات زبائن التوصيل") Then
            Me.Text = "كافة معلومات زبائن التوصيل"
            DataGridView1.DataSource = functions.GetTable("select * from delivery_customers")
        ElseIf (Reports.report = "اضهار معلومات المجهزين") Then
            Me.Text = "كافة معلومات المجهزين"
            DataGridView1.DataSource = functions.GetTable("select * from supplier")
        End If
        If (Reports.report = "اضهار كافة معلومات المواد") Then
            Me.Text = "كافة معلومات المواد "
            DataGridView1.DataSource = functions.GetTable("select * from materials")
        End If
    End Sub
End Class