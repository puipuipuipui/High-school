Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim t = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            Dim x As String = StrReverse(t(0)), y As String = StrReverse(t(1))
            Dim re As String = add(x, y)
            re = StrReverse(re)
            Do Until re(0).ToString <> "0" Or Len(re) = 1
                re = re.Substring(1)
            Loop
            PrintLine(3, re)
        Next
        Close()
    End Sub
    Function add(ByVal x As String, ByVal y As String) As String
        Do Until Len(x) = Len(y)
            If Len(x) > Len(y) Then y = "0" & y
            If Len(x) < Len(y) Then x = "0" & x
        Loop
        Dim re As String = "", pt As Integer = 0
        For i = Len(x) - 1 To 0 Step -1
            Dim a As Integer = Val(x(i)), b As Integer = Val(y(i))
            Dim sum As Integer = a + b + pt
            re = (sum Mod 10).ToString & re
            pt = (sum \ 10).ToString
        Next
        If pt > 0 Then re = pt.ToString & re
        Return re
    End Function
End Class
