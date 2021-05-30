Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Sub solve(ByVal t As Integer)
        Dim org As Integer = t
        Dim feb As New ArrayList : feb.Add(0) : feb.Add(1)
        Do
            Dim sum As Integer = feb(feb.Count - 1) + feb(feb.Count - 2)
            If sum > 10000 Then Exit Do
            feb.Add(sum)
        Loop
        feb.RemoveRange(0, 2)
        Dim re(feb.Count - 1) As Integer
        For i = 16 To 0 Step -1
            If t >= feb(i) Then t -= feb(i) : re(i) = 1
        Next
        Dim result = New ArrayList(re) : result.Reverse()
        Do Until result(0) <> 0
            result.RemoveAt(0)
        Loop
        PrintLine(3, org.ToString & "=" & String.Join("", result.ToArray))
    End Sub
End Class
