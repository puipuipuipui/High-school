Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t As Integer = LineInput(i)
                solve(t)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(ByVal t As Integer)

        For i = 0 To 100000
            Dim sum As Integer = 0
            Dim tmp As String = i.ToString
            sum += i
            For j = 0 To Len(tmp) - 1
                Dim a As Integer = Val(tmp(j))
                sum += a
            Next
            If sum = t Then PrintLine(3, i.ToString) : Exit Sub
        Next
        PrintLine(3, "0")
    End Sub
End Class
