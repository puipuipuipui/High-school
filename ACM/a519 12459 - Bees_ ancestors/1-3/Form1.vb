Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t As Integer = LineInput(1)
        Do Until t = 0
            Dim feb As New ArrayList : feb.Add(1) : feb.Add(1)
            For i = 1 To 80
                feb.Add(feb(feb.Count - 1) + feb(feb.Count - 2))
            Next
            PrintLine(3, feb(t).ToString)
            t = LineInput(1)
        Loop
        Close()
    End Sub
End Class
