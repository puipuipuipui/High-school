Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i), LineInput(i))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(a As String, b As String)
        Dim result As New ArrayList
        For i = 0 To Len(a) - 1
            If InStr(b, a(i).ToString) > 0 Then If result.IndexOf(a(i).ToString) = -1 Then result.Add(a(i).ToString)
        Next
        If result.Count = 0 Then PrintLine(3, "N") Else result.Sort() : PrintLine(3, String.Join("", result.ToArray))
    End Sub
End Class
