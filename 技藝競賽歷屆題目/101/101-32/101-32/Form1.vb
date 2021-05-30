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
        Dim num = "00,01,100,101,1100,1101,11100,11101,111100,111101,111110,111111".Split(",")
        Dim word = "A,B,0,1,2,3,4,5,6,7,8,9".Split(",")
        Dim result As New ArrayList
        Do Until Len(t) = 0
            For i = UBound(num) To 0 Step -1
                Dim pt As Integer = InStr(t, num(i))
                If pt = 1 Then result.Add(word(i)) : t = t.Substring(Len(num(i)))
            Next
        Loop
        result.Insert(4, ",")
        PrintLine(3, String.Join("", result.ToArray))
    End Sub
End Class
