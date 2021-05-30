Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim data() = {8, 8, 4, 12, -9, -35, 2, 4, 76, 89, 989}
        For i = 0 To UBound(data) - 1
            For j = i + 1 To UBound(data)
                If data(i) > data(j) Then
                    Dim tmp As Integer = data(i)
                    data(i) = data(j)
                    data(j) = tmp
                End If
            Next
        Next

        Close()
    End Sub
End Class
