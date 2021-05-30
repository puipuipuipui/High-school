Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i).Replace(" ", "").Replace("-", ""))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(t As String)
        Dim n As Integer = Len(t), wd As String = ""
        If n = 10 Then wd = "10,9,8,7,6,5,4,3,2" Else wd = "1,3,1,3,1,3,1,3,1,3,1,3"
        Dim sum As Integer = 0
        For i = 0 To n - 2
            Dim wdd = wd.Split(",")
            Dim a% = Val(t(i)), b% = Val(wdd(i))
            sum += a * b
        Next

        If n = 10 Then
            sum = sum Mod 11 : sum = 11 - sum
            If sum = 10 Then
                If t.Substring(n - 1) = "X" Then PrintLine(3, "T") Else PrintLine(3, "F")
            ElseIf sum = 11 Then
                If t.Substring(n - 1) = "0" Then PrintLine(3, "T") Else PrintLine(3, "F")
            Else
                Dim a = t.Substring(n - 1)
                If t.Substring(n - 1) = sum.ToString Then PrintLine(3, "T") Else PrintLine(3, "F")
            End If
        Else
            sum = sum Mod 10 : sum = 10 - sum
            If sum = 10 Then
                If t.Substring(n - 1) = "0" Then PrintLine(3, "T") Else PrintLine(3, "F")
            Else
                If t.Substring(n - 1) = sum.ToString Then PrintLine(3, "T") Else PrintLine(3, "F")
            End If
        End If


    End Sub
End Class
