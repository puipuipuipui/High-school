Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            solve(LineInput(i), i)
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(t As String, q As Integer)
        Dim pt% = 0, sum% = 0, wordsum% = 0
        Dim data As String = ""
        Do
            data = LineInput(q) : If data = "EOF" Then Exit Do
            Dim tmp = LCase(data.Replace(",", " ").Replace(";", " ").Replace(".", " ")).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            pt = 0 : wordsum += UBound(tmp) + 1
            Do Until Array.IndexOf(tmp, LCase(t), pt) = -1
                sum += 1 : pt = Array.IndexOf(tmp, LCase(t), pt) + 1
            Loop
        Loop
        PrintLine(3, sum.ToString & "," & wordsum.ToString)
    End Sub

End Class
