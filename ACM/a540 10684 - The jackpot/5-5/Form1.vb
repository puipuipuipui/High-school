Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        Do Until n = 0
            Dim t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            Dim sum(UBound(t)) As Integer : sum(0) = t(0)
            Dim max As Integer = sum(0)
            For i = 1 To UBound(t)
                Dim summ As Integer = t(i) + sum(i - 1)
                If summ > t(i) Then sum(i) = summ Else sum(i) = t(i)
                max = Math.Max(max, sum(i))
            Next
            If max <= 0 Then PrintLine(3, "Losing streak.") Else PrintLine(3, "The maximum winning streak is " & max.ToString & ".")

            n = LineInput(1)
        Loop
        Close()
    End Sub
End Class
