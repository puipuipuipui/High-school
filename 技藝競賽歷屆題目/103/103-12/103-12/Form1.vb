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
        Dim tmp = Array.ConvertAll(t, Function(x) Int32.Parse(x))
        Dim a, b, c, d, e, f As Integer
        a = 1 : b = 1 : c = tmp(0) : d = tmp(1) : e = tmp(2) : f = tmp(3)
        Dim xx, yy As Integer
        xx = (e * c - b * f) / (a * e - b * d)
        yy = (a * f - d * c) / (a * e - b * d)
        PrintLine(3, xx.ToString & "," & yy.ToString)

    End Sub
End Class
