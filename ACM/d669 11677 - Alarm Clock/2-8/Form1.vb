Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
        Do Until t.Sum = 0
            Dim re As Integer = 0
            If t(0) < t(2) Then
                Dim star As Integer = t(0) * 60 + t(1), eend As Integer = t(2) * 60 + t(3)
                re = eend - star
            ElseIf t(0) = t(2) And t(1) < t(3) Then
                re = t(3) - t(1)
            ElseIf t(0) = t(2) And t(1) = t(3) Then
                re = 0
            Else
                Dim star As Integer = (24 - t(0)) * 60 + (0 - t(1)), eend As Integer = t(2) * 60 + t(3)
                re = eend + star
            End If
            PrintLine(3, re.ToString)
            t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
        Loop
        Close()
    End Sub
End Class
