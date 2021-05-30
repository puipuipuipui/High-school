Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t As Integer = LineInput(1)
        Do Until t = 0
            Dim re As Integer = 0
            Dim ad As Integer = 4 * t - 3
            For i = 1 To (2 * t - 1)
                Dim pt As Integer = 2 * i - 1
                If ad Mod pt = 0 Then
                    If pt Mod 2 = 1 And (ad / pt) Mod 2 = 1 Then re += 1
                End If
            Next
            PrintLine(3, t.ToString & " " & re.ToString)
            t = LineInput(1)
        Loop


        Close()
    End Sub
End Class
