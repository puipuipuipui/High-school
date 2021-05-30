Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            For j = 1 To 4
                solve(LineInput(i))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(t As String)
        Dim tmp = Split(t.Replace(" ", ""), "==")
        If ans(tmp(0)) <> ans(tmp(1)) Then PrintLine(3, UCase(False)) Else PrintLine(3, UCase(True))
    End Sub
    Function ans(tt As String) As Integer
        Dim tp = tt.Replace("+", " +").Replace("-", " -").Replace("*", " * ").Split({" "}, StringSplitOptions.RemoveEmptyEntries)
        Dim tmp = New ArrayList(tp)
        Do Until tmp.IndexOf("*") = -1
            Dim pt As Integer = tmp.IndexOf("*")
            Dim sum% = Val(tmp(pt - 1)) * Val(tmp(pt + 1))
            tmp(pt - 1) = sum : tmp.RemoveAt(pt) : tmp.RemoveAt(pt)
        Loop
        Dim result = Array.ConvertAll(tmp.ToArray, Function(x) Int32.Parse(x))
        Return result.Sum

    End Function
End Class
