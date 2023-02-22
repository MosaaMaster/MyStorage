Imports FontAwesome.Sharp
Public Class Form1

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        purchases.ShowDialog()
    End Sub

    Private Sub IconButton2_Click(sender As Object, e As EventArgs) Handles IconButton2.Click
        Sales.ShowDialog()
    End Sub

    Private Sub IconButton3_Click(sender As Object, e As EventArgs) Handles IconButton3.Click
        retail.ShowDialog()
    End Sub

    Private Sub IconButton4_Click(sender As Object, e As EventArgs) Handles IconButton4.Click
        MoneyBox.ShowDialog()
    End Sub

    Private Sub IconButton5_Click(sender As Object, e As EventArgs) Handles IconButton5.Click
        Management.ShowDialog()
    End Sub

    Private Sub IconButton6_Click(sender As Object, e As EventArgs) Handles IconButton6.Click
        Reports.ShowDialog()
    End Sub


    '-------------------------الاحداث--------------------------
    Private Sub IconButton1_MouseHover(sender As Object, e As EventArgs) Handles IconButton1.MouseHover, IconButton1.Click
        IconButton10.IconSize = 200
        IconButton1.ForeColor = Color.White
        IconButton1.ForeColor = Color.White
        IconButton10.IconChar = IconChar.Shopify
        IconButton10.Text = "المشتريات من هنا نقوم بعمليه شراء المواد"
    End Sub

    Private Sub IconButton2_MouseHover(sender As Object, e As EventArgs) Handles IconButton2.MouseHover
        IconButton2.ForeColor = Color.White
        IconButton10.IconChar = IconChar.ShoppingBasket
        IconButton10.Text = "مبيعات جمله من هنا نقوم بأنشاء قوائم بيع الجمله للزبائن"
    End Sub

    Private Sub IconButton3_MouseHover(sender As Object, e As EventArgs) Handles IconButton3.MouseHover
        IconButton10.IconSize = 200
        IconButton3.ForeColor = Color.White
        IconButton10.IconChar = IconChar.ShoppingBasket
        IconButton10.Text = "مبيعات مفرد من هنا نقوم بعمليه البيع المباشر والتوصيل "
    End Sub

    Private Sub IconButton4_MouseHover(sender As Object, e As EventArgs) Handles IconButton4.MouseHover
        IconButton10.IconSize = 200
        IconButton4.ForeColor = Color.White
        IconButton10.IconChar = IconChar.SuitcaseRolling
        IconButton10.Text = "الصندوق من هنا نقوم  بعمليه ادرة الاموال دخل الصندوق"
    End Sub
    Private Sub IconButton5_MouseHover(sender As Object, e As EventArgs) Handles IconButton5.MouseHover
        IconButton10.IconSize = 200
        IconButton5.ForeColor = Color.White
        IconButton10.IconChar = IconChar.Gear
        IconButton10.Text = "اداره النظام  من هنا نقوم بادراة خصائص النظام  "
    End Sub

    Private Sub IconButton6_MouseHover(sender As Object, e As EventArgs) Handles IconButton6.MouseHover
        IconButton10.IconSize = 200
        IconButton6.ForeColor = Color.White
        IconButton10.IconChar = IconChar.Gear
        IconButton10.Text = "التقارير  من هنا نقوم بعرض جميع التقارير  "
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False

        IconButton10.IconChar = IconChar.None
        IconButton10.Text = ""


        'IconButton1.ForeColor = Color.Black
        'IconButton2.ForeColor = Color.Black
        'IconButton3.ForeColor = Color.Black
        'IconButton4.ForeColor = Color.Black
        'IconButton5.ForeColor = Color.Black
        'IconButton6.ForeColor = Color.Black
        Dim screenBounds As Rectangle = Screen.PrimaryScreen.WorkingArea
        Me.Bounds = screenBounds
        'Me.WindowState = FormWindowState.Maximized
        'Me.FormBorderStyle = FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.AutoSize = False




    End Sub
    'عنده مغادرت البتن
    Private Sub IconButton1_MouseLeave(sender As Object, e As EventArgs) Handles IconButton1.MouseLeave
        IconButton1.ForeColor = Color.Black
        IconButton10.IconChar = IconChar.None
        IconButton10.Text = ""

    End Sub

    Private Sub IconButton2_MouseLeave(sender As Object, e As EventArgs) Handles IconButton2.MouseLeave
        IconButton2.ForeColor = Color.Black
        IconButton10.IconChar = IconChar.None
        IconButton10.Text = ""

    End Sub


    Private Sub IconButton3_MouseLeave(sender As Object, e As EventArgs) Handles IconButton3.MouseLeave
        IconButton3.ForeColor = Color.Black
        IconButton10.IconChar = IconChar.None
        IconButton10.Text = ""

    End Sub

    Private Sub IconButton4_MouseLeave(sender As Object, e As EventArgs) Handles IconButton4.MouseLeave
        IconButton4.ForeColor = Color.Black
        IconButton10.IconChar = IconChar.None
        IconButton10.Text = ""

    End Sub

    Private Sub IconButton5_MouseLeave(sender As Object, e As EventArgs) Handles IconButton5.MouseLeave
        IconButton5.ForeColor = Color.Black
        IconButton10.IconChar = IconChar.None
        IconButton10.Text = ""

    End Sub

    Private Sub IconButton6_MouseLeave(sender As Object, e As EventArgs) Handles IconButton6.MouseLeave
        IconButton6.ForeColor = Color.Black
        IconButton10.IconChar = IconChar.None
        IconButton10.Text = ""

    End Sub

    Private Sub IconButton7_MouseHover(sender As Object, e As EventArgs) Handles IconButton7.MouseHover
        ''IconButton10.Text = " الاداره :احمد صباح //البرمجه سجاد مؤيد موسى عارف //تصميم الاء يوسف


        Label3.Visible = True
        Label4.Visible = True
        Label5.Visible = True
    End Sub

    Private Sub IconButton7_MouseLeave(sender As Object, e As EventArgs) Handles IconButton7.MouseLeave
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
    End Sub

    Private Sub IconButton8_MouseHover(sender As Object, e As EventArgs) Handles IconButton8.MouseHover
        ' IconButton10.TextAlign = ContentAlignment.MiddleCenter



        IconButton10.Text = "       برنامج اداره المبيعات هوه برنامج يقوم بتسهيل عمليه الاداره الكامله داخل المحلات الصغير والمتوسطه من خلال اداره تامه لحركة الاموال وادارة الديون وادارة المخزون داخل المحل "
    End Sub

    Private Sub IconButton8_MouseLeave(sender As Object, e As EventArgs) Handles IconButton8.MouseLeave
        IconButton10.Text = ""
    End Sub

    Private Sub IconButton9_MouseHover(sender As Object, e As EventArgs) Handles IconButton9.MouseHover


        'Dim image As Image = My.Resources.لوغو_النظام_مع_الأسم
        IconButton10.BackgroundImageLayout = ImageLayout.Zoom

        IconButton10.Image = My.Resources.لوغو_النظام_مع_الأسم

    End Sub

    Private Sub IconButton9_Mouseleave(sender As Object, e As EventArgs) Handles IconButton9.MouseLeave

        IconButton10.Image = Nothing

    End Sub


    'ايقاف تحريك الشاشة عن طريق سحب شريط العنوان

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left AndAlso e.Location.Y < SystemInformation.CaptionHeight Then
            ' The user clicked the title bar
            MsgBox("User clicked title bar.")
        End If
    End Sub

    'Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    'Private Const HT_CAPTION As Integer = 2

    'Protected Overrides Sub WndProc(ByRef m As Message)
    '    MyBase.WndProc(m)

    '    If m.Msg = WM_NCLBUTTONDOWN AndAlso m.WParam.ToInt32() = HT_CAPTION Then
    '        ' Prevent the user from moving the form by handling the WM_NCLBUTTONDOWN message
    '        Return
    '    End If
    'End Sub

    'Private isMouseDown As Boolean
    'Private mouseOffset As Point

    'Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
    '    If e.Button = MouseButtons.Left Then
    '        isMouseDown = True
    '        mouseOffset = New Point(e.X, e.Y)
    '    End If
    'End Sub

    'Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
    '    If isMouseDown Then
    '        Dim newLocation As Point = Me.Location
    '        newLocation.X += e.X - mouseOffset.X
    '        newLocation.Y += e.Y - mouseOffset.Y
    '        Me.Location = newLocation
    '    End If
    'End Sub

    'Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
    '    isMouseDown = False
    'End Sub
    'Private mouseOffset As Point

    'Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
    '    If e.Button = MouseButtons.Left Then
    '        ' Capture the mouse events to prevent the form from being moved
    '        Me.Capture = True
    '        ' Calculate the offset between the mouse position and the form's top-left corner
    '        Me.mouseOffset = New Point(-e.X, -e.Y)
    '    End If
    'End Sub

    'Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
    '    If Me.Capture Then
    '        ' Move the form to the new mouse position
    '        Dim mousePos As Point = Control.MousePosition
    '        mousePos.Offset(Me.mouseOffset.X, Me.mouseOffset.Y)
    '        Me.Location = mousePos
    '    End If
    'End Sub

    'Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
    '    ' Release the mouse events
    '    Me.Capture = False
    'End Sub
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub


End Class
