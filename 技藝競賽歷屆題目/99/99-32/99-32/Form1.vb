Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            For j = 1 To 4
                PrintLine(3, solve(LineInput(i)))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Function solve(t As String) As String
        Dim tmp = t.Substring(InStr(t, "民國") + 1).Replace(" ", "").Replace("年", " 年 ").Replace("月", " 月 ").Replace("日", " 日 ").Split(" ")
        If tmp(1) <> "年" Or tmp(3) <> "月" Or tmp(5) <> "日" Or Len(tmp(0)) > 3 Or Len(tmp(1)) > 2 Or Len(tmp(2)) > 2 Then Return "不符合"
        Dim y% = Val(tmp(0)), m% = Val(tmp(2)), d% = Val(tmp(4))
        If Not (0 < y And y < 1000) Or Not (0 < m And m < 13) Then Return "不符合"
        Dim day = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31}
        If (y + 1991) Mod 400 = 0 Or (y + 1991) Mod 4 = 0 And (y + 1991) Mod 100 <> 0 Then day(1) = 29
        If day(m - 1) < d Then Return "不符合"
        Return "符合"
    End Function
End Class
