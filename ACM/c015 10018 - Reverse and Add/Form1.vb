Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim t As Integer = LineInput(1), tt As Integer = Val(StrReverse(t.ToString))
            Dim pt As Integer = 0
            Do
                pt += 1
                Dim sum As Integer = t + tt
                If sum.ToString = StrReverse(sum.ToString) Then PrintLine(3, pt.ToString & " " & sum.ToString) : Exit Do
                t = sum : tt = Val(StrReverse(sum.ToString))
            Loop
        Next

        Close()
    End Sub
End Class
