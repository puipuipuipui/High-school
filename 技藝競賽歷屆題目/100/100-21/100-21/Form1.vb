Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To 2
                solve(n, i)
                If j = 1 Then LineInput(i)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(n As Integer, q As Integer)
        Dim map(16, 16) As Integer
        For i = 1 To 15
            Dim a = LineInput(q)
            For j = 1 To 15
                map(i, j) = Val(a(j - 1))
            Next
            map(0, i) = 1 : map(i, 0) = 1 : map(16, i) = 1 : map(i, 16) = 1
        Next
        BFS(map)
        If map(15, 15) <> 0 And map(15, 15) - 1 <= n Then PrintLine(3, UCase(True)) Else PrintLine(3, UCase(False))
    End Sub
    Sub BFS(map(,) As Integer)
        Dim bfsx, bfsy As New Queue
        Dim x% = 1, y% = 1
        Do
            If map(x - 1, y) = 0 Then map(x - 1, y) = map(x, y) + 1 : bfsx.Enqueue(x - 1) : bfsy.Enqueue(y)
            If map(x + 1, y) = 0 Then map(x + 1, y) = map(x, y) + 1 : bfsx.Enqueue(x + 1) : bfsy.Enqueue(y)
            If map(x, y - 1) = 0 Then map(x, y - 1) = map(x, y) + 1 : bfsx.Enqueue(x) : bfsy.Enqueue(y - 1)
            If map(x, y + 1) = 0 Then map(x, y + 1) = map(x, y) + 1 : bfsx.Enqueue(x) : bfsy.Enqueue(y + 1)
            If bfsx.Count = 0 Then Exit Do
            x = bfsx.Dequeue() : y = bfsy.Dequeue()
        Loop

    End Sub
End Class
