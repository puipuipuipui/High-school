Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
        Dim v(t(0)), check(t(0)), road(t(0), t(0)) As Integer, ad As Integer = 99999
        For i = 1 To UBound(road)
            check(i) = 1 : v(i) = ad
        Next
        v(1) = 0
        For i = 1 To t(1)
            Dim tmp = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            road(tmp(0), tmp(1)) = tmp(2)
        Next
        solve(v, check, road, 1)
        Dim re = New ArrayList(v) : re.RemoveAt(0)
        PrintLine(3, String.Join(" ", re.ToArray))
        Close()
    End Sub
    Sub solve(ByVal v() As Integer, ByVal check() As Integer, ByVal road(,) As Integer, ByVal n As Integer)
        Dim min As Integer = 99999, minv As Integer = -1 : check(n) = 0
        For i = 1 To UBound(road, 2)
            If road(n, i) <> 0 Then
                If (road(n, i) + v(n)) < min Then minv = i : min = (road(n, i) + v(n))
                v(i) = Math.Min(v(i), road(n, i) + v(n))
            End If
        Next
        If minv <> -1 Then
            If check.Sum > 0 Then solve(v, check, road, minv)
        End If
    End Sub
End Class
