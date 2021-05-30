Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            solve(i)
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(q As Integer)
        Dim map(8, 8) As Integer
        For i = 1 To 8
            Dim tmp = Array.ConvertAll(LineInput(q).Replace(" ", "").Split(","), Function(x) Int32.Parse(x))
            For j = 1 To 8
                map(i, j) = tmp(j - 1)
            Next
        Next
        For i = 1 To 4
            Dim mapp = map.Clone
            Dim t = Array.ConvertAll(LineInput(q).Replace(" ", "").Split(","), Function(x) Int32.Parse(x))
            Dim ad As New ArrayList : ad.Add(t(0))
            Dim test As Boolean = False
            For j = 1 To 3
                Dim pt As Integer = ad.Count
                For r = 0 To pt - 1
                    For k = 1 To 8
                        If mapp(ad(r), k) > 0 Then
                            ad.Add(k)
                            If k = t(1) And j = 3 Then test = True
                        End If
                    Next
                Next
                ad.RemoveRange(0, pt)
            Next
            If test Then PrintLine(3, "有路徑") Else PrintLine(3, "沒路徑")
        Next

    End Sub
End Class
