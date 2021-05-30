Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t As Integer = LineInput(1)
        Do Until t = 0
            Dim re As Integer = f91(t)
            PrintLine(3, "f91(" & t.ToString & ") = " & re.ToString)
            t = LineInput(1)
        Loop

        Close()
    End Sub
    Function f91(ByVal n As Integer)
        If n <= 100 Then Return f91(f91(n + 11)) Else Return n - 10
    End Function
End Class
