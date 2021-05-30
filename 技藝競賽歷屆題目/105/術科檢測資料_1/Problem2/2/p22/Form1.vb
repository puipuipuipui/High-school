Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For j = 1 To n
                Dim t = LineInput(i).Replace(" ", "").Split(",")
                Dim max As Integer = -9999999
                For k = 0 To UBound(t)
                    For q = k + 1 To UBound(t)
                        Dim a As Integer = gcd(t(k), t(q))
                        max = Math.Max(max, a)
                    Next
                Next
                PrintLine(3, max.ToString)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Function gcd(ByVal x As Integer, ByVal y As Integer) As Integer
        If y = 0 Then Return x
        Return gcd(y, x Mod y)
    End Function
End Class
