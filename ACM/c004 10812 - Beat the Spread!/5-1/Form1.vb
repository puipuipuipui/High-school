Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim t = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            Dim test As Boolean = True
            If Len(t(1)) > Len(t(0)) Then
                PrintLine(3, "impossible") : test = False
            ElseIf Len(t(1)) = Len(t(0)) Then
                For j = 0 To Len(t(0)) - 1
                    Dim a As Integer = Val(t(0)(j)), b As Integer = Val(t(1)(j))
                    If a > b Then Exit For Else If a < b Then PrintLine(3, "impossible") : test = False : Exit For
                Next
            End If
            If test Then
                Do Until Len(t(0)) = Len(t(1))
                    t(1) = "0" & t(1)
                Loop
                Dim pt As Integer = 0, re As String = ""
                For j = Len(t(0)) - 1 To 0 Step -1
                    Dim a As Integer = Val(t(0)(j)), b As Integer = Val(t(1)(j))
                    Dim sum As Integer = a - b + pt
                    If sum < 0 Then sum += 10 : pt = -1 Else pt = 0
                    re = sum.ToString & re
                Next
                Do
                    If re(0) = "0" Then re = re.Substring(1) Else Exit Do
                Loop
                pt = 0
                Dim res As String = ""
                For j = 0 To Len(re) - 1
                    Dim a As Integer = Val((pt & re(j)))
                    res &= a \ 2 : pt = a Mod 2
                Next
                If pt = 1 Then
                    PrintLine(3, "impossible")
                Else
                    Dim ans1 As String = ""
                    pt = 0
                    Do Until Len(t(1)) = Len(res)
                        If Len(t(1)) > Len(res) Then res = "0" & res
                        If Len(t(1)) < Len(res) Then t(1) = "0" & t(1)
                    Loop
                    For j = Len(res) - 1 To 0 Step -1
                        Dim a As Integer = Val(t(1)(j)), b As Integer = Val(res(j))
                        Dim sum As Integer = a + b + pt
                        ans1 = (sum Mod 10).ToString & ans1 : pt = sum \ 10
                    Next
                    If pt > 0 Then ans1 = pt & ans1
                    Do Until res(0) <> "0" And ans1(0) <> "0"
                        If res(0) = "0" Then res = res.Substring(1)
                        If ans1(0) = "0" Then ans1 = ans1.Substring(1)
                    Loop
                    PrintLine(3, ans1 & " " & res)
                End If


            End If
            

        Next
        Close()
    End Sub
End Class
