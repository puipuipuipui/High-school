Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Do Until EOF(1)
            Dim t = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            Dim re As String = ""
            solve(t(0), t(1), re)
            PrintLine(3, re)
        Loop
        Close()
    End Sub
    Sub solve(ByVal pre As String, ByVal inor As String, ByRef re As String)
        Dim r As String = pre(0), pt As Integer = InStr(inor, r)
        Dim left_inor As String = Mid(inor, 1, pt - 1), left_pre As String = Mid(pre, 2, Len(left_inor))
        If Len(left_inor) > 0 Then
            solve(left_pre, left_inor, re)
        End If
        Dim right_inor As String = inor.Substring(pt), right_pre As String = pre.Substring(Len(left_pre) + 1)
        If Len(right_inor) > 0 Then
            solve(right_pre, right_inor, re)
        End If
        re &= r
    End Sub
End Class
