Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim pt As Integer = 1
        Dim tt = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
        Do Until tt(0) = tt(1) And tt(0) = 0
            Dim n1 = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            Dim n2 = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            Dim data(tt(0), tt(1)) As Integer
            For i = 1 To UBound(data)
                For j = 1 To UBound(data, 2)
                    If n1(i - 1) = n2(j - 1) Then
                        data(i, j) = data(i - 1, j - 1) + 1
                    Else
                        data(i, j) = Math.Max(data(i - 1, j), data(i, j - 1))
                    End If
                Next
            Next
            PrintLine(3, "Twin Towers #" & pt.ToString)
            PrintLine(3, "Number of Tiles : " & data(tt(0), tt(1)).ToString)
            PrintLine(3) : pt += 1
            tt = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
        Loop

        Close()
    End Sub
End Class
