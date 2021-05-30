Public Class Form1
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            solve(i)
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(q As Integer)
        Dim n As Integer = LineInput(q), org(n - 1) As String
        Dim max As Integer = -999999, min As Integer = 9999999, remax As String = -1, remin As String = -1
        For z = 0 To n - 1
            org(z) = LineInput(q)
            Dim t = org(z).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            Dim card(4), flower(4) As Integer
            Dim point, num As New ArrayList
            Dim fl As String = "CDHS"
            For i = 0 To UBound(t)
                Dim fr As Integer = InStr(fl, t(i)(0).ToString), cd As Integer = Val(t(i).Substring(1))
                flower(i) = fr : card(i) = cd
                If point.IndexOf(cd) = -1 Then point.Add(cd) : num.Add(1) Else num(point.IndexOf(cd)) += 1
            Next
            Dim ans As Integer = judge(card, flower, point.ToArray, num.ToArray)
            If max <> Math.Max(max, ans) Then remax = org(z) : max = Math.Max(max, ans)
            If min <> Math.Min(min, ans) Then remin = org(z) : min = Math.Min(min, ans)
        Next
        PrintLine(3, remax) : PrintLine(3, remin)
    End Sub
    Function judge(ByVal card, ByVal flower, ByVal point, ByVal num)
        Array.Sort(num, point) : Array.Reverse(num) : Array.Reverse(point)
        Array.Sort(flower, card) : Array.Reverse(flower) : Array.Reverse(card)
        If num(0) = 4 Then Return 7000 + point(0) * 10 + flower(Array.IndexOf(card, point(0)))
        If num(0) = 3 And num(1) = 2 Then Return 6000 + point(0) * 10 + flower(Array.IndexOf(card, point(0)))
        If num(0) = 3 Then Return 4000 + point(0) * 10 + flower(Array.IndexOf(card, point(0)))
        If num(0) = 2 And num(1) = 2 Then Return 3000 + Math.Max(point(0), point(1)) * 10 + flower(Array.IndexOf(card, Math.Max(point(0), point(1))))
        If num(0) = 2 Then Return 2000 + point(0) * 10 + flower(Array.IndexOf(card, point(0)))
        Array.Sort(point)
        If flower(0) = flower(4) Then
            If point(4) - point(0) = 4 Then Return (8000 + point(0) * 10 + flower(0))
            If point(0) = 1 And point(1) = 10 And point(4) = 13 Then Return 8000 + point(0) * 10 + flower(0)
        Else
            If point(4) - point(0) = 4 Then Return (5000 + point(0) * 10 + flower(0))
            If point(0) = 1 And point(1) = 10 And point(4) = 13 Then Return 5000 + point(0) * 10 + flower(0)
        End If
        Return 1000 + point(4) * 10 + flower(0)
    End Function

End Class
