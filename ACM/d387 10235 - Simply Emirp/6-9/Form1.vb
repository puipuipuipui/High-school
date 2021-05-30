Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim prime As New ArrayList : prime.Add(2)
        For i = 3 To 1000
            Dim test As Boolean = True
            For j = 0 To prime.Count - 1
                If prime(j) ^ 2 > i Then Exit For
                If i Mod prime(j) = 0 Then test = False : Exit For
            Next
            If test Then prime.Add(i)
        Next
        Do Until EOF(1)
            Dim t As Integer = LineInput(1)
            If solve(prime, t) Then
                Dim tt As Integer = Val(StrReverse(t.ToString))
                If t = tt Then
                    PrintLine(3, t.ToString & " is prime.")
                Else
                    If solve(prime, tt) Then PrintLine(3, t.ToString & " is emirp.") Else PrintLine(3, t.ToString & " is prime.")
                End If
            Else
                PrintLine(3, t.ToString & " is not prime.")
            End If

        Loop
        Close()
    End Sub
    Function solve(ByVal prime As ArrayList, ByVal t As Integer) As Boolean
        If t > prime(prime.Count - 1) Then
            Dim test As Boolean = True
            For i = 0 To prime.Count - 1
                If t Mod prime(i) = 0 Then test = False : Exit For
            Next
            If test Then Return True Else Return False
        Else
            If prime.IndexOf(t) = -1 Then Return False Else Return True
        End If
    End Function
End Class
