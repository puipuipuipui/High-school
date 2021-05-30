Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        Do Until n = 0
            Dim data As New ArrayList
            For i = 1 To n
                If i ^ 2 <= n Then data.Add(i ^ 2)
            Next
            PrintLine(3, data(data.Count - 1).ToString)


            n = LineInput(1)
        Loop
        Close()
    End Sub
End Class
