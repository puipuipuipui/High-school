Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
        Do Until t(0) = "0"
            Dim k As Integer = Val(t(0))
            Dim data = New ArrayList(t) : data.RemoveAt(0)
            Dim re, result As New ArrayList
            combination(data, 6, re, result, 0)
            For i = 0 To result.Count - 1
                PrintLine(3, result(i))
            Next
            PrintLine(3)
            t = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
        Loop

        Close()
    End Sub
    Sub combination(ByVal data As ArrayList, ByVal n As Integer, ByVal re As ArrayList, ByVal result As ArrayList, ByVal pt As Integer)
        If re.Count = n Then
            result.Add(String.Join(" ", re.ToArray))
        Else
            For i = pt To data.Count - 1
                If re.IndexOf(data(i)) = -1 Then
                    re.Add(data(i))
                    combination(data, n, re, result, i + 1)
                    re.RemoveAt(re.Count - 1)
                End If
            Next
        End If
    End Sub
End Class
