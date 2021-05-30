Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim data = Array.ConvertAll({1, 2, 3, 4}, Function(x) x.ToString)
        Dim re As New ArrayList, result As New ArrayList
        Dim n As Integer = data.Length, r As Integer = 3
        combination(data, re, result, n, 0, r)
        FileOpen(3, "out.txt", 2)
        For i = 0 To result.Count - 1
            PrintLine(3, result(i))
        Next
        '從n個取r個
        Close()
    End Sub
    Sub combination(ByVal data() As String, ByVal re As ArrayList, ByVal result As ArrayList, ByVal n As Integer, ByVal pt As Integer, ByVal r As Integer)
        If re.Count = r Then
            Dim re_arr = re.ToArray
            result.Add(String.Join("", re_arr))
        Else
            For i = pt To UBound(data)
                re.Add(data(i))
                combination(data, re, result, n, i + 1, r)
                re.RemoveAt(re.Count - 1)
            Next
        End If
    End Sub
End Class
