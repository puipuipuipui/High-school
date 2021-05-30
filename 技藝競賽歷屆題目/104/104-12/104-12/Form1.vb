Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            Dim tmp = LineInput(i).Split(",")
            For j = 1 To n
                solve(tmp, LineInput(i).Split(","))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(ans() As String, t() As String)
        Dim sum As Integer = 0
        For i = 0 To UBound(t)
            If Array.IndexOf(ans, t(i)) > -1 Then sum += 1
        Next
        Dim result(5) As Integer
        If sum >= 2 Then result(sum) = 6 - sum : result(sum - 1) = sum
        Dim re = New ArrayList(result) : re.RemoveAt(0) : re.RemoveAt(0)
        PrintLine(3, String.Join(",", re.ToArray))
    End Sub
End Class
