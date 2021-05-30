Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(t As Integer)
        Dim two = Convert.ToString(t, 2), sum As Integer = 0
        For i = 0 To Len(two) - 1
            If two(i).ToString = "1" Then sum += 1
        Next
        PrintLine(3, sum.ToString)
    End Sub
End Class
