Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i), LineInput(i).Split(","))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(n As Integer, t() As String)
        Dim tmp = Array.ConvertAll(t, Function(x) Int32.Parse(x))
        Dim sum% = 0
        For i = 0 To UBound(tmp) - 1
            Dim ad As Integer = tmp(i) - tmp(i + 1), cost = 0
            If ad > 0 Then cost = 10 Else cost = 20
            sum += Math.Abs(ad * cost)
        Next
        PrintLine(3, sum.ToString)
    End Sub
End Class
