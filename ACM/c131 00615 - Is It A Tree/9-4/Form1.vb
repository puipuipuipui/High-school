Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
        Dim pt As Integer = 1
        Do Until t(0) = -1
            Dim v, test, ad As New ArrayList, tests As Boolean = True
            For i = 0 To UBound(t)
                If t(i) = 0 Then Exit For
                If v.IndexOf(t(i)) = -1 Then v.Add(t(i)) : test.Add(1)
                If i Mod 2 = 1 Then
                    If t(i) = t(i - 1) Then tests = False : Exit For
                    If ad.IndexOf(t(i)) = -1 Then ad.Add(t(i)) Else tests = False : Exit For
                End If
            Next
            If tests Then
                For i = 0 To ad.Count - 1
                    Dim pts As Integer = v.IndexOf(ad(i))
                    test(pts) = 0
                Next
                Dim tt = Array.ConvertAll(test.ToArray, Function(x) Int32.Parse(x))
                If tt.Sum > 1 Then PrintLine(3, "Case " & pt.ToString & " is not a tree.") Else PrintLine(3, "Case " & pt.ToString & " is a tree.")
            Else
                PrintLine(3, "Case " & pt.ToString & " is not a tree.")
            End If

            pt += 1
            t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
        Loop
        Close()
    End Sub
End Class
