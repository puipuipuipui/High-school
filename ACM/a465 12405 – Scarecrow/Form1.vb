Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim q As Integer = LineInput(1)
            Dim t As String = LineInput(1), sum As Integer = 0
            If InStr(t, ".") = 0 Then
                PrintLine(3, "0")
            Else
                Do
                    Do
                        If Len(t) = 0 Then Exit Do
                        If t(0) <> "#" Then Exit Do
                        t = t.Substring(1)
                    Loop
                    If t = "" Then Exit Do
                    If Len(t) >= 3 Then t = t.Substring(3) : sum += 1 Else t = "" : sum += 1
                Loop
                PrintLine(3, sum.ToString)
            End If

        Next

        Close()
    End Sub
End Class
