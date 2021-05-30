Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim data As New ArrayList
        For i = 1 To 100000
            If Math.Sqrt(i) * 10 Mod 10 = 0 Then data.Add(i)
        Next

        Do
            Dim sum As Integer = 0
            Dim t = LineInput(1).Split({" "}, StringSplitOptions.None)
            If t(0) = 0 Then Exit Do
            For i = 0 To data.Count - 1
                If data(i) >= t(0) And data(i) <= t(1) Then sum += 1
            Next
            PrintLine(3, sum.ToString)
        Loop
        Close()
    End Sub
End Class
