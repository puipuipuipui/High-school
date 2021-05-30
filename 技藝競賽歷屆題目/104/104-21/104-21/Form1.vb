Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i).Split(","))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(t() As String)
        Dim re, result As New ArrayList
        permutation(re, result, t(0))
        result.Sort()
        Dim a As Integer = Val(result(Val(t(1)) - 1)), b As Integer = Val(result(Val(t(2)) - 1))
        Dim sum As Integer = a + b
        PrintLine(3, sum.ToString)
    End Sub
    Sub permutation(re As ArrayList, result As ArrayList, t As String)
        If re.Count = Len(t) Then
            result.Add(String.Join("", re.ToArray))
        Else
            For i = 0 To Len(t) - 1
                If re.IndexOf(t(i).ToString) = -1 Then
                    re.Add(t(i).ToString)
                    permutation(re, result, t)
                    re.RemoveAt(re.Count - 1)
                End If
            Next
        End If
    End Sub
End Class
