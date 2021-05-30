Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For k = 1 To n
            Dim q As Integer = LineInput(1)
            Dim x As String = "", y As String = ""
            For i = 1 To q
                Dim t = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
                x &= t(0) : y &= t(1)
            Next
            Dim re As String = "", pt As Integer = 0
            For i = Len(x) - 1 To 0 Step -1
                Dim a As Integer = Val(x(i)), b As Integer = Val(y(i))
                Dim sum As Integer = a + b + pt
                re = (sum Mod 10).ToString & re
                pt = sum \ 10
            Next
            If pt > 0 Then re = pt.ToString & re
            PrintLine(3, re)
        Next

        Close()
    End Sub
End Class
