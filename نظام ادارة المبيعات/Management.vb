Public Class Management




    Private Sub Management_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'IconButton1.ForeColor = Color.Black
        'IconButton2.ForeColor = Color.Black
        'IconButton3.ForeColor = Color.Black
    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        passwords.ShowDialog()
    End Sub

    Private Sub IconButton2_Click(sender As Object, e As EventArgs) Handles IconButton2.Click
        people.ShowDialog()
    End Sub

    Private Sub IconButton3_Click(sender As Object, e As EventArgs) Handles IconButton3.Click
        other_activities.ShowDialog()
    End Sub

    'تغير لون الايكون عنده المرور عليها واخفئها عنده الابتعاد عنها
    Private Sub IconButton1_MouseHover(sender As Object, e As EventArgs) Handles IconButton1.MouseHover
        IconButton1.IconColor = Color.White


    End Sub

    Private Sub IconButton1_Mouseleave(sender As Object, e As EventArgs) Handles IconButton1.MouseLeave
        IconButton1.IconColor = Color.Black
    End Sub


    'تغير لون الايكون عنده المرور عليها واخفئها عنده الابتعاد عنها
    Private Sub IconButton2_MouseHover(sender As Object, e As EventArgs) Handles IconButton2.MouseHover
        IconButton2.IconColor = Color.White
    End Sub

    Private Sub IconButton2_Mouseleave(sender As Object, e As EventArgs) Handles IconButton2.MouseLeave
        IconButton2.IconColor = Color.Black
    End Sub


    'تغير لون الايكون عنده المرور عليها واخفئها عنده الابتعاد عنها
    Private Sub IconButton3_MouseHover(sender As Object, e As EventArgs) Handles IconButton3.MouseHover
        IconButton3.IconColor = Color.White
    End Sub

    Private Sub IconButton3_Mouseleave(sender As Object, e As EventArgs) Handles IconButton3.MouseLeave
        IconButton3.IconColor = Color.Black
    End Sub

End Class