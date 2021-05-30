Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Do Until EOF(1)
            Dim t = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            Dim n As Integer = Val(t(1)), n1 As Integer = Val(t(2))
            Dim tmp As Integer, ad As String = "123456789ABCDEF"
            If n = 10 Then
                tmp = t(0)
            ElseIf n = 2 Or n = 8 Or n = 16 Then
                tmp = Convert.ToInt32(t(0), n)
            Else
                Dim sum As Integer = 0, pt As Integer = 0
                For i = Len(t(0)) - 1 To 0 Step -1
                    Dim a As Integer = InStr(ad, t(0)(i))
                    sum += a * n ^ pt
                    pt += 1
                Next
                tmp = sum
            End If
            Dim result As String = ""
            If n1 = 10 Then
                result = tmp.ToString
            ElseIf n1 = 2 Or n1 = 8 Or n1 = 16 Then
                result = Convert.ToString(tmp, n1)
            Else
                Dim re As String = ""
                Do
                    Dim a As Integer = tmp Mod n1, aa As String = ""
                    If a = 0 Then aa = "0" Else aa = ad(a - 1).ToString
                    re = aa & re : tmp = tmp \ n1
                    If tmp \ n1 = 0 Then
                        a = tmp Mod n1
                        If a = 0 Then aa = "0" Else aa = ad(a - 1).ToString
                        re = aa & re
                        Exit Do
                    End If

                Loop
                result = re
            End If
            If Len(result) > 7 Then
                PrintLine(3, "  ERROR")
            Else
                Do Until Len(result) = 7
                    result = " " & result
                Loop
                PrintLine(3, UCase(result))
            End If
        Loop
        Close()
    End Sub
End Class
