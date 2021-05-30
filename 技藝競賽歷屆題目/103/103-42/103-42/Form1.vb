Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(Array.ConvertAll(LineInput(i).Split(","), Function(x) Int32.Parse(x)), i)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(t() As Integer, q As Integer)
        Dim father(t(0) - 1, t(1) - 1) As Integer
        For i = 0 To t(0) - 1
            Dim tmp = Array.ConvertAll(LineInput(q).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            For j = 0 To t(1) - 1
                father(i, j) = tmp(j + 1)
            Next
        Next
        Dim result(t(1) - 1) As Integer
        For i = 0 To t(1) - 1
            Dim sum& = 0, pt As Integer = t(2)
            Do
                If father(pt, i) = 999 Then Exit Do
                pt = father(pt, i) : sum += 1
            Loop
            result(i) = sum
        Next
        PrintLine(3, String.Join(",", result))
    End Sub
End Class
