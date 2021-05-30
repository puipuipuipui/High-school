Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For j = 1 To n
                solve(LineInput(i).Split({" "}, StringSplitOptions.RemoveEmptyEntries))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(ByVal t() As String)
        Dim cost(UBound(t)) As Integer
        Dim data(UBound(t)) As String, dot As New ArrayList, boss As New ArrayList
        For i = 0 To UBound(t)
            cost(i) = Val(t(i).Substring(4))
            data(i) = Mid(t(i), 1, 3)
            Dim tt = data(i).Split(",")
            If dot.IndexOf(tt(0)) = -1 Then dot.Add(tt(0)) : boss.Add(tt(0))
            If dot.IndexOf(tt(1)) = -1 Then dot.Add(tt(1)) : boss.Add(tt(1))
        Next
        Array.Sort(cost, data)
        Dim sum As Integer = 0
        For i = 0 To UBound(data)
            Dim tt = data(i).Split(",")
            Dim one As Integer = find(dot.IndexOf(tt(0)), dot, boss)
            Dim two As Integer = find(dot.IndexOf(tt(1)), dot, boss)
            If one <> two Then
                Dim pt As Integer = dot.IndexOf(tt(1))
                boss(dot.IndexOf(boss(pt))) = dot(one)
                boss(pt) = dot(one) : sum += cost(i)
            End If
        Next
        PrintLine(3, sum.ToString)
    End Sub
    Function find(ByVal pt As Integer, ByVal dot As ArrayList, ByVal boss As ArrayList)
        Do
            If dot(pt) = boss(pt) Then Exit Do
            pt = dot.IndexOf(boss(pt))
        Loop
        Return pt
    End Function
End Class
