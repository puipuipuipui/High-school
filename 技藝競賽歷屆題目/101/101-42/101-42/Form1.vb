Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i).Split({" "}, StringSplitOptions.RemoveEmptyEntries))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(t() As String)
        Dim tmp = Array.ConvertAll(t, Function(x) Int32.Parse(x))
        For i = 0 To UBound(tmp)
            Dim n As Integer = tmp(i) Mod 13
            If n = 0 Or n > 10 Then tmp(i) = 10 Else tmp(i) = n
        Next
        Dim sum As Integer = tmp.Sum
        If sum > 21 Then PrintLine(3, "F") : Exit Sub
        If Array.IndexOf(tmp, 1) > -1 Then
            If (sum + 10) <= 21 Then PrintLine(3, (sum + 10).ToString) : Exit Sub
        End If
        PrintLine(3, sum.ToString)
    End Sub
End Class
