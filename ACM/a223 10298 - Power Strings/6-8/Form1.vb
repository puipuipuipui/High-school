Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t As String = LineInput(1)
        Do Until t = "."
            Dim test As Boolean = False
            For i = 1 To Len(t)
                If Len(t) - i < i Then test = True : Exit For
                Dim tmp As String = Mid(t, 1, i)
                If t.Replace(tmp, "") = "" Then PrintLine(3, (Len(t) / i).ToString) : Exit For
            Next
            If test Then PrintLine(3, "1")
            t = LineInput(1)
        Loop
        Close()
    End Sub
End Class
