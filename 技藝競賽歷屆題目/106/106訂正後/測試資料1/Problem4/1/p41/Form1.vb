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
        Dim q As Integer = Array.IndexOf(v, 1) : stack.Push(q) : v(q) = 0
        Dim x As Integer = stack(0), ad As New ArrayList, tests As Boolean = False
        ad.Add(q)
        Do
            Dim test As Boolean = True
            For i = 0 To UBound(v)
                If map(x, i) = 1 Then
                    map(x, i) = 0 : map(i, x) = 0 : v(i) = 0 : stack.Push(i) : test = False
                    Dim pt As Integer = ad.IndexOf(i)
                    If pt = -1 Then ad.Add(i) Else ad = ad.GetRange(pt, ad.Count - pt) : tests = True : Exit Do
                    Exit For
                End If
            Next
            x = stack(0)
            If stack.Count = 0 Then Exit Do
            If test Then stack.Pop() : x = stack(0) : ad.RemoveAt(ad.Count - 1)
        Loop
        If tests Then
            ad.Sort() : PrintLine(3, String.Join(",", ad.ToArray))
        Else
            Dim pt As Integer = Array.IndexOf(v, 1)
            If pt = -1 Then PrintLine(3, "T") Else PrintLine(3, "F")
        End If
    End Sub
End Class
