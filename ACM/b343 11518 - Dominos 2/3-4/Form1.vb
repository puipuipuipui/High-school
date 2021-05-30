Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For k = 1 To n
            Dim ad = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            Dim data As New ArrayList
            For i = 1 To Val(ad(1))
                data.Add(LineInput(1).ToString)
            Next
            Dim re, pu As New ArrayList
            For i = 1 To Val(ad(2))
                Dim pt As String = LineInput(1)
                Do
                    If re.IndexOf(pt) = -1 Then re.Add(pt)
                    For j = 0 To data.Count - 1
                        Dim t = data(j).split({" "}, StringSplitOptions.RemoveEmptyEntries)
                        If t(0) = pt Then
                            If re.IndexOf(t(1)) = -1 Then pu.Add(t(1))
                        End If
                    Next
                    If pu.Count = 0 Then Exit Do
                    pt = pu(0) : pu.RemoveAt(0)
                Loop
            Next
            PrintLine(3, re.Count.ToString)
        Next
        Close()
    End Sub
End Class
