Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
        Dim v(t(0)) As Integer
        For i = 1 To UBound(v)
            v(i) = 999999
        Next
        v(1) = 0
        Dim data As New ArrayList
        For i = 1 To t(1)
            data.Add(LineInput(1))
        Next
        For k = 1 To t(0) - 1
            Dim check As String = String.Join(" ", v)
            For i = 0 To data.Count - 1
                Dim q As String = data(i)
                Dim a = q.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
                Dim tmp = Array.ConvertAll(a, Function(x) Int32.Parse(x))
                Dim ad As Integer = v(tmp(0)) + tmp(2)
                If ad < v(tmp(1)) Then v(tmp(1)) = ad
            Next
            If String.Join(" ", v) = check Then Exit For
        Next
        Dim re = New ArrayList(v) : re.RemoveAt(0)
        PrintLine(3, String.Join(" ", re.ToArray))
        Close()
    End Sub
End Class
