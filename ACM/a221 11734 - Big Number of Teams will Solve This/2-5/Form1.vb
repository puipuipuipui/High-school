Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim re As String = LineInput(1)
            Dim check As String = LineInput(1)
            If re = check Then
                PrintLine(3, "Yes")
            Else
                If re.Replace(" ", "") <> check.Replace(" ", "") Then PrintLine(3, "Wrong Answer") Else PrintLine(3, "Output Format Error")
            End If
        Next

        Close()
    End Sub
End Class
