Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim t As String = LineInput(1)
            Dim word, num As New ArrayList
            For j = 0 To Len(t) - 1
                Dim pt As Integer = word.IndexOf(t(j))
                If pt = -1 Then word.Add(t(j)) : num.Add(1) Else num(pt) += 1
            Next
            Dim prime As New ArrayList : prime.Add(2)
            For j = 3 To 2001
                Dim test As Boolean = True
                For k = 0 To prime.Count - 1
                    If prime(k) ^ 2 > j Then Exit For
                    If j Mod prime(k) = 0 Then test = False : Exit For
                Next
                If test Then prime.Add(j)
            Next
            Dim re, re1 As New ArrayList
            Dim ad As String = "abcdefghijklmnopqrstuvwxyz"
            For j = 0 To num.Count - 1
                If prime.IndexOf(num(j)) > -1 Then
                    If InStr(ad, word(j)) > 0 Then re1.Add(word(j)) Else re.Add(word(j))
                End If
            Next
            If re.Count = 0 And re1.Count = 0 Then
                PrintLine(3, "Case " & i.ToString & ": " & "empty")
            Else
                re.Sort() : re1.Sort()
                PrintLine(3, "Case " & i.ToString & ": " & String.Join("", re.ToArray) & String.Join("", re1.ToArray))
            End If
        Next

        Close()
    End Sub
End Class
