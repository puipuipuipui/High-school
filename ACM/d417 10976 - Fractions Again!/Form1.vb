Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Do Until EOF(1)
            Dim k As Integer = LineInput(1)
            Dim sum As Integer = 0
            For i = 1 To 40
                For j = i To 10000
                    If k * (i + j) = (i * j) Then sum += 1
                Next
            Next
            PrintLine(3, sum.ToString)
        Loop
        Close()
    End Sub
End Class
