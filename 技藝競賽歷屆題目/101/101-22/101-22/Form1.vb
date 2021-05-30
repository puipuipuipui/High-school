Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(n As String)
        Dim t = n.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
        Dim map(20, 20) As Integer, dot(20) As Integer
        For i = 0 To UBound(t)
            Dim tt = t(i).Replace(" ", "").Split(",")
            map(tt(0), tt(1)) = 1 : dot(tt(0)) = 1 : dot(tt(1)) = 1
        Next
        map(0, 0) = 2
        If dot.Sum <> UBound(t) + 1 Then PrintLine(3, "F") : Exit Sub
        BFS(map, dot)
        If Array.IndexOf(dot, 1) > -1 Then PrintLine(3, "F") : Exit Sub
        Dim pt As Integer = 0, sum = 0, ans = 0
        Dim tmp = Array.ConvertAll(n.Replace(",", " ").Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
        For i = 0 To 20
            If dot(i) = 2 Then
                sum = 0 : pt = 0
                Do
                    If Array.IndexOf(tmp, i, pt) = -1 Then Exit Do
                    pt = Array.IndexOf(tmp, i, pt) + 1
                    sum += 1
                Loop
                If sum = 1 Then ans += 1
            End If
        Next
        PrintLine(3, ans.ToString)

    End Sub
    Sub BFS(map(,) As Integer, dot() As Integer)
        Dim bx As New Queue
        Dim x As Integer = 0

        For i = 0 To 20
            For j = 1 To 20
                If map(x, j) = 1 Then map(x, j) = 2 : bx.Enqueue(j) : dot(x) = 2 : dot(j) = 2
                If map(j, x) = 1 Then map(j, x) = 2 : bx.Enqueue(j) : dot(x) = 2 : dot(j) = 2
            Next
            If bx.Count = 0 Then Exit Sub
            x = bx.Dequeue
        Next

    End Sub
End Class
