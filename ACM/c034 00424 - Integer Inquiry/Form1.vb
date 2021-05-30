Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim data As New ArrayList
        Dim t As String = LineInput(1)
        Do Until t = "0"
            data.Add(t)
            t = LineInput(1)
        Loop
        Dim re As String = "0"
        For i = 0 To data.Count - 1
            re = add(re, data(i))
        Next
        PrintLine(3, re)
        Close()
    End Sub
    Function add(ByVal x As String, ByVal y As String) As String
        Do Until Len(x) = Len(y)
            If Len(x) < Len(y) Then x = "0" & x
            If Len(x) > Len(y) Then y = "0" & y
        Loop
        Dim re As String = "", pt As Integer = 0
        For i = Len(x) - 1 To 0 Step -1
            Dim a As Integer = Val(x(i)), b As Integer = Val(y(i))
            Dim sum As Integer = a + b + pt
            pt = sum \ 10
            re = (sum Mod 10).ToString & re
        Next
        If pt > 0 Then re = pt.ToString & re
        Return re
    End Function
End Class
