Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim pt As Integer = 0
        Do Until EOF(1)
            pt += 1
            Dim n As Integer = LineInput(1)
            Dim t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            Dim check As New ArrayList, test As Boolean = True

            For i = 0 To UBound(t)
                For j = i To UBound(t)
                    Dim sum As Integer = t(i) + t(j)
                    If check.IndexOf(sum) > -1 Or t(i) < 1 Then PrintLine(3, "Case #" & pt.ToString & ": It is not a B2-Sequence.") : test = False : Exit For
                    If (i + 1) <= UBound(t) Then If t(i) >= t(i + 1) Then PrintLine(3, "Case #" & pt.ToString & ": It is not a B2-Sequence.") : test = False : Exit For
                    check.Add(sum)
                Next
                If Not (test) Then Exit For
            Next
            If test Then PrintLine(3, "Case #" & pt.ToString & ": It is a B2-Sequence.")
        Loop

        Close()
    End Sub
End Class
