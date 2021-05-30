Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim prime As New ArrayList
        prime.Add(2)
        For i = 3 To 1000 Step 2
            Dim test As Boolean = True
            For j = 0 To prime.Count - 1
                If j ^ 2 > i Then Exit For
                If i Mod prime(j) = 0 Then test = False : Exit For
            Next
            If test Then prime.Add(i)
        Next

        Close()
    End Sub
End Class
