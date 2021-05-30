Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Do Until EOF(1)
            Dim t As String = LineInput(1)
            Dim wd As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            Dim data As String = "", tests As Boolean = True
            For i = 1 To 10000
                Dim test As Boolean = False : data = ""
                For j = 0 To Len(t) - 1
                    Dim ad As Integer = InStr(wd, t(j).ToString)
                    data = data & (ad + i - 1).ToString
                Next
                Dim re As String = ""
                Do
                    For j = Len(data) - 1 To 1 Step -1
                        Dim a As Integer = Val(data(j)), b As Integer = Val(data(j - 1))
                        re = ((a + b) Mod 10).ToString & re
                    Next
                    data = re : re = ""
                    If Len(data) = 2 Then Exit Do
                    If data = "100" Then test = True : Exit Do
                Loop
                If test Then PrintLine(3, i.ToString) : tests = False : Exit For
            Next
            If tests Then PrintLine(3, ":(")
        Loop
        Close()
    End Sub
End Class
