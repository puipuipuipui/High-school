Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim ad As Integer = Val(LineInput(1))
            Dim t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            Array.Sort(t) : Array.Reverse(t)
            Dim sum As Integer = 0
            For j = 2 To UBound(t) Step 3
                sum += t(j)
            Next
            PrintLine(3, sum.ToString)
        Next
        Close()
    End Sub
End Class
