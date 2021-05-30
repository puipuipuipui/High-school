Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(t As String)
        Dim check = "ABCDEFGHJKLMNPQRSTUVXYWZIO", ad = "876543211", add = "19"
        Dim aa = Len(check)
        Dim sum As Integer = 0
        For i = 0 To Len(t) - 1
            sum += Val(t(i)) * Val(ad(i))
        Next
        sum = sum Mod 10
        Dim result(26) As String, pt% = 0
        For i = 1 To Len(check)
            Dim n As String = (i + 9).ToString
            If (sum + Val(n(0)) * Val(add(0)) + Val(n(1)) * Val(add(1))) Mod 10 = 0 Then result(pt) = check(i - 1).ToString : pt += 1
        Next
        Array.Sort(result)
        PrintLine(3, String.Join("", result))
    End Sub
End Class
