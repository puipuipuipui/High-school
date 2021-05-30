Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            solve(LineInput(i), i)
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(n As Integer, q%)
        Dim map(16, 16) As Integer
        For i = 1 To 15
            Dim a As String = LineInput(q)
            For j = 1 To 15
                map(i, j) = Val(a(j - 1))
            Next
            map(0, i) = 1 : map(i, 0) = 1 : map(16, i) = 1 : map(i, 16) = 1
        Next
        Dim map2 = map.Clone
        LineInput(q) : BFS(map, q, n)
        LineInput(q) : BFS(map2, q, n)


    End Sub
    Sub BFS(map(,) As Integer, q As Integer, n As Integer)
        Dim star = LineInput(q).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
        Dim endd = LineInput(q).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
        Dim bx, by As New Queue
        Dim x% = star(0), y% = star(1)
        Do
            If map(x + 1, y) = 0 Then map(x + 1, y) = map(x, y) + 1 : bx.Enqueue(x + 1) : by.Enqueue(y)
            If map(x, y + 1) = 0 Then map(x, y + 1) = map(x, y) + 1 : bx.Enqueue(x) : by.Enqueue(y + 1)
            If map(x - 1, y) = 0 Then map(x - 1, y) = map(x, y) + 1 : bx.Enqueue(x - 1) : by.Enqueue(y)
            If map(x, y - 1) = 0 Then map(x, y - 1) = map(x, y) + 1 : bx.Enqueue(x) : by.Enqueue(y - 1)
            If bx.Count = 0 Then Exit Do
            x = bx.Dequeue : y = by.Dequeue
        Loop

        If map(endd(0), endd(1)) <> 0 And map(endd(0), endd(1)) - 2 <= n Then PrintLine(3, UCase(True)) Else PrintLine(3, UCase(False))
    End Sub
End Class
