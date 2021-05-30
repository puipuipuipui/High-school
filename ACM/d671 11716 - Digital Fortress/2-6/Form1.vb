Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim t As String = LineInput(1)
            Dim q As Integer = Int(Math.Sqrt(Len(t)) * 10)
            If q Mod 10 <> 0 Then
                PrintLine(3, "INVALID")
            Else
                q = q \ 10
                Dim data(q, q) As String
                Dim pt As Integer = 0
                For j = 1 To UBound(data)
                    For k = 1 To UBound(data, 2)
                        data(j, k) = t(pt).ToString : pt += 1
                    Next
                Next
                Dim re As String = ""
                For j = 1 To UBound(data)
                    For k = 1 To UBound(data, 2)
                        re &= data(k, j)
                    Next
                Next
                PrintLine(3, re)
            End If
        Next

        Close()
    End Sub
End Class
