Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As String = LineInput(i)
            For j = 1 To 4
                PrintLine(3, solve(n, LineInput(i)))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Function solve(tt As String, data As String) As String
        Dim check(2) As String
        check(0) = "0123456789" : check(1) = "abcdefghijklmnopqrstuvwxyz" : check(2) = UCase(check(1))
        For i = 1 To Len(data) - Len(tt) + 1
            Dim tmp As String = Mid(data, i, Len(tt))
            Dim test As Boolean = True
            For j = 0 To Len(tt) - 1
                Dim pt As Integer = -1
                If tt(j).ToString = "#" Then pt = 0 Else If tt(j) = "$" Then pt = 1 Else pt = 2
                If InStr(check(pt), tmp(j).ToString) = 0 Then test = False : Exit For
            Next
            If test Then Return "符合"
        Next
        Return "不符合"
    End Function
End Class
