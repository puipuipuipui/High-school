Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t As Integer = Val(LineInput(1))
        Do Until t < 0
            Dim re As String = ""
            Do Until t = 0
                re = (t Mod 3) & re
                t = t \ 3
            Loop
            If re = "" Then re = "0"
            PrintLine(3, re)
            t = Val(LineInput(1))
        Loop

        Close()
    End Sub
End Class
