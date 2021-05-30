Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Do Until EOF(1)
            Dim t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            If t(0) = 1 Then
                PrintLine(3, "Jolly")
            Else
                Dim n As Integer = t(0)
                Dim tmp = New ArrayList(t) : tmp.RemoveAt(0)
                Dim test As Boolean = True
                For i = 0 To tmp.Count - 2
                    Dim sum As Integer = Math.Abs(tmp(i) - tmp(i + 1))
                    If sum >= n Then test = False : Exit For
                Next
                If test Then PrintLine(3, "Jolly") Else PrintLine(3, "Not jolly")
            End If
        Loop
        Close()
    End Sub
End Class
