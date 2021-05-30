Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i).Split(","), i)
                If j <> n Then LineInput(i)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(t() As String, q%)
        Dim tt = Array.ConvertAll(t, Function(x) Int32.Parse(x))
        Dim son, father As New ArrayList
        For i = 0 To tt(0) - 1
            Dim tmp = Array.ConvertAll(LineInput(q).Split(","), Function(x) Int32.Parse(x))
            son.Add(tmp(0)) : father.Add(tmp(1))
        Next
        Dim result As Integer = 0
        For i = 0 To son.Count - 1
            Dim sum As Integer = 1, pt As Integer = father(i)
            Do
                If pt = 99 Then Exit Do
                pt = father(son.IndexOf(pt)) : sum += 1
            Loop
            If sum - 1 = tt(1) Then result += 1
        Next
        PrintLine(3, result.ToString)
    End Sub

End Class
