Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
        Dim data(t(0), t(0)) As Integer
        For i = 1 To UBound(data)
            For j = 1 To UBound(data, 2)
                data(i, j) = 999999
                If i = j Then data(i, j) = 0
            Next
        Next
        For i = 1 To t(1)
            Dim tmp = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            data(tmp(0), tmp(1)) = tmp(2)
        Next

        For k = 1 To t(0)
            For i = 1 To UBound(data)
                For j = 1 To UBound(data, 2)
                    data(i, j) = Math.Min(data(i, j), data(i, k) + data(k, j))
                Next
            Next
        Next

        For i = 1 To UBound(data)
            For j = 1 To UBound(data, 2)
                Print(3, data(i, j).ToString & " ")
            Next
            PrintLine(3)
        Next

        Close()
    End Sub
End Class
