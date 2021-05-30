Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For j = 1 To n
                Dim A As String = LineInput(i), B As String = LineInput(i)
                Dim C(Len(A), Len(B)) As Integer
                For k = 1 To UBound(C)
                    Dim aa As String = A(k - 1).ToString
                    For q = 1 To UBound(C, 2)
                        Dim bb As String = B(q - 1).ToString
                        If aa = bb Then
                            C(k, q) = C(k - 1, q - 1) + 1
                        ElseIf aa <> bb Then
                            C(k, q) = Math.Max(C(k - 1, q), C(k, q - 1))
                        End If
                    Next
                Next
                PrintLine(3, C(UBound(C), UBound(C, 2)).ToString)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
End Class
