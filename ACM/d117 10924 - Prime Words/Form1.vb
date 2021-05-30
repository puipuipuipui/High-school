Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Do Until EOF(1)
            Dim t As String = LineInput(1)
            Dim ad As String = "abcdefghijklmnopqrstuvwxyz" & UCase("abcdefghijklmnopqrstuvwxyz")
            Dim sum As Integer = 0
            For i = 0 To Len(t) - 1
                sum += InStr(ad, t(i).ToString)
            Next
            Dim test As Boolean = True
            For i = 2 To sum - 1
                If i ^ 2 > sum Then Exit For
                If sum Mod i = 0 Then test = False
            Next
            If test Then PrintLine(3, "It is a prime word.") Else PrintLine(3, "It is not a prime word.")
        Loop
        Close()
    End Sub
End Class
