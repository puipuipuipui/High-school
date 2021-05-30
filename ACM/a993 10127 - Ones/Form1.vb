Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Do Until EOF(1)
            Dim t As Integer = LineInput(1)
            Dim tt As String = t.ToString
            If tt = StrDup(Len(tt), "1") Then
                PrintLine(3, Len(tt).ToString)
            Else
                Dim ad(9) As Integer
                For i = 0 To UBound(ad)
                    ad(i) = t * i
                Next
                Dim re As Integer = 0
                Dim sum As Integer = 0
                Do
                    For i = 0 To UBound(ad)
                        If (sum + ad(i)) Mod 10 = 1 Then sum = (sum + ad(i)) \ 10 : re += 1 : Exit For
                    Next
                    If sum.ToString = StrDup(Len(sum.ToString), "1") Then re += Len(sum.ToString) : Exit Do
                Loop
                PrintLine(3, re.ToString)
            End If
        Loop

        Close()
    End Sub
End Class
