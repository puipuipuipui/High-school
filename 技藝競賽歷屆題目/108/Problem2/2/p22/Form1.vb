Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t As Integer = LineInput(i)
                Dim tmp As String = t.ToString
                Dim sum As Integer = 0, pt As Integer = Len(tmp)
                For j = 0 To pt - 1
                    Dim a As Integer = Val(tmp(j))
                    sum += a ^ pt
                Next
                If sum = t Then PrintLine(3, "Y") Else PrintLine(3, "N")
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
End Class
