Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t As Integer = LineInput(1)
        Dim prime As New ArrayList : prime.Add(2)
        For i = 3 To 2 ^ 32 - 1
            If i ^ 2 > 2 ^ 32 - 1 Then Exit For
            Dim test As Boolean = True
            For j = 0 To prime.Count - 1
                If prime(j) ^ 2 > i Then Exit For
                If i Mod prime(j) = 0 Then test = False : Exit For
            Next
            If test Then prime.Add(i)
        Next
        Do Until t = 0
            Dim base, num As New ArrayList
            For i = 0 To prime.Count - 1
                If t Mod prime(i) = 0 Then
                    base.Add(prime(i)) : num.Add(0)
                    Dim pt As Integer = num.Count - 1
                    Do Until t Mod prime(i) <> 0
                        t = t / prime(i)
                        num(pt) += 1
                    Loop
                End If
            Next
            Dim re As Integer = 1
            For i = 0 To num.Count - 1
                re *= num(i) + 1
            Next
            If re Mod 2 = 0 Then PrintLine(3, "no") Else PrintLine(3, "yes")
            t = LineInput(1)
        Loop

        Close()
    End Sub
End Class
