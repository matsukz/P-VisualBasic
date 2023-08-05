Imports System.Threading.Tasks
Public Class Form1

    Dim roulette As Integer = 0
    Dim rcnt As Integer = 0
    Dim rand As New System.Random()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 各項目の初期化
    End Sub
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False

        ' --回転数--
        Dim cnt As Integer
        cnt = Val(Lab_cnt.Text)
        Lab_cnt.Text = cnt + 1
        ' ----------

        ' --結果の計算--
        Dim arr() As Integer = {0, 0, 0}
        Lab_A0.Text = " " : Lab_A1.Text = " "
        Lab_A2.Text = " " : Lab_st.Text = ""

        For i = 0 To 2

            arr(i) = rand.Next(1, 8)

        Next i
        ' --------------

        ' --デバッグで結果操作--
        ' arr = {1, 1, 1}
        ' ----------------------

        ' --天井--
        If Val(Lab_cnt.Text) Mod 100 = 0 Then
            If ToolStrip_100.Checked = True Then
                roulette = rand.Next(1, 8)
                For m = 0 To 2
                    arr(m) = roulette
                Next m
            End If
        End If
        ' --------

        ' --デバッグログ--
        Debug.Write(Lab_cnt.Text & "回転：")
        Debug.Write(String.Join(",", arr))
        Debug.Write(" " & ToolStrip_100.Checked)
        If arr(0) = arr(2) Then
            If arr(0) = arr(1) Then
                Debug.Write(" 当たり")
            Else
                Debug.Write(" リーチ")
            End If
        Else
            End If
        Debug.WriteLine("")
        ' ----------------

        ' --左リール決定--
        Await A0()
        If arr(0) = 7 Then
            Lab_A0.ForeColor = Color.Gold
        ElseIf arr(0) Mod 2 = 0 Then
            Lab_A0.ForeColor = Color.Blue
        Else
            Lab_A0.ForeColor = Color.Red
        End If
        Lab_A0.Text = arr(0)
        Await Task.Delay(1000)
        ' ----------------

        ' --右リール決定--
        Await A2()
        If arr(2) = 7 Then
            Lab_A2.ForeColor = Color.Gold
        ElseIf arr(2) Mod 2 = 0 Then
            Lab_A2.ForeColor = Color.Blue
        Else
            Lab_A2.ForeColor = Color.Red
        End If
        Lab_A2.Text = arr(2)
        ' ----------------

        ' --リーチ判定--
        Await Task.Delay(500)
        If arr(0) = arr(2) Then
            If arr(0) Mod 2 = 0 Then
                Lab_st.ForeColor = Color.Blue
            Else
                Lab_st.ForeColor = Color.Red
            End If
            Lab_st.Text = "　リーチ！"
            Await Task.Delay(1000)
            rcnt = 39
        Else
            rcnt = 14
        End If

        ' --------------

        ' --中リール決定--
        Await A1()
        If arr(1) = 7 Then
            Lab_A1.ForeColor = Color.Gold
        ElseIf arr(1) Mod 2 = 0 Then
            Lab_A1.ForeColor = Color.Blue
        Else
            Lab_A1.ForeColor = Color.Red
        End If
        Lab_A1.Text = arr(1)
        ' ----------------

        ' --当選判定--
        If Lab_st.Text = "　リーチ！" Then
            If arr(0) = arr(1) Then
                If arr(0) Mod 2 = 0 Then
                    Lab_st.ForeColor = Color.Blue
                    Lab_st.Text = "大当たり！"

                Else
                    Lab_st.ForeColor = Color.Red
                    Lab_st.Text = "大当たり！"

                End If
            Else
                Lab_st.ForeColor = Color.Black
                Lab_st.Text = "　はずれ！"
            End If
        Else
        End If
        ' --------------

        Button1.Enabled = True

    End Sub

    Private Async Function A0() As Task

        For j = 0 To 14

            roulette = rand.Next(1, 8)

            If roulette = 7 Then
                Lab_A0.ForeColor = Color.Gold
            ElseIf roulette Mod 2 = 0 Then
                Lab_A0.ForeColor = Color.Blue
            Else
                Lab_A0.ForeColor = Color.Red
            End If

            Lab_A0.Text = roulette.ToString()
            Await Task.Delay(50)

        Next j

    End Function

    Private Async Function A1() As Task

        For j = 0 To rcnt

            roulette = rand.Next(1, 8)

            If roulette = 7 Then
                Lab_A1.ForeColor = Color.Gold
            ElseIf roulette Mod 2 = 0 Then
                Lab_A1.ForeColor = Color.Blue
            Else
                Lab_A1.ForeColor = Color.Red
            End If

            Lab_A1.Text = roulette.ToString()
            Await Task.Delay(50)

        Next j

    End Function

    Private Async Function A2() As Task

        For j = 0 To 14

            roulette = rand.Next(1, 8)

            If roulette = 7 Then
                Lab_A2.ForeColor = Color.Gold
            ElseIf roulette Mod 2 = 0 Then
                Lab_A2.ForeColor = Color.Blue
            Else
                Lab_A2.ForeColor = Color.Red
            End If

            Lab_A2.Text = roulette.ToString()
            Await Task.Delay(50)

        Next j

    End Function

    Private Sub ToolStrip_100_Click(sender As Object, e As EventArgs) Handles ToolStrip_100.Click
        ToolStrip_100.Checked = Not ToolStrip_100.Checked
    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        End
    End Sub
End Class
