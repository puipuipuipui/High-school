Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
        Do Until t(0) = -1
            Array.Sort(t)
            Dim summ As Integer = t(0) + 1 + (99 + t(1) * -1)
            Dim sum As Integer = t(1) - t(0)
            Dim min As Integer = 999999999
            If sum <> summ Then min = Math.Min(summ, sum) Else min = sum
            PrintLine(3, min.ToString)
            t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
        Loop
        Close()
    End Sub
End Class
