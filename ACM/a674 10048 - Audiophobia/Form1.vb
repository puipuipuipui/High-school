Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim pt As Integer = 1
        Dim t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
        Do Until t.Sum = 0
            Dim map(t(0), t(0)) As Integer, ad As Integer = 99999
            For i = 1 To UBound(map)
                For j = 1 To UBound(map, 2)
                    If i = j Then map(i, j) = 0 Else map(i, j) = ad
                Next
            Next
            For i = 1 To t(1)
                Dim tmp = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
                map(tmp(0), tmp(1)) = tmp(2) : map(tmp(1), tmp(0)) = tmp(2)
            Next
            For k = 1 To t(0)
                For i = 1 To UBound(map)
                    For j = 1 To UBound(map, 2)
                        map(i, j) = Math.Min(map(i, j), Math.Max(map(i, k), map(k, j)))
                    Next
                Next
            Next
            PrintLine(3, "Case #" & pt.ToString)
            For i = 1 To t(2)
                Dim q = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
                Dim re As Integer = map(q(0), q(1))
                If re = ad Then PrintLine(3, "no path") Else PrintLine(3, re.ToString)
            Next
            t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            PrintLine(3) : pt += 1
        Loop
        
        Close()
    End Sub

End Class
