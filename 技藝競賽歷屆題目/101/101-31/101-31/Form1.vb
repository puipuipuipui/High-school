Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i), result(2) As Integer, check As New ArrayList
            For j = 1 To n

                solve(result, check, LineInput(i))
            Next
            PrintLine(3, String.Join(",", result))
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(result() As Integer , check As Arraylist,t As String)
        Dim eng As String = "ABCDEFGHJKLMNPQRSTUVXYWZIO", ad = "19876543211"
        If t(1).ToString <> "1" And t(1).ToString <> "2" Then result(2) += 1 : Exit Sub
        t = (InStr(eng, t(0).ToString) + 9) & t.Substring(1)
        If check.IndexOf(t) > -1 Then result(1) += 1 : Exit Sub
        Dim sum As Integer
        For j = 0 To Len(t) - 1
            sum += Val(t(j)) * Val(ad(j))
        Next
        If sum Mod 10 <> 0 Then result(2) += 1 : Exit Sub
        result(0) += 1 : check.Add(t)
    End Sub

End Class
