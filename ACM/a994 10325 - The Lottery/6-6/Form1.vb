Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Do Until EOF(1)
            Dim t = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            Dim tmp = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            Dim re As New ArrayList
            For i = 0 To UBound(tmp)
                Dim pt As Integer = 1, last As String = "", test As Boolean = True
                Do
                    Dim check As String = xxx(tmp(i), pt.ToString)
                    If big(t(0), check, test) Then
                        If test Then re.Add(pt) Else re.Add(pt - 1)
                        Exit Do
                    Else
                        last = check
                    End If
                    pt += 1
                Loop
            Next
            Dim gcds_re As New ArrayList
            For i = 0 To UBound(tmp) - 1
                For j = i + 1 To UBound(tmp)
                    Dim gcds As String = gcd(tmp(i), tmp(j))
                    Dim sum As String = xxx(tmp(i), tmp(j))
                    Dim pt As Integer = 1, last As String = "", test As Boolean = True
                    Do
                        Dim check As String = xxx(gcds, pt.ToString)
                        If big(sum, check, test) Then
                            If test Then gcds_re.Add(pt) Else gcds_re.Add(pt - 1)
                            Exit Do
                        Else
                            last = check
                        End If
                        pt += 1
                    Loop
                Next
            Next
            Dim res As New ArrayList
            For i = 0 To gcds_re.Count - 1
                Dim pt As Integer = 1, last As String = "", test As Boolean = True
                Do
                    Dim check As String = xxx(gcds_re(i), pt.ToString)
                    If big(t(0), check, test) Then
                        If test Then res.Add(pt) Else res.Add(pt - 1)
                        Exit Do
                    Else
                        last = check
                    End If
                    pt += 1
                Loop
            Next

            Dim result As String = re(0)
            For i = 1 To re.Count - 1
                result = add(result, re(i))
            Next
            For i = 0 To res.Count - 1
                result = reduce(result, res(i))
            Next
            result = reduce(t(0), result)
            PrintLine(3, result)

        Loop

        Close()
    End Sub
    Function add(ByVal x As String, ByVal y As String) As String
        Do Until Len(x) = Len(y)
            If Len(x) < Len(y) Then x = "0" & x
            If Len(x) > Len(y) Then y = "0" & y
        Loop
        Dim re As String = "", pt As Integer = 0
        For i = Len(x) - 1 To 0 Step -1
            Dim a As Integer = Val(x(i)), b As Integer = Val(y(i))
            Dim sum As Integer = a + b + pt
            re = (sum Mod 10).ToString & re
            pt = sum \ 10
        Next
        If pt > 0 Then re = pt & re
        Return re
    End Function
    Function reduce(ByVal x As String, ByVal y As String) As String
        Do Until Len(x) = Len(y)
            If Len(x) < Len(y) Then x = "0" & x
            If Len(x) > Len(y) Then y = "0" & y
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
    Function xxx(ByVal x As String, ByVal y As String) As String
        If Len(x) = 1 Or Len(y) = 1 Then Return xx(x, y)
        Dim n1 As Integer = Len(x) \ 2, n2 As Integer = Len(y) \ 2
        Dim a As String = Mid(x, 1, Len(x) - n1), b As String = x.Substring(Len(x) - n1)
        Dim c As String = Mid(y, 1, Len(y) - n2), d As String = y.Substring(Len(y) - n2)
        Dim re1 As String = "", re2 As String = "", re3 As String = "", re4 As String = ""
        If Len(a) > 1 And Len(c) > 1 Then re1 = xxx(a, c) Else re1 = xx(a, c)
        If Len(b) > 1 And Len(d) > 1 Then re2 = xxx(b, d) Else re2 = xx(b, d)
        Dim x3 As String = add(a, b), y3 As String = add(c, d)
        If Len(x3) > 1 And Len(y3) > 1 Then re3 = xxx(x3, y3) Else Dim q As Integer = Val(x3), w As Integer = Val(y3) : re3 = (q * w).ToString
        re4 = reduce(re3, re1) : re4 = reduce(re4, re2)
        For i = 1 To n1
            re1 &= "0"
        Next
        For j = 1 To n2
            re1 &= "0"
            re4 &= "0"
        Next
        Dim ans As String = ""
        ans = add(re1, re2) : ans = add(ans, re4)
        Return ans
    End Function
    Function big(ByVal x As String, ByVal y As String, ByRef test As Boolean)
        If Len(y) > Len(x) Then Return True
        If Len(y) < Len(x) Then Return False
        For i = 0 To Len(x) - 1
            Dim a As Integer = Val(x(i)), b As Integer = Val(y(i))
            If b > a Then test = False : Return True
            If b < a Then Return False
        Next
        Return True
    End Function
    Function gcd(ByVal x As String, ByVal y As String) As String
        If y = "0" Then Return x
        Dim pt As Integer = 1, last As String = "", test As Boolean = True
        Do
            Dim check As String = xxx(y, pt.ToString)
            If big(x, check, test) Then
                Dim r As String = ""
                If test Then r = reduce(x, check) Else r = reduce(x, last)
                Return gcd(y, r)
                Exit Do
            Else
                last = check
            End If
            pt += 1
        Loop
    End Function
    Function xx(ByVal x As String, ByVal y As String) As String
        If Len(x) < Len(y) Then Dim ad As String = x : x = y : y = ad
        Dim yy As Integer = Val(y)
        Dim re As String = "", pt As Integer = 0
        For i = Len(x) - 1 To 0 Step -1
            Dim a As Integer = Val(x(i))
            Dim sum As Integer = a * yy + pt
            re = (sum Mod 10).ToString & re
            pt = sum \ 10
        Next
        If pt > 0 Then re = pt.ToString & re
        Return re
    End Function
End Class
