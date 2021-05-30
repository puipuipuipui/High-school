Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim boss, data As New ArrayList
        '10個強盜下面不是10
        Do Until EOF(1)
            Dim tmp() = LineInput(1).Split(",")
            If data.IndexOf(tmp(0)) = -1 Then data.Add(tmp(0)) : boss.Add(tmp(0))
            If data.IndexOf(tmp(1)) = -1 Then data.Add(tmp(1)) : boss.Add(tmp(1))
            Dim pt = data.IndexOf(tmp(1))
            boss(data.IndexOf(boss(pt))) = boss(data.IndexOf(tmp(0))) : boss(pt) = boss(data.IndexOf(tmp(0)))
        Loop

        Dim sum = 0
        Dim re As New ArrayList
        For i = 0 To boss.Count - 1
            If re.IndexOf(boss(i)) = -1 Then sum += 1 : re.Add(boss(i))
        Next
        '10個強盜sum = 3
        PrintLine(3, sum)
        Close()

    End Sub
End Class
