Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i), i)
                If j <> n Then LineInput(i)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(n As Integer, q%)
        Dim num, sum As New ArrayList
        For i = 1 To n
            Dim a = LineInput(q)
            Dim t = a.Replace(" ", "").Split(",")
            For j = 0 To UBound(t)
                If num.IndexOf(t(j)) = -1 Then num.Add(t(j)) : sum.Add(1) Else sum(num.IndexOf(t(j))) += 1
            Next
        Next
        Dim numarray = num.ToArray, sumarray = sum.ToArray, result As New ArrayList
        Array.Sort(sumarray, numarray)
        For i = UBound(numarray) To 0 Step -1
            If sumarray(UBound(sumarray)) = sumarray(i) Then result.Add(numarray(i).ToString) Else Exit For
        Next
        result.Sort()
        PrintLine(3, String.Join(",", (result).ToArray))
    End Sub
End Class
