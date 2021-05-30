Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For k = 1 To n
            Dim t1 As String = StrReverse(LineInput(1)), t2 As String = StrReverse(LineInput(1))
            Dim s1 As Integer = 0, s2 As Integer = 0
            For i = 0 To Len(t1) - 1
                Dim a As Integer = Val(t1(i))
                s1 += a * 2 ^ i
            Next
            For i = 0 To Len(t2) - 1
                Dim a As Integer = Val(t2(i))
                s2 += a * 2 ^ i
            Next

            If s2 > s1 Then Dim a As Integer = s1 : s1 = s2 : s2 = a
            Dim ad As New ArrayList
            For i = 1 To s2
                If i ^ 2 > s2 Then Exit For
                If s2 Mod i = 0 Then
                    Dim a As Integer = s2 / i
                    ad.Add(i)
                    If i <> a Then ad.Add(a)
                End If
            Next
            ad.Remove(1)
            Dim r As Integer = s1 - s2, test As Boolean = False
            For i = 0 To ad.Count - 1
                If r Mod ad(i) = 0 Then test = True : Exit For
            Next
            If test Then PrintLine(3, "Pair #" & k.ToString & ": All you need is love!") Else PrintLine(3, "Pair #" & k.ToString & ": Love is not all you need!")
        Next

        Close()
    End Sub
End Class
