Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t = LineInput(i).Replace(" ", "").Split(".")
                Dim re As Double = 0
                re += Convert.ToInt32(t(0), 2)
                Dim pt As Integer = -1
                For j = 0 To Len(t(1)) - 1
                    Dim a As Integer = Val(t(1)(j))
                    re += a * 2 ^ pt
                    pt -= 1
                Next
                PrintLine(3, re.ToString)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
End Class
