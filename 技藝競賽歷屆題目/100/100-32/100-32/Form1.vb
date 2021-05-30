Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(t As String)
        Dim tmp = Convert.ToString(Convert.ToInt32(t, 16), 2)
        Do Until Len(tmp) = 16
            tmp = "0" & tmp
        Loop
        Dim check = {3, 5, 6, 7, 9, 10, 11, 12, 13, 14, 15, 17, 18, 19, 20, 21}
        Dim ad As New ArrayList
        For i = 0 To Len(tmp) - 1
            If tmp(i).ToString = "1" Then ad.Add(check(i))
        Next
        Dim re(4) As Integer
        For i = 0 To ad.Count - 1
            Dim tt = Convert.ToString(ad(i), 2)
            Do Until Len(tt) = 5
                tt = "0" & tt
            Loop
            For j = 0 To 4
                Dim a As Integer = Val(tt(j))
                re(j) += a
            Next
        Next
        For i = 0 To UBound(re)
            re(i) = re(i) Mod 2
        Next
        Array.Reverse(re)
        PrintLine(3, String.Join("", re))
    End Sub
End Class
