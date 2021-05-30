Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t = LineInput(i).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
                Dim map(20, 20) As Integer, v(20) As Integer
                For j = 0 To UBound(t)
                    Dim tmp = Array.ConvertAll(t(j).Split(","), Function(x) Int32.Parse(x))
                    map(tmp(0), tmp(1)) = 1 : map(tmp(1), tmp(0)) = 1 : v(tmp(0)) = 1 : v(tmp(1)) = 1
                Next
                dfs(map, v)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub dfs(ByVal map(,) As Integer, ByVal v() As Integer)
        Dim stack As New Stack
        Dim q As Integer = Array.IndexOf(v, 1) : stack.Push(q)
        Dim x As Integer = stack(0), ad As New ArrayList
        Do
            For i = 0 To UBound(v)

            Next

        Loop

    End Sub
End Class
