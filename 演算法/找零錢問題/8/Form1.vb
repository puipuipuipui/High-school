Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim sum% = 39
        Dim data = {4, 3, 1}, ans% = 0
        For i = 0 To UBound(data)
            Do
                If sum - data(i) >= 0 Then ans += 1 : sum = sum - data(i) Else Exit Do
            Loop
        Next
        MsgBox(ans)
        Close()
    End Sub
End Class
