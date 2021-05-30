Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i), i)
                If j <> n Then Dim tmp = LineInput(i)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(n As Integer, q As Integer)
        Dim data, inside, L As New ArrayList
        Dim i As Integer
        For i = 1 To n
            data.Add(LineInput(q))
        Next
        For i = 0 To n - 1
            Dim org$ = data(i)
            Dim t = org.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            Dim map(60, 60) As Integer, dot(60) As Integer
            For j = 0 To UBound(t)
                Dim tmp = t(j).Replace(" ", "").Split("-")
                map(tmp(0), tmp(1)) = 1 : map(tmp(1), tmp(0)) = 1 : dot(tmp(0)) = 1 : dot(tmp(1)) = 1
            Next
            '樹
            Dim first = Array.ConvertAll(t(0).Replace(" ", "").Split("-"), Function(x) Int32.Parse(x))
            BFS(map, dot, first)
            If Array.IndexOf(dot, 1) > -1 Then PrintLine(3, "F") : Exit Sub
            '邊
            For j = 0 To UBound(t)
                Dim x As String = t(j).Split("-")(0), y As String = t(j).Split("-")(1)
                If L.IndexOf(x & "," & y) = -1 Then L.Add(x & "," & y) : L.Add(y & "," & x) Else PrintLine(3, "F") : Exit Sub
            Next
            '內
            For j = 0 To UBound(dot)
                If dot(j) = 2 Then
                    Dim sum% = 0, test As Boolean = False
                    Dim ori = org.Replace("-", " ").Split({" "}, StringSplitOptions.RemoveEmptyEntries)
                    Dim pt As Integer = -1
                    Do
                        pt = Array.IndexOf(ori, j.ToString, pt + 1)
                        If pt > -1 Then sum += 1 Else Exit Do
                        If sum > 1 Then test = True : Exit Do
                    Loop
                    If test Then
                        If inside.IndexOf(j) > -1 Then PrintLine(3, "F") : Exit Sub Else inside.Add(j)
                    End If
                End If
            Next
        Next
        PrintLine(3, "T")
    End Sub
    Sub BFS(map(,) As Integer, dot() As Integer, t() As Integer)
        Dim bx As New Queue
        Dim x As Integer = t(0)
        Do
            For i = 0 To 60
                If map(x, i) = 1 Then map(x, i) = 2 : map(i, x) = 2 : dot(x) = 2 : dot(i) = 2 : bx.Enqueue(i)
            Next
            If bx.Count = 0 Then Exit Do
            x = bx.Dequeue
        Loop

    End Sub

End Class
