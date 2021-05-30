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
        t = t.Substring(InStr(t, "國")) : If InStr(t, "月") > InStr(t, "日") Or InStr(t, "年") > InStr(t, "月") Then Return "不符合"
        t = Mid(t, 1, InStr(t, "日") - 1)
        Dim tmp = t.Replace("月", "*").Replace("年", "*").Replace(" ", "").Split("*")
        If Len(tmp(0)) > 3 Or Len(tmp(1)) > 2 Or Len(tmp(2)) > 2 Then Return "不符合"
        Dim tmpp = Array.ConvertAll(tmp, Function(x) Int32.Parse(x))
        If tmpp(1) > 12 Then Return "不符合"
        Dim day() As String = {1, 3, 5, 7, 8, 10, 12}
        If Array.IndexOf(day, tmp(1)) > -1 Then
            If tmp(2) > 31 Then Return "不符合"
        Else
            If tmp(2) > 30 Then Return "不符合"
        End If
        If tmp(1) = 2 Then
            Dim year = tmp(0) + 1991, ad As Integer
            If year Mod 400 = 0 Or year Mod 4 = 0 And year Mod 100 <> 0 Then ad = 29 Else ad = 28
            If tmp(2) > ad Then Return "不符合"
        End If
        Return "符合"
    End Function
End Class
