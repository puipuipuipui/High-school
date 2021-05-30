Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim t As String = LineInput(1)
            Dim re As Integer = solve(t)
            If re = 1 Then PrintLine(3, "Case #" & i.ToString & ": " & t & " is a Happy number.") Else PrintLine(3, "Case #" & i.ToString & ": " & t & " is an Unhappy number.")
        Next


        Close()
    End Sub
    Function solve(ByVal t As String) As Integer
        Dim sum As Integer = 0
        For i = 0 To Len(t) - 1
            Dim a As Integer = Val(t(i))
            sum += a ^ 2
        Next
        If Len(sum.ToString) = 1 Then Return sum Else Return solve(sum.ToString)
    End Function
End Class
