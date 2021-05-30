Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i), tmp As String = ""
            For j = 1 To n
                tmp = tmp & LineInput(i).Replace("，", "*").Replace("。", "*").Replace("；", "*").Replace("、", "*").Replace("！", "*").Replace("？", "*")
            Next
            solve(tmp)
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(tmp As String)
        Dim word, sum As New ArrayList
        For i = 1 To Len(tmp) - 1
            Dim ad = Mid(tmp, i, 2)
            If InStr(ad, "*") = 0 Then
                If word.IndexOf(ad) = -1 Then word.Add(ad) : sum.Add(1) Else sum(word.IndexOf(ad)) += 1
            End If
        Next
        Dim wordd = word.ToArray, summ = sum.ToArray
        Array.Sort(summ, wordd)
        For i = UBound(wordd) To 0 Step -1
            If summ(i) = summ(UBound(wordd)) Then PrintLine(3, wordd(i) & " " & summ(i)) Else Exit For
        Next

    End Sub
End Class
