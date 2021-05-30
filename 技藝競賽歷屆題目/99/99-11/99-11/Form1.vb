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
        Dim word, sum As New ArrayList
        For i = 1 To n
            Dim t As String = LineInput(q).Replace("，", "").Replace("。", "").Replace("；", "").Replace("、", "").Replace("！", "").Replace("？", "")
            For j = 0 To Len(t) - 1
                Dim a = t(i)
                If word.IndexOf(t(j).ToString) = -1 Then word.Add(t(j).ToString) : sum.Add(1) Else sum(word.IndexOf(t(j).ToString)) += 1
            Next
        Next
        Dim summ = sum.ToArray, wordd = word.ToArray
        Array.Sort(summ, wordd)
        For i = UBound(summ) To 0 Step -1
            If summ(i) = summ(UBound(summ)) Then PrintLine(3, wordd(i) & " " & summ(i)) Else Exit For
        Next

    End Sub
End Class
