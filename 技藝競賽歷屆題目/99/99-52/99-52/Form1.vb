Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            solve(LineInput(i))
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(t As String)
        Dim pt, card As New ArrayList
        For i = 1 To Len(t)
            card.Add(i) : pt.Add(InStr(t, i))
        Next
        PrintLine(3, String.Join("", card.ToArray))

        Dim org As String = String.Join("", card.ToArray)
        For i = 5 To 1 Step -1
            Dim ad As Integer = pt.IndexOf(i), tt% = -1
            For j = 1 To 2
                tt = pt(0) : pt(0) = pt(ad) : pt(ad) = tt
                tt = card(0) : card(0) = card(ad) : card(ad) = tt
                If org = String.Join("", card.ToArray) Then Exit For Else PrintLine(3, String.Join("", card.ToArray))
                ad = i - 1
            Next
            If t = String.Join("", card.ToArray) Then Exit Sub
        Next

    End Sub
End Class
