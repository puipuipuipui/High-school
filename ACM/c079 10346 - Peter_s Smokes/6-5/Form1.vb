Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Do Until EOF(1)
            Dim t = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            Dim n As Integer = Val(t(0)), k As Integer = Val(t(1))
            Dim sum As Integer = n
            Do
                If n \ k = 0 Then Exit Do
                sum += n \ k
                n = n \ k + n Mod k
            Loop
            PrintLine(3, sum.ToString)
        Loop

        Close()
    End Sub
End Class
