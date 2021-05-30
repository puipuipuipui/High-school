Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim q As Integer = LineInput(1)
            Dim t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            If q = 1 Then
                PrintLine(3, "0 0")
            Else
                Dim high As Integer = 0, low As Integer = 0
                For j = 0 To UBound(t) - 1
                    If t(j) > t(j + 1) Then low += 1
                    If t(j) < t(j + 1) Then high += 1
                Next
                PrintLine(3, high.ToString & " " & low.ToString)
            End If
        Next
        Close()
    End Sub
End Class
