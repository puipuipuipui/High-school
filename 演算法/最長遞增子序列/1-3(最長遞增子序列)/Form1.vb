Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim data = {13, 14, 55, 21, 66, 72, 23, 73, 1, 2, 88, 83, 84, 24, 7}
        Dim tmp = data.Clone : Array.Sort(tmp)
        Dim c(UBound(data) + 1, UBound(data) + 1) As Integer
        For i = 1 To UBound(c)
            For j = 1 To UBound(c, 2)
                If data(i - 1) = tmp(j - 1) Then
                    c(i, j) = c(i - 1, j - 1) + 1
                ElseIf data(i - 1) <> tmp(j - 1) Then
                    c(i, j) = Math.Max(c(i - 1, j), c(i, j - 1))
                End If

            Next
        Next
        Dim result As Integer = c(UBound(c), UBound(c, 2))
        Close()
    End Sub
End Class
