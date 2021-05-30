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
        Dim check As String = "0123456789", result As New ArrayList
        For i = 0 To Len(t) - 1
            Dim pt As Integer = InStr(check, t(i).ToString)
            If pt > 0 And result.IndexOf(t(i).ToString) = -1 Then result.Add(t(i).ToString)
        Next
        If result.Count = 0 Then result.Add("N")
        result.Sort()
        PrintLine(3, String.Join("", String.Join("", result.ToArray)))
    End Sub

End Class
