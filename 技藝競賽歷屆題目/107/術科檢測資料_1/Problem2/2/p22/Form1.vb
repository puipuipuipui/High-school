Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t = Array.ConvertAll(LineInput(i).Replace(" ", "").Split(","), Function(x) Int32.Parse(x))
                Dim nn As Integer = t(0), kk As Integer = t(UBound(t))
                Dim tmp = New ArrayList(t) : tmp.RemoveAt(0) : tmp.RemoveAt(tmp.Count - 1)
                tmp.Sort()
                Dim re, result As New ArrayList
                permutation(tmp, re, result)
                PrintLine(3, result(kk - 1))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub permutation(ByVal tmp As ArrayList, ByVal re As ArrayList, ByVal result As ArrayList)
        If re.Count = tmp.Count Then
            result.Add(String.Join("", re.ToArray))
        Else
            For i = 0 To tmp.Count - 1
                If re.IndexOf(tmp(i)) = -1 Then
                    re.Add(tmp(i))
                    permutation(tmp, re, result)
                    re.RemoveAt(re.Count - 1)
                End If
            Next
        End If

    End Sub
End Class
