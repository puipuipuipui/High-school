Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim t As String = LineInput(1).Replace(" ", "")
            Do Until t = t.Replace("()", "").Replace("[]", "")
                t = t.Replace("()", "").Replace("[]", "")
            Loop
            If t = "" Then PrintLine(3, "Yes") Else PrintLine(3, "No")
        Next

        Close()
    End Sub
End Class
