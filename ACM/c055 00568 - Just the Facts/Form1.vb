Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim prime As New ArrayList : prime.Add(2)
        For i = 3 To 10000 Step 2
            Dim test As Boolean = True
            For j = 0 To prime.Count - 1
                If prime(j) ^ 2 > i Then Exit For
                If i Mod prime(j) = 0 Then test = False : Exit For
            Next
            If test Then prime.Add(i)
        Next
        Do Until EOF(1)
            Dim t As Integer = LineInput(1)
            Dim two As Integer = solve(t, 2), five As Integer = solve(t, 5)
            Dim re As Integer = 1
            For i = 0 To prime.Count - 1
                If prime(i) > t Then Exit For
                If prime(i) <> 2 And prime(i) <> 5 Then
                    Dim pt As Integer = solve(t, prime(i))
                    For j = 1 To pt
                        re = (re * prime(i)) Mod 10
                    Next
                End If
            Next
            Dim sum As Integer = Math.Abs(two - five)
            For i = 1 To sum
                re = (re * 2) Mod 10
            Next
            PrintLine(3, t.ToString & " -> " & re.ToString)
        Loop
        Close()
    End Sub
    Function solve(ByVal t As Integer, ByVal n As Integer) As Integer
        Dim re As Integer = 0, pt As Integer = 1
        Do Until t < n ^ pt
            re += t \ n ^ pt
            pt += 1
        Loop
        Return re
    End Function
End Class
