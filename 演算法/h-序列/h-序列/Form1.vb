Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "out.txt", 2)
        For i = 1 To 3
            PrintLine(2, solve(LineInput(1)))
            PrintLine(2)
        Next
        Close()
    End Sub
    Function solve(tmp As String) As Boolean
        If tmp(0).tostring = "0" And Len(tmp) > 1 Then Return "False"
        tmp = tmp.Replace("100", "h").Replace("0", "h")
        Do
            tmp = tmp.Replace("1hh", "h")
            If tmp = tmp.Replace("1hh", "h") Then Exit Do
        Loop
        If tmp = "h" Then Return "True" Else Return "False"
    End Function
  

End Class
