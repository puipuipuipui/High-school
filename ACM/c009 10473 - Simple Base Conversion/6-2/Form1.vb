Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t As String = LineInput(1)
        Do Until InStr(t, "-") > 0
            Dim ad As String = "123456789ABCDEF"
            If InStr(t, "0x") > 0 Then
                t = t.Substring(2)
                Dim sum As String = "0", pt As Integer = 0
                For i = Len(t) - 1 To 0 Step -1
                    Dim a As Integer = InStr(ad, t(i))
                    add(sum, (a * 16 ^ pt))
                    pt += 1
                Next
                PrintLine(3, sum)
            Else
                Dim re As String = "", q As String = "", r As String = ""
                Do Until t = "0"
                    For i = 0 To Len(t) - 1
                        r &= t(i)
                        Dim a As Integer = Val(r)
                        r = (a Mod 16).ToString
                        q &= (a \ 16).ToString
                    Next
                    If r = "0" Then re = "0" & re Else re = Mid(ad, r, 1) & re
                    t = q : r = "" : q = ""
                    Do
                        If Len(t) = 1 Or t(0).ToString <> "0" Then Exit Do
                        t = t.Substring(1)
                    Loop
                Loop
                re = "0x" & re
                PrintLine(3, re)
            End If

            t = LineInput(1)
        Loop

        Close()
    End Sub
    Sub add(ByRef sum As String, ByVal n As String)
        Do Until Len(sum) = Len(n)
            If Len(sum) > Len(n) Then n = "0" & n
            If Len(sum) < Len(n) Then sum = "0" & sum
        Loop
        Dim re As String = "", pt As Integer = 0
        For i = Len(sum) - 1 To 0 Step -1
            Dim a As Integer = Val(sum(i)), b As Integer = Val(n(i))
            Dim summ As Integer = a + b + pt
            re = (summ Mod 10).ToString & re
            pt = summ \ 10
        Next
        If pt > 0 Then re = pt.ToString & re
        sum = re
    End Sub
End Class
