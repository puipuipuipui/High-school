Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim q As Integer = LineInput(1)
        Dim prime As New ArrayList : prime.Add(2)
        For i = 3 To 5000 Step 2
            Dim test As Boolean = True
            For j = 0 To prime.Count - 1
                If prime(j) ^ 2 > i Then Exit For
                If i Mod prime(j) = 0 Then test = False : Exit For
            Next
            If test Then prime.Add(i)
        Next
        For k = 1 To q
            Dim t = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            Dim m As Integer = t(0), n As Integer = Val(t(1))
            Dim base, num As New ArrayList
            For i = 0 To prime.Count - 1
                If m Mod prime(i) = 0 Then
                    Dim pt As Integer=0
                    If base.IndexOf(prime(i)) = -1 Then base.Add(prime(i)) : num.Add(1) : pt = num.Count - 1 Else pt = base.IndexOf(prime(i))
                    Do Until m Mod prime(i) <> 0
                        m = m / prime(i)
                        num(pt) += 1
                    Loop
                End If
                If m = 1 Then Exit For
            Next
            Dim min As Integer = 999999999
            For i = 0 To base.Count - 1
                Dim sum As Integer = 0
                Dim ad As Integer = 1
                Do Until base(i) ^ ad > n
                    sum += n \ base(i) ^ ad
                    ad += 1
                Loop
                min = Math.Min(min, sum)
            Next
            If min = 0 Then PrintLine(3, "Case " & k.ToString & ":" & "Impossible to divide") Else PrintLine(3, "Case " & k.ToString & ":" & min.ToString)
        Next

        Close()
    End Sub
End Class
