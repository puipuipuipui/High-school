Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim t As String = "a2[b3[c]3[d]]2[e]"
        Dim result As New ArrayList
        solve(t, result)
        Dim re As String = String.Join("", result.ToArray)

        Close()
    End Sub
    Sub solve(ByVal t As String, ByVal result As ArrayList)
        Dim ad As String = "0123456789"
        Do Until t = ""
            For i = 0 To Len(t) - 1
                If InStr(ad, t(i)) > 0 Then
                    Dim n As Integer = Val(t(0))
                    Dim L, R As Integer
                    For j = 1 To Len(t) - 1
                        If t(j) = "[" Then L += 1
                        If t(j) = "]" Then R += 1
                        If L = R Then
                            For k = 1 To n
                                solve(Mid(t, 3, j - 2), result)
                            Next
                            t = t.Substring(j + 1)
                            Exit For
                        End If
                    Next
                Else
                    result.Add(t(0))
                    t = t.Substring(1)
                End If
                Exit For
            Next

        Loop

    End Sub
End Class
