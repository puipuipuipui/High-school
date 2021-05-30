Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t = LineInput(i).Replace("[", "").Replace("]", "").Replace(" ", "").Split(",")
                Dim tmp(UBound(t)) As Integer, re As New ArrayList

                For j = 0 To UBound(t)
                    Dim ad As New ArrayList
                    If tmp(j) = 0 Then
                        Dim r As Integer = j
                        Do Until tmp(r) = 1
                            ad.Add(r + 1) : tmp(r) = 1
                            r = Val(t(r)) - 1
                        Loop
                        re.Add("[" & String.Join(",", ad.ToArray) & "]")
                    End If
                Next
                PrintLine(3, "[" & String.Join(",", re.ToArray) & "]")
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
End Class
