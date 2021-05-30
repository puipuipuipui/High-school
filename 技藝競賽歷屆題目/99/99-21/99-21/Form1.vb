Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            solve(i, n)
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(q As Integer, n As Integer)
        Dim father, son As New ArrayList
        For i = 1 To n
            Dim t = LineInput(q).Replace(" ", "").Split(",")
            son.Add(t(0)) : father.Add(t(1))
        Next
        Dim ans_sum, ans_tree As New ArrayList
        For i = 0 To son.Count - 1
            Dim sum% = 0
            If father.IndexOf(son(i)) = -1 Then ans_sum.Add(judge(i, father, son, sum)) : ans_tree.Add(son(i))
        Next
        For i = 0 To ans_sum.Count - 1
            PrintLine(3, ans_tree(i) & " " & ans_sum(i).ToString)
        Next
    End Sub
    Function judge(n As Integer, father As ArrayList, son As ArrayList, ByRef sum As Integer) As Integer
        If father(n) = "---" Then Return sum Else sum += 1 : judge(son.IndexOf(father(n)), father, son, sum)
        Return sum
    End Function
End Class
