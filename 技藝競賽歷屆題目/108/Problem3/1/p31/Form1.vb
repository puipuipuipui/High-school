Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim feb As New ArrayList : feb.Add("0") : feb.Add("1")
        Do Until feb.Count - 1 = 5000
            Dim pt As Integer = feb.Count
            feb.Add(add(feb(pt - 1), feb(pt - 2)))
        Loop
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t As Integer = LineInput(i)
                PrintLine(3, feb(t))
            Next
            PrintLine(3)
        Next
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
            re = (sum Mod 10).ToString & re
            pt = sum \ 10
        Next
        If pt > 0 Then re = pt.ToString & re
        Return re
    End Function
   
End Class
