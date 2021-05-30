Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i), LineInput(i))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(a As String, b As String)
        Dim data1 = a.Split({" "}, StringSplitOptions.RemoveEmptyEntries), data2 = b.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
        data2(0) = -1 : Dim sum As Integer
        For i = 1 To UBound(data1)
            If Array.IndexOf(data2, data1(i)) > -1 Then sum += 1
        Next
        PrintLine(3, sum.ToString)
    End Sub
End Class
