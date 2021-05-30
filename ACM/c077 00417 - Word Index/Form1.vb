Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim wd As String = "abcdefghijklmnopqrstuvwxyz", data As New ArrayList
        Dim pt As Integer = 1
        Do Until EOF(1)
            Dim t As String = LineInput(1), test As Boolean = True
            For i = 0 To Len(t) - 2
                Dim a As Integer = InStr(wd, t(i)), b As Integer = InStr(wd, t(i + 1))
                If a >= b Then test = False
            Next
            If test Then
                If pt = 1 Then
                    Dim re As New ArrayList
                    For i = 1 To 5
                        combination(data, re, wd, i, 0)
                    Next
                    pt += 1
                End If
                PrintLine(3, (data.IndexOf(t) + 1).ToString)

            Else
                PrintLine(3, "0")
            End If
        Loop

        Close()
    End Sub
    Sub combination(ByVal data As ArrayList, ByVal re As ArrayList, ByVal wd As String, ByVal n As Integer, ByVal pt As Integer)
        If re.Count = n Then
            data.Add(String.Join("", re.ToArray))
        Else
            For i = pt To Len(wd) - 1
                re.Add(wd(i).ToString)
                combination(data, re, wd, n, i + 1)
                re.RemoveAt(re.Count - 1)
            Next
        End If
    End Sub
End Class
