Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim da = {13, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7}
        Dim max As Integer = -999999

        For i = 0 To UBound(da)
            Dim data = New ArrayList(da)
            max = Math.Max(max, data(i))
            For j = i + 1 To UBound(da)
                data(j) = Math.Max(data(j), data(j) + data(j - 1))
                max = Math.Max(max, data(j))
            Next
        Next
        MsgBox(max)
        Close()
    End Sub
End Class
