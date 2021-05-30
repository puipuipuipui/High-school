Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Do Until EOF(1)
            Dim t As String = LineInput(1)
            Dim sum As Integer = 0
            Do Until t = t.Replace("  ", " ")
                t = t.Replace("  ", " ") : sum += 1
            Loop
            PrintLine(3, sum.ToString)
        Loop
        Close()
    End Sub
End Class
