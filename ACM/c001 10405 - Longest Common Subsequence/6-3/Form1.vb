Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Do Until EOF(1)
            Dim A As String = LineInput(1), B As String = LineInput(1)
            Dim C(Len(A), Len(B)) As Integer
            For i = 1 To UBound(C)
                For j = 1 To UBound(C, 2)
                    If A(i - 1) = B(j - 1) Then
                        C(i, j) = C(i - 1, j - 1) + 1
                    Else
                        C(i, j) = Math.Max(C(i - 1, j), C(i, j - 1))
                    End If
                Next
            Next
            PrintLine(3, C(UBound(C), UBound(C, 2)).ToString)
        Loop
        Close()
    End Sub
End Class
