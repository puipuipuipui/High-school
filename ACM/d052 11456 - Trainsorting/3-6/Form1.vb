Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim q As Integer = LineInput(1)
            If q = 0 Then
                PrintLine(3, "0")
            ElseIf q = 1 Then
                LineInput(1)
                PrintLine(3, "1")
            Else
                Dim data, lsum, hsum As New ArrayList
                For k = 1 To q
                    Dim ad As Integer = Val(LineInput(1))
                    data.Add(ad) : lsum.Add(0) : hsum.Add(0)
                Next
                For j = data.Count - 1 To 0 Step -1
                    Dim max As Integer = 0, maxs As Integer = 0
                    For k = j + 1 To data.Count - 1
                        If data(j) > data(k) Then max = Math.Max(max, lsum(k))
                        If data(j) < data(k) Then maxs = Math.Max(maxs, hsum(k))
                    Next
                    lsum(j) += max + 1 : hsum(j) += maxs + 1
                Next
                Dim remax As Integer = 0
                For j = 0 To lsum.Count - 1
                    remax = Math.Max(remax, lsum(j) + hsum(j))
                Next
                PrintLine(3, (remax - 1).ToString)
            End If
        Next
        Close()
    End Sub
End Class
