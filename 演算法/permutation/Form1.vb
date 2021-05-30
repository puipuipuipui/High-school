Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim data = {"蛋", "肉", "菜", "果"}
        Dim re, result As New ArrayList
        permutation(data, re, result)
        FileOpen(3, "out.txt", 2)
        For i = 0 To result.Count - 1
            PrintLine(3, result(i))
        Next
        Close()
    End Sub
    Sub permutation(data() As String, re As ArrayList, result As ArrayList)
        If re.Count = data.Length Then
            result.Add(String.Join("", re.ToArray))
        Else
            For i = 0 To data.Count - 1
                If re.IndexOf(data(i)) = -1 Then
                    re.Add(data(i))
                    permutation(data, re, result)
                    re.RemoveAt(re.Count - 1)
                End If
            Next
        End If
    End Sub
End Class
