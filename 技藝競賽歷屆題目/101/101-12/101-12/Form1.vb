Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            solve(i)
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(q As Integer)
        Dim data As String = LineInput(q), ans As String = ""
        Do Until data = "EOF"
            ans = ans & LCase(data) & " "
            data = LineInput(q)
        Loop
        Dim tmp = ans.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
        Dim word, num, result As New ArrayList
        For i = 0 To UBound(tmp)
            If word.IndexOf(tmp(i)) = -1 Then word.Add(tmp(i)) : num.Add(1) Else num(word.IndexOf(tmp(i))) += 1
        Next
        num.Sort()
        result.Add(num(num.Count - 1)) : result.Add(num(num.Count - 2)) : result.Add(num(num.Count - 3))
        PrintLine(3, String.Join(",", result.ToArray))

    End Sub
End Class
