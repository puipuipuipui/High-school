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
        Dim pt As Integer = tmp(0)
        For i = 1 To UBound(tmp)
            pt = GCD(pt, tmp(i))
        Next
        PrintLine(3, pt.ToString)
    End Sub
    Function GCD(a As Integer, b As Integer) As Integer
        If b = 0 Then Return a
        Return GCD(b, a Mod b)
    End Function
End Class
