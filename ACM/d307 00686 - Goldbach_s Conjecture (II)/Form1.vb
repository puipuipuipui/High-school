Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t As Integer = LineInput(1)
        Dim prime As New ArrayList : prime.Add(2)
        For i = 3 To 2 ^ 15 Step 2
            Dim test As Boolean = True
            For j = 0 To prime.Count - 1
                If prime(j) ^ 2 > i Then Exit For
                If i Mod prime(j) = 0 Then test = False : Exit For
            Next
            Dim a As Integer = i
            If test Then prime.Add(a)
        Next
        Do Until t = 0
            Dim sum As Integer = 0
            For i = 0 To prime.Count - 1
                If prime(i) > t / 2 Then Exit For
                Dim ad As Integer = t - prime(i)
                If prime.IndexOf(ad) > -1 Then sum += 1
            Next
            PrintLine(3, sum.ToString)
            t = LineInput(1)
        Loop
        Close()
    End Sub
End Class
