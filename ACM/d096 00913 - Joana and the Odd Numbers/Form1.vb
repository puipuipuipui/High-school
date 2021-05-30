Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Do Until EOF(1)
            Dim t As Integer = LineInput(1)
            Dim sum As Long = (1 + t)
            Dim high As Integer = (1 + t) / 2
            sum = sum / 2 * high
            Dim re As String = ""
            For i = sum To sum - 3 + 1 Step -1
                re = add(re, (i * 2 - 1).ToString)
            Next
            PrintLine(3, re.ToString)
        Loop

        Close()
    End Sub
    Function add(x As String, y As String) As String
        Do Until Len(x) = Len(y)
            If Len(x) > Len(y) Then y = "0" & y
            If Len(x) < Len(y) Then x = "0" & x
        Loop
        Dim re As String = "", pt As Integer = 0
        For i = Len(x) - 1 To 0 Step -1
            Dim a As Integer = Val(x(i)), b As Integer = Val(y(i))
            Dim sum As Integer = a + b + pt
            re = (sum Mod 10).ToString & re
            pt = sum \ 10
        Next
        If pt > 0 Then re = pt.ToString & re
        Return re
    End Function
End Class
