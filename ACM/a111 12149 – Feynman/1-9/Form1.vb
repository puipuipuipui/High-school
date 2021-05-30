Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t As Integer = LineInput(1)
        Do Until t = 0
            Dim sum As Integer = 0
            For i = 1 To t
                sum += i ^ 2
            Next
            PrintLine(3, sum.ToString)
            t = LineInput(1)
        Loop

        Close()
    End Sub
End Class
