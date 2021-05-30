Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        Dim prime As New ArrayList : prime.Add(2)
        For i = 1 To n
            Dim t As String = LineInput(1)
            If Len(t) <= 10 Then
                Dim tt As Integer = Val(t)
                PrintLine(3, Math.Sqrt(tt).ToString)
            Else
                solve(t)

            End If
        Next
        Close()
    End Sub
    Sub solve(ByVal t As String)
        Dim data As New ArrayList
        If Len(t) Mod 2 = 1 Then data.Add(t(0).ToString) : t = t.Substring(1)
        Do Until t = ""
            data.Add(Mid(t, 1, 2))
            t = t.Substring(2)
        Loop
        Dim tt As String = "", re As String = ""
        Dim tmp As String = "", ad As String = "", last As String = ""
        For i = 0 To data.Count - 1
            tmp &= data(i)
            For j = 0 To 8
                Dim ads As String = ad & (j + 1).ToString
                Dim num As String = xxx(ads, (j + 1).ToString)
                If big(num, tmp) Then re &= j.ToString : ad = add(ad & j.ToString, j.ToString) : tmp = reduce(tmp, last) : Exit For
                If j = 8 Then re &= (j + 1).ToString : ad = add(ads, (j + 1).ToString) : tmp = reduce(tmp, num) : Exit For
                last = num
            Next
            last = ""
        Next
        PrintLine(3, re)
    End Sub
    Function xxx(ByVal x As String, ByVal y As String) As String
        If Len(x) = 1 Or Len(y) = 1 Then Return xx(x, y)
        Dim n1 As Integer = Len(x) \ 2, n2 As Integer = Len(y) \ 2
        Dim a As String = Mid(x, 1, Len(x) - n1), b As String = x.Substring(Len(x) - n1)
        Dim c As String = Mid(y, 1, Len(y) - n2), d As String = y.Substring(Len(y) - n2)
        Dim re1 As String = "", re2 As String = "", re3 As String = "", re4 As String = ""
        If Len(a) = 1 Or Len(c) = 1 Then
            re1 = xx(a, c)
        Else
            re1 = xxx(a, c)
        End If
        If Len(b) = 1 Or Len(d) = 1 Then
            re2 = xx(b, d)
        Else
            re2 = xxx(b, d)
        End If
        Dim x1 As String = add(a, b), y1 As String = add(c, d)
        If Len(x1) = 1 Or Len(y1) = 1 Then
            re3 = xx(x1, y1)
        Else
            re3 = xxx(x1, y1)
        End If
        re4 = reduce(re3, re2) : re4 = reduce(re4, re1)
        Dim ans As String = ""
        For i = 1 To n1
            re1 &= "0"
            For j = 1 To n2
                re1 &= "0"
                re4 &= "0"
            Next
        Next
        ans = add(re1, re2) : ans = add(ans, re4)
        Return ans
    End Function
    Function add(ByVal x As String, ByVal y As String) As String
        Do Until Len(x) = Len(y)
            If Len(x) > Len(y) Then y = "0" & y
            If Len(x) < Len(y) Then x = "0" & x
        Loop
        Dim re As String = "", pt As Integer = 0
        For i = Len(x) - 1 To 0 Step -1
            Dim a As Integer = Val(x(i)), b As Integer = Val(y(i))
            Dim sum As Integer = a + b + pt
            re = (sum Mod 10).ToString & re
            pt = sum \ 10
        Next
        If pt > 0 Then re = pt.ToString & re
        Return re
    End Function
    Function reduce(ByVal x As String, ByVal y As String) As String
        Do Until Len(x) = Len(y)
            y = "0" & y
        Loop
        Dim re As String = "", pt As Integer = 0
        For i = Len(x) - 1 To 0 Step -1
            Dim a As Integer = Val(x(i)), b As Integer = Val(y(i))
            Dim sum As Integer = a - b + pt
            If sum < 0 Then sum += 10 : pt = -1 Else pt = 0
            re = sum.ToString & re
        Next
        Do Until re(0).ToString <> "0" Or Len(re) = 1
            re = re.Substring(1)
        Loop
        Return re
    End Function
    Function xx(ByVal x As String, ByVal y As String) As String
        If Len(x) = 1 Then Dim ad As String = x : x = y : y = ad
        Dim re As String = "", yy As Integer = Val(y), pt As Integer = 0
        For i = Len(x) - 1 To 0 Step -1
            Dim a As Integer = Val(x(i))
            Dim sum As Integer = a * yy + pt
            re = (sum Mod 10).ToString & re
            pt = sum \ 10
        Next
        If pt > 0 Then re = pt.ToString & re
        Return re
    End Function
    Function big(ByVal x As String, ByVal y As String) As Boolean
        If Len(x) > Len(y) Then Return True
        If Len(x) < Len(y) Then Return False
        For i = 0 To Len(x) - 1
            Dim a As Integer = Val(x(i)), b As Integer = Val(y(i))
            If a > b Then Return True
            If a < b Then Return False
        Next
        Return False
    End Function
End Class
