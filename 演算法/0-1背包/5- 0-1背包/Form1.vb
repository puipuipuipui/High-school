Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim n As Integer = 23
        Dim w = {5, 6, 8, 11, 12}, v = {19, 24, 33, 45, 50}
        Dim re(UBound(w), n) As Integer
        Dim max As Integer = -9999999
        For i = 0 To UBound(w)
            For j = UBound(re, 2) To 0 Step -1
                Dim test(UBound(w)) As Boolean
                Dim sum As Integer = j, vsum As Integer = 0
                For k = i To 0 Step -1
                    If test(k) = False Then
                        If sum - w(k) >= 0 Then sum -= w(k) : test(k) = True : vsum += v(k)
                    End If
                Next
                re(i, j) = vsum
                If max <> vsum Then max = Math.Max(max, vsum)
            Next
        Next
        FileOpen(3, "out.txt", 2)
        PrintLine(3, max.ToString)
        'result = max
        Close()
    End Sub
End Class
