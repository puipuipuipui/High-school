Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i).Split({" "}, StringSplitOptions.RemoveEmptyEntries))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(t() As String)
        Dim tmp = Array.ConvertAll(t, Function(x) Int32.Parse(x))
        Dim test As Boolean = True, first As Integer = (tmp(0) - 1) \ 13
        Dim ca, nm As New ArrayList
        For i = 0 To UBound(tmp)
            If first <> (tmp(i) - 1) \ 13 Then test = False
            Dim ad% = tmp(i) Mod 13 : If ad = 0 Then ad = 13
            If ca.IndexOf(ad) = -1 Then ca.Add(ad) : nm.Add(1) Else nm(ca.IndexOf(ad)) += 1
        Next
        Dim card = ca.ToArray, num = nm.ToArray
        If judge(card, test) Then Exit Sub
        Array.Sort(num) : Array.Reverse(num)
        If num(0) = 4 Then PrintLine(3, "四條") : Exit Sub
        If num(0) = 3 And num(1) = 2 Then PrintLine(3, "葫蘆") : Exit Sub
        If num(0) = 3 Then PrintLine(3, "三條") : Exit Sub
        If num(0) = 2 And num(1) = 2 Then PrintLine(3, "兩對") : Exit Sub
        If num(0) = 2 Then PrintLine(3, "一對") : Exit Sub
        PrintLine(3, "雜牌")


    End Sub
    Function judge(card(), test) As Boolean
        For i = 1 To 2
            Array.Sort(card)
            If card(UBound(card)) - card(0) = 4 Then
                If test = True Then PrintLine(3, "同花順") : Return True Else PrintLine(3, "順子") : Return True
            End If
            If Array.IndexOf(card, 1) > -1 Then card(Array.IndexOf(card, 1)) = 14
        Next
        Return False
    End Function
End Class
