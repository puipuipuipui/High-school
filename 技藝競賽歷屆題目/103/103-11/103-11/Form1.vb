Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i).Replace(" ", "").Split(","))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(t() As String)
        Dim tmp = Array.ConvertAll(t, Function(x) Int32.Parse(x))
        If tmp(1) - tmp(0) <> 2 Then PrintLine(3, "N") : Exit Sub
        If judge(tmp(0)) And judge(tmp(1)) Then PrintLine(3, "Y") Else PrintLine(3, "N")
    End Sub
    Function judge(n As Integer) As Boolean
        If n = 2 Then Return True
        Dim test As Boolean = True
        For i = 2 To n - 1
            If i ^ 2 > n Then Exit For
            If n Mod i = 0 Then test = False : Exit For
        Next
        Return test
    End Function
End Class
