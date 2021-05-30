Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t = Array.ConvertAll(LineInput(i).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
                Dim h1 As Integer = t(0) * 60 + t(1), h2 As Integer = t(2) * 60 + t(3)
                Dim re As Integer = 0
                If h2 >= h1 Then re = h2 - h1 Else re = (24 * 60 - h1) + h2
                PrintLine(3, re.ToString)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
End Class
