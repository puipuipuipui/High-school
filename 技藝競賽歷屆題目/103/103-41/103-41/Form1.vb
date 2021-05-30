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
        Dim two = "00,01,100,101,1100,1101,11100,11101,111100,111101".Split(",")
        Dim num = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}, ad As String = ""
        For i = 0 To UBound(two)
            Dim pt = InStr(t, two(i))
            If pt = 1 Then ad &= num(i).ToString : t = t.Substring(Len(two(i))) : i = -1
            If Len(t) = 0 Then Exit For
        Next
        Dim check As String = "DEFGHIJKLMNOPQRSTUVWXYZABC"
        Dim ans As Integer = Val(ad)
        PrintLine(3, check(ans - 1).ToString)

    End Sub
End Class
