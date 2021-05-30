Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For j = 1 To n
                Dim inor = New ArrayList(LineInput(i).Replace(" ", "").Split(","))
                Dim pre = New ArrayList(LineInput(i).Replace(" ", "").Split(","))
                Dim re As New ArrayList
                judge(pre, inor, re)
                PrintLine(3, String.Join(",", re.ToArray))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub judge(ByVal pre As ArrayList, ByVal inor As ArrayList, ByVal re As ArrayList)
        Dim r As String = pre(0), pt As Integer = inor.IndexOf(r)
        Dim inor_left = inor.GetRange(0, pt), pre_left = pre.GetRange(1, pt)
        Dim inor_right = inor.GetRange(pt + 1, inor.Count - (pt + 1)), pre_right = pre.GetRange(pt + 1, pre.Count - (pt + 1))
        If inor_left.Count <> 0 Then
            judge(pre_left, inor_left, re)
        End If
        If inor_right.Count <> 0 Then
            judge(pre_right, inor_right, re)
        End If
        re.Add(r)
    End Sub
End Class
