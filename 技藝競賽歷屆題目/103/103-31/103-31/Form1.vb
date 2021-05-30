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
        Dim max As Integer = -999
        For i = 0 To UBound(tmp)
            Dim data = New ArrayList(tmp) : data.RemoveAt(i)
            Dim test As Boolean = True, first = (data(0) - 1) \ 13
            Dim card, num As New ArrayList
            For j = 0 To data.Count - 1
                If first <> (data(j) - 1) \ 13 Then test = False
                Dim ad = data(j) Mod 13 : If ad = 0 Then ad = 13
                If card.IndexOf(ad) = -1 Then card.Add(ad) : num.Add(1) Else num(card.IndexOf(ad)) += 1
            Next
            Dim point As Integer = judge(card, num, test)
            max = Math.Max(max, point)
        Next
        PrintLine(3, max.ToString)
    End Sub
    Function judge(ca As ArrayList, nm As ArrayList, test As Boolean) As Integer
        Dim num = nm.ToArray, card = ca.ToArray
        Array.Sort(card) : Array.Sort(num) : Array.Reverse(num)
        If num(0) = 4 Then Return 6
        If num(0) = 3 And num(1) = 2 Then Return 5
        If num(0) = 3 Then Return 3
        If num(0) = 2 And num(1) = 2 Then Return 2
        If num(0) = 2 Then Return 1
        If test Then
            If card(4) - card(0) = 4 Then Return 7
            If card(0) = 1 And card(1) = 10 And card(4) = 13 Then Return 7
        Else
            If card(4) - card(0) = 4 Then Return 4
            If card(0) = 1 And card(1) = 10 And card(4) = 13 Then Return 4
        End If

        Return 0
    End Function
End Class
