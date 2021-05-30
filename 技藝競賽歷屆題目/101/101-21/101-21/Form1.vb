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
    Sub solve(n As Integer, q As Integer)
        Dim son(n - 2), father(n - 2) As Integer
        For i = 0 To n - 2
            Dim t = LineInput(q).Replace(" ", "").Split(",")
            son(i) = t(0) : father(i) = t(1)
        Next
        Dim sum(n - 1) As Integer
        For i = 0 To UBound(son)
            Dim pt As Integer = i
            sum(i) = 1

            Do
                pt = Array.IndexOf(son, father(pt))
                sum(i) += 1
                If pt = -1 Then Exit Do
            Loop
        Next
        Array.Sort(sum)
        PrintLine(3, sum(UBound(sum)).ToString)
    End Sub

End Class
