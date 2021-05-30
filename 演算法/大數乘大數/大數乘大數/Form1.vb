Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim x As String = "987", y As String = "123"
        Dim result As String = solve(x, y)

        Close()
    End Sub
    Function solve(ByVal x As String, ByVal y As String) As String
        Dim nx As Integer = Len(x) \ 2, ny As Integer = Len(y) \ 2
        Dim a As String = Mid(x, 1, Len(x) - nx), b As String = x.Substring(Len(x) - nx)
        Dim c As String = Mid(y, 1, Len(y) - ny), d As String = y.Substring(Len(y) - ny)
        Dim re1 As String = "", re2 As String = "", re3 As String = "", re4 As String = ""


        If Len(a) > 1 And Len(c) > 1 Then
            re1 = solve(a, c)
        Else
            Dim q As Integer = Val(a), w As Integer = Val(c)
            re1 = (q * w).ToString
        End If

        If Len(b) > 1 And Len(d) > 1 Then
            re2 = solve(b, d)
        Else
            Dim q As Integer = Val(b), w As Integer = Val(d)
            re2 = (q * w).ToString
        End If

        Dim x3 As String = add(a, b), y3 As String = add(c, d)
        If Len(x3) > 1 And Len(y3) > 1 Then
            re3 = solve(x3, y3)
        Else
            Dim q As Integer = Val(x3), w As Integer = Val(y3)
            re3 = (q * w).ToString
        End If


        re4 = reduce(re3, re1) : re4 = reduce(re4, re2)
        For i = 1 To nx
            re1 = re1 & "0"
        Next
        For i = 1 To ny
            re1 &= "0"
            re4 &= "0"
        Next
        Dim ans As String = add(re1, re2) : ans = add(ans, re4)
        Return ans

    End Function
    Function add(ByVal a As String, ByVal b As String) As String
        Do Until Len(a) = Len(b)
            If Len(a) < Len(b) Then a = "0" & a
            If Len(a) > Len(b) Then b = "0" & b
        Loop
        Dim re As String = "", pt As Integer = 0
        For i = Len(a) - 1 To 0 Step -1
            Dim x As Integer = Val(a(i)), y As Integer = Val(b(i))
            Dim sum As Integer = x + y + pt
            re = (sum Mod 10).ToString & re
            pt = sum \ 10
        Next
        If pt > 0 Then re = pt.ToString & re
        Return re
    End Function
    Function reduce(ByVal a As String, ByVal b As String) As String
        Do Until Len(a) = Len(b)
            If Len(a) < Len(b) Then a = "0" & a
            If Len(a) > Len(b) Then b = "0" & b
        Loop
        Dim re As String = "", pt As Integer = 0
        For i = Len(a) - 1 To 0 Step -1
            Dim x As Integer = Val(a(i)), y As Integer = Val(b(i))
            Dim sum As Integer = x - y + pt
            If sum < 0 Then sum += 10 : pt = -1 Else pt = 0
            re = sum.ToString & re
        Next
        Do Until re(0).ToString <> "0"
            re = re.Substring(1)
        Loop
        Return re
    End Function
End Class
