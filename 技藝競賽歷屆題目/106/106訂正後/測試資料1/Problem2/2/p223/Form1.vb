Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t = Array.ConvertAll(LineInput(i).Replace(" ", "").Split(","), Function(x) Int32.Parse(x))
                Dim re, result As New ArrayList
                permutation(t(0).ToString, re, result)
                Dim xx As String = result(t(1) - 1), yy As String = result(t(2) - 1)
                Dim A As Integer = 0, B As Integer = 0
                For j = 0 To Len(yy) - 1
                    Dim aa As String = yy(j).ToString
                    Dim pt As Integer = InStr(xx, aa)
                    If pt > 0 Then
                        If pt = j + 1 Then A += 1 Else B += 1
                    End If
                Next
                PrintLine(3, A.ToString & "A" & B.ToString & "B")
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub permutation(ByVal n As String, ByVal re As ArrayList, ByVal result As ArrayList)
        If re.Count = Len(n) Then
            result.Add(String.Join("", re.ToArray))
        Else
            For i = 0 To Len(n) - 1
                Dim a As String = n(i).ToString
                If re.IndexOf(a) = -1 Then
                    re.Add(a)
                    permutation(n, re, result)
                    re.RemoveAt(re.Count - 1)
                End If
            Next
        End If
    End Sub
End Class
