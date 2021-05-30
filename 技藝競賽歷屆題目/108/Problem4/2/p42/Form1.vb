Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t = Array.ConvertAll(LineInput(i).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
                If t(0) - t(1) < t(1) Then t(1) = t(0) - t(1)
                Dim data(t(1) - 1) As Integer
                For j = 0 To UBound(data)
                    data(j) = t(0) - j
                Next
                For j = 2 To t(1)
                    Dim tmp As Integer = j
                    Do Until tmp = 1
                        For q = 0 To UBound(data)
                            Dim gcds As Integer = gcd(tmp, data(q))
                            If gcds > 1 Then data(q) = data(q) / gcds : tmp /= gcds : Exit For
                        Next
                    Loop
                Next
                Dim re As Integer = 1
                For j = 0 To UBound(data)
                    re *= data(j)
                Next
                PrintLine(3, re.ToString)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Function gcd(ByVal a As Integer, ByVal b As Integer) As Integer
        If b = 0 Then Return a
        Return gcd(b, a Mod b)
    End Function
End Class
