Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim data1 = "GCCCTAGCG", data2 = "GCGCAATG"
        Dim C(Len(data1), Len(data2)) As Integer

        For i = 1 To UBound(C)
            For j = 1 To UBound(C, 2)
                If data1(i - 1) = data2(j - 1) Then C(i, j) = C(i - 1, j - 1) + 1 Else C(i, j) = Math.Max(C(i - 1, j), C(i, j - 1))
            Next
        Next
        MsgBox(C(Len(data1), Len(data2)))
        Close()
    End Sub
End Class
