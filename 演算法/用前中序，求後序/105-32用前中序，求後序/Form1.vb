Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For j = 1 To n
                Dim result As New ArrayList
                solve(New ArrayList(LineInput(i).Split(",")), New ArrayList(LineInput(i).Split(",")), result)
                PrintLine(3, String.Join(",", result.ToArray))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(ByVal inor As ArrayList, ByVal preo As ArrayList, ByVal result As ArrayList)
        If inor.Count = 1 Then
            result.Add(inor(0))
        ElseIf inor.Count = 0 Then
            Exit Sub
        Else
            Dim pt As Integer = inor.IndexOf(preo(0))
            Dim t1 = New ArrayList(inor.GetRange(0, pt)), t2 = New ArrayList(preo.GetRange(1, pt))
            Dim tt1 = New ArrayList(inor.GetRange(pt + 1, inor.Count - pt - 1)), tt2 = New ArrayList(preo.GetRange(pt + 1, preo.Count - pt - 1))
            solve(t1, t2, result) : solve(tt1, tt2, result) : result.Add(preo(0))
        End If
    End Sub
End Class
