Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            Dim v(n) As Integer
            Dim father, son As New ArrayList
            For k = 1 To n
                Dim t = Array.ConvertAll(LineInput(i).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
                For q = 1 To Val(t(0))
                    father.Add(k) : son.Add(t(q))
                Next
            Next
            solve(father, son, v)

            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(ByVal father As ArrayList, ByVal son As ArrayList, ByVal v() As Integer)
        Dim r As Integer = 0
        For i = 1 To UBound(v)
            If son.IndexOf(i) = -1 Then PrintLine(3, i.ToString) : r = i : Exit For
        Next
        dfs(father, son, v, r)

    End Sub
    Sub dfs(ByVal father As ArrayList, ByVal son As ArrayList, ByVal v() As Integer, ByVal r As Integer)
        Dim stack As New Stack : stack.Push(r) : v(r) = 1
        Dim sum As Integer = 0, max As Integer = -99999, pts As Integer = 0
        Do
            Dim test As Boolean = True
            Do
                Dim pt As Integer = father.IndexOf(r, pts)
                If pt > -1 Then
                    If v(son(pt)) = 0 Then
                        sum += 1 : v(son(pt)) = 1 : stack.Push(son(pt)) : test = False : Exit Do
                    Else
                        pts = pt + 1
                    End If
                Else
                    Exit Do
                End If
            Loop
            If stack.Count = 0 Then Exit Do
            If test Then stack.Pop() : r = stack(0) : max = Math.Max(max, sum) : sum -= 1 Else r = son(father.IndexOf(r, pts))
        Loop
        PrintLine(3, (max + 1).ToString)
    End Sub
End Class
