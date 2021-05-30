Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i).Replace(" ", "").Split(","))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(t() As String)
        Dim re, result As New ArrayList
        permutation(t(0), re, result)
        Dim ans As Integer
        GCD(result(Val(t(1) - 1)), result(Val(t(2) - 1)), ans)
        PrintLine(3, ans.ToString)
    End Sub
    Sub permutation(t As String, re As ArrayList, result As ArrayList)
        If re.Count = Len(t) Then
            result.Add(String.Join("", re.ToArray))
        Else
            For i = 0 To Len(t) - 1
                If re.IndexOf(t(i).ToString) = -1 Then re.Add(t(i).ToString) : permutation(t, re, result) : re.RemoveAt(re.Count - 1)
            Next
        End If
    End Sub
    Sub GCD(a As Integer, b As Integer, ByRef ans%)
        If b = 0 Then ans = a : Exit Sub Else GCD(b, a Mod b, ans)
    End Sub

End Class
