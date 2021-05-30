Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim t = New ArrayList(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries))
            Dim q As Integer = Val(t(0)) : t.RemoveAt(0)
            Dim tmp = Array.ConvertAll(t.ToArray, Function(x) Int32.Parse(x))
            Array.Sort(tmp)
            Dim ad As Integer = tmp.Length
            If ad Mod 2 = 1 Then ad = tmp(ad \ 2) Else ad = (tmp(ad / 2) + tmp(ad / 2 - 1)) \ 2
            Dim sum As Integer = 0
            For j = 0 To UBound(tmp)
                sum += Math.Abs(tmp(j) - ad)
            Next
            PrintLine(3, sum.ToString)
        Next

        Close()
    End Sub
End Class
