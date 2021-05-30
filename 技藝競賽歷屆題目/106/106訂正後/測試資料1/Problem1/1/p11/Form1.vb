Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t = LCase(LineInput(i)).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
                Dim sum As Integer = 0
                For j = 0 To UBound(t)
                    If InStr(t(j), "s") > 0 Then sum += 1
                Next
                PrintLine(3, sum.ToString)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
End Class
