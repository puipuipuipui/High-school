Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t = Array.ConvertAll(LineInput(i).Replace(" ", "").Split(","), Function(x) Int32.Parse(x))
                Dim re As String = "1"
                For j = 1 To t(1)
                    solve(re, t(0))
                Next
                PrintLine(3, Len(re).ToString)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(ByRef t As String, ByVal n As Integer)
        Dim re As String = "", pt As Integer = 0
        For i = Len(t) - 1 To 0 Step -1
            Dim a As Integer = Val(t(i))
            Dim sum As Integer = a * n + pt
            re = (sum Mod 10).ToString & re
            pt = sum \ 10
        Next
        If pt > 0 Then re = pt.ToString & re
        t = re
    End Sub
End Class
