Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            Array.Sort(t)
            If t(0) = t(UBound(t)) Then
                PrintLine(3, "square")
            ElseIf t(0) = t(1) And t(2) = t(3) Then
                PrintLine(3, "rectangle")
            Else
                Dim sum As Integer = t(0) + t(1) + t(2)
                If sum > t(3) Then PrintLine(3, "quadrangle") Else PrintLine(3, "banana")
            End If
        Next
        Close()
    End Sub
End Class
