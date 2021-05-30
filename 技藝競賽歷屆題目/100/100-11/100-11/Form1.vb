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
        Dim tmp = t.Replace(" ", "").Replace("==", "=").Split("=")
        If summ(tmp(0)) <> summ(tmp(1)) Then PrintLine(3, UCase(False)) Else PrintLine(3, UCase(True))
    End Sub
    Function summ(tmp As String) As Integer
        Dim re = tmp.Replace("+", " +").Replace("-", " -")
        Dim result = Array.ConvertAll(re.Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
        Return result.Sum
    End Function
End Class
