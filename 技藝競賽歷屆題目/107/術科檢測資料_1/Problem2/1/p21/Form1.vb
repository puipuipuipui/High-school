Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t As String = LineInput(i)
                Dim sum As Integer = 0
                Do
                    sum = 0
                    For j = 0 To Len(t) - 1
                        Dim a As Integer = Val(t(j))
                        sum += a ^ 2
                    Next
                    If sum = 1 Then PrintLine(3, "T") : Exit Do
                    If Len(sum.ToString) = 1 Then PrintLine(3, "F") : Exit Do
                    t = sum.ToString
                Loop

            Next
            PrintLine(3)
        Next
        Close()
    End Sub
End Class
