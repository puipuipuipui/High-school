Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Do Until EOF(1)
            Dim t As Integer = LineInput(1)
            Dim test1 As Boolean = False, test2 As Boolean = False, test3 As Boolean = False
            If t Mod 400 = 0 Or (t Mod 4 = 0 And t Mod 100 <> 0) Then test1 = True
            If t Mod 15 = 0 Then test2 = True
            If test1 Then If t Mod 55 = 0 Then test3 = True
            If test1 Then PrintLine(3, "This is leap year.")
            If test2 Then PrintLine(3, "This is huluculu festival year.")
            If test3 Then PrintLine(3, "This is bulukulu festival year.")
            If Not (test1) And Not (test2) And Not (test3) Then PrintLine(3, "This is an ordinary year.")
            PrintLine(3)
        Loop

        Close()
    End Sub
End Class
