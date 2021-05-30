Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i).Split({" "}, StringSplitOptions.RemoveEmptyEntries))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(t() As String)
        Dim tmp(UBound(t)) As String, cost(UBound(t)) As Integer
        For i = 0 To UBound(t)
            tmp(i) = Mid(t(i), 1, 3) : cost(i) = Val(t(i).Substring(4))
        Next
        Array.Sort(cost, tmp)
        Dim dot, boss As New ArrayList, sum As Integer = 0
        For i = 0 To UBound(cost)
            Dim tmpp = tmp(i).Split(",")
            If dot.IndexOf(tmpp(0)) = -1 Then dot.Add(tmpp(0)) : boss.Add(tmpp(0))
            If dot.IndexOf(tmpp(1)) = -1 Then dot.Add(tmpp(1)) : boss.Add(tmpp(1))
            Dim lefthigh As String = high(dot, boss, tmpp(0)), rihgthigh As String = high(dot, boss, tmpp(1))
            If lefthigh <> rihgthigh Then sum += cost(i) : boss(dot.IndexOf(rihgthigh)) = lefthigh
        Next
        PrintLine(3, sum.ToString)
    End Sub
    Function high(dot As ArrayList, boss As ArrayList, t As String) As String
        Dim bs = boss(dot.IndexOf(t))
        If bs <> t Then Return high(dot, boss, bs)
        Return bs

    End Function
End Class
