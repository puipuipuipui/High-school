Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim t = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            If UBound(t) = 0 Then
                PrintLine(3, "NO LOOP")
            Else
                Dim m As Integer = 0, f As Integer = 0
                For j = 0 To UBound(t)
                    Dim first As String = Mid(t(j), 1, 1), last As String = Mid(t(j), Len(t(j)), 1)
                    If first = "M" Then m += 1 Else f += 1
                    If last = "M" Then m += 1 Else f += 1
                Next
                If m <> f Then PrintLine(3, "NO LOOP") Else PrintLine(3, "LOOP")
            End If
        Next
        Close()
    End Sub
End Class
