Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(3, "out.txt", 2)
        Dim data As New ArrayList
        For i = 1 To 1000
            data.Add(i)
        Next
        For i = 1 To 1000
            Dim ad As String = i.ToString, sum As Integer = i
            For j = 0 To Len(ad) - 1
                Dim a As Integer = Val(ad(j))
                sum += a
            Next
            data.Remove(sum)
        Next
        For i = 0 To data.Count - 1
            PrintLine(3, data(i).ToString)
        Next
        Close()
    End Sub
End Class
