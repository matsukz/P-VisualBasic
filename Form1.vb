Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Button1.Enabled = False

        Dim rand As New System.Random()
        Dim arr() As Integer = {0, 0, 0}

        Label1.Text = " " : Label2.Text = " "
        Label3.Text = " " : Label4.Text = ""

        For i = 0 To 2

            arr(i) = rand.Next(1, 8)

        Next i

        If arr(0) = 7 Then
            Label1.ForeColor = Color.Gold
        ElseIf arr(0) Mod 2 = 0 Then
            Label1.ForeColor = Color.Blue
        Else
            Label1.ForeColor = Color.Red
        End If
        Label1.Text = arr(0)

        If arr(2) = 7 Then
            Label3.ForeColor = Color.Gold
        ElseIf arr(2) Mod 2 = 0 Then
            Label3.ForeColor = Color.Blue
        Else
            Label3.ForeColor = Color.Red
        End If
        Label3.Text = arr(2)

        If arr(0) = arr(2) Then Label4.Text = "　リーチ！"

        If arr(1) = 7 Then
            Label2.ForeColor = Color.Gold
        ElseIf arr(1) Mod 2 = 0 Then
            Label2.ForeColor = Color.Blue
        Else
            Label2.ForeColor = Color.Red
        End If
        Label2.Text = arr(1)

        If arr(0) = arr(1) And arr(1) = arr(2) Then
            If arr(0) Mod 2 = 0 Then
                Label4.Text = "大当たり！"
                Label4.ForeColor = Color.Blue
            Else
                Label4.Text = "大当たり！"
                Label4.ForeColor = Color.Red
            End If
        End If

        Button1.Enabled = True

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "7" : Label2.Text = "7"
        Label3.Text = "7" : Label4.Text = ""

        Label1.ForeColor = Color.Gold
        Label2.ForeColor = Color.Gold
        Label3.ForeColor = Color.Gold
        Label4.ForeColor = Color.Black
    End Sub
End Class
