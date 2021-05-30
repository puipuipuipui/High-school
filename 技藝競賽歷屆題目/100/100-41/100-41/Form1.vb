Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            solve(n, i)
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(n As Integer, q As Integer)
        Dim money = {50, 20, 10, 5, 1}, num = {0, 0, 0, 0, 0}
        For i = 1 To n
            Dim price% = 100 - LineInput(q)
            For j = 0 To 4
                num(j) += price \ money(j) : price = price Mod money(j)
            Next
        Next
        Dim ans As New ArrayList
        For i = 0 To UBound(money)
            ans.Add(money(i) & "," & num(i))
        Next
        PrintLine(3, String.Join(" ", ans.ToArray))
    End Sub
End Class
