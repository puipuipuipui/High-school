Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            solve(n)
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(n As Integer)
        Dim data = "肉菜蛋果魚蝦豆菇"
        Dim tmp As New ArrayList
        For i = 0 To n - 1
            tmp.Add(data(i).ToString)
        Next
        Dim re, result As New ArrayList
        permutation(tmp, re, result, n)
        Dim cant = "肉果 肉豆 肉菇 菜蛋 菜魚 菜豆 菜菇 蛋果 蛋蝦 蛋菇 果魚 果豆 果菇 魚蝦 魚豆 魚菇 蝦豆 豆菇".Split(" ")
        Dim sum As Integer
        For i = 0 To result.Count - 1
            Dim test As Boolean = True
            For j = 0 To UBound(cant)
                If InStr(result(i), cant(j)) > 0 Or InStr(result(i), StrReverse(cant(j))) > 0 Then test = False
            Next
            If test Then PrintLine(3, result(i)) : sum += 1
        Next
        PrintLine(3, sum.ToString)
    End Sub
    Sub permutation(tmp As ArrayList, re As ArrayList, result As ArrayList, n As Integer)
        If re.Count = n Then
            result.Add(String.Join("", re.ToArray))
        Else
            For i = 0 To tmp.Count - 1
                If re.IndexOf(tmp(i)) = -1 Then
                    re.Add(tmp(i))
                    permutation(tmp, re, result, n)
                    re.RemoveAt(re.Count - 1)
                End If
            Next
        End If
    End Sub

End Class
