Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t As Integer = Val(LineInput(1))
        Do Until t < 0
            Dim sum As Integer = 0
            Dim add = New ArrayList(Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x)))
            add.IndexOf(0, t)
            Dim need = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            For i = 0 To UBound(need)
                sum += add(i)
                If sum < need(i) Then PrintLine(3, "No problem. :(") Else PrintLine(3, "No problem! :D")
            Next
            t = Val(LineInput(1))
        Loop

        Close()
    End Sub
End Class
