Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Do Until EOF(1)
            Dim t As Integer = Val(LineInput(1))
            Dim pt As Integer = 0, sum As Integer = 0
            Do
                Dim ad As Integer = t + pt
                pt = ad Mod 3 : sum += t : t = ad \ 3
                If ad = 2 Then sum += 1 : Exit Do Else If ad = 0 Or ad = 1 Then Exit Do
            Loop
            PrintLine(3, sum.ToString)

        Loop
        Close()
    End Sub
End Class
