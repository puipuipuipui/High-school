Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
        Do Until t(0) = 0
            If t(0) - t(1) < t(1) Then t(1) = t(0) - t(1)
            Dim data As New ArrayList
            For i = t(0) To t(0) - t(1) + 1 Step -1
                data.Add(i)
            Next

            For i = 2 To t(1)
                Dim n As Integer = i
                For j = 0 To data.Count - 1
                    If n = 1 Then Exit For
                    Dim gcds As Integer = gcd(n, data(j))
                    n /= gcds : data(j) /= gcds
                Next
            Next
            Dim re As Integer = 1
            For i = 0 To data.Count - 1
                re *= data(i)
            Next
            PrintLine(3, re.ToString)
            t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
        Loop

        Close()
    End Sub
    Function gcd(ByVal a As Integer, ByVal b As Integer) As Integer
        If b = 0 Then Return a
        Return gcd(b, a Mod b)
    End Function
End Class
