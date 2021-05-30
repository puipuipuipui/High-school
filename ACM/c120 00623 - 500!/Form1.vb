Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Do Until EOF(1)
            Dim t As Integer = LineInput(1)
            Dim re As String = "1"
            For i = 2 To t
                re = xx(re, i)
            Next
            PrintLine(3, t.ToString & "!")
            PrintLine(3, re)
        Loop
        Close()
    End Sub
    Function xx(ByVal x As String, ByVal y As Integer) As String
        Dim re As String = "", pt As Integer = 0
        For i = Len(x) - 1 To 0 Step -1
            Dim a As Integer = Val(x(i))
            Dim sum As Integer = a * y + pt
            pt = sum \ 10
            re = (sum Mod 10).ToString & re
        Next
        If pt > 0 Then re = pt.ToString & re
        Return re
    End Function
End Class
