Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            Dim sum As Integer = t(0) + t(1), re As Integer = 0
            Do
                Dim ad As Integer = sum \ t(2)
                Dim pt As Integer = sum Mod t(2)
                re += ad : sum = pt + ad
                If ad = 0 Then Exit Do
            Loop
            PrintLine(3, re.ToString)
        Next

        Close()
    End Sub
End Class
