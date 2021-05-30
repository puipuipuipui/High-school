Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t As Integer = LineInput(1)
        Do Until t = -1
            Dim alls As Integer = all(t), boys As Integer = all(t - 1)
            PrintLine(3, boys.ToString & " " & alls.ToString)
            t = LineInput(1)
        Loop
        Close()
    End Sub
    Function all(n As Integer)
        If n < 0 Then Return 0
        If n = 0 Then Return 1
        If n = 1 Then Return 2
        Return all(n - 1) + all(n - 2) + 1
    End Function

End Class
