Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t = LineInput(i).Replace("[", "").Replace("]", "").Replace(" ", "").Split(",")
                Dim r As Integer = 0
                For j = 0 To UBound(t)
                    Dim a As Integer = 2 * j + 1, b As Integer = 2 * j + 2
                    Dim test As Boolean = True
                    If a > UBound(t) Then
                        test = False
                    Else
                        If t(a) = "null" Then test = False
                    End If
                    If b > UBound(t) Then
                        test = False
                    Else
                        If t(b) = "null" Then test = False
                    End If
                    If test Then r = j : Exit For
                Next
                Dim re As New ArrayList
                re.Add(solve(t, r, 0, 0))
                Dim max1 As Integer = 0, max2 As Integer = 0
                Dim aa As Integer = 2 * r + 1, bb As Integer = 2 * r + 2
                If aa <= UBound(t) Then judge(t, aa, max1, 1)
                If bb <= UBound(t) Then judge(t, bb, max2, 1)
                re.Add(max1) : re.Add(max2)
                re.Sort()
                If re.Count = 3 Then re.RemoveAt(0) : PrintLine(3, (re(0) + re(1)).ToString) Else Dim result = Array.ConvertAll(re.ToArray, Function(x) Int32.Parse(x)) : PrintLine(3, result.Sum.ToString)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Function solve(ByVal t() As String, ByVal r As Integer, ByVal sum As Integer, ByVal pt As Integer) As Integer
        If pt = r Then Return sum
        Dim a As Integer = 2 * pt + 1, b As Integer = 2 * pt + 2
        If a = r Then Return sum Else If b = r Then Return sum
        If a <= UBound(t) AndAlso t(a) <> "null" Then
            Return solve(t, r, sum + 1, a)
        End If
        If b <= UBound(t) AndAlso t(b) <> "null" Then
            Return solve(t, r, sum + 1, b)
        End If
    End Function
    Sub judge(ByVal t() As String, ByVal r As Integer, ByRef max As Integer, ByVal sum As Integer)
        If t(r) = "null" Then Exit Sub
        Dim a As Integer = 2 * r + 1, b As Integer = 2 * r + 2
        If a <= UBound(t) AndAlso t(a) <> "null" Then
            judge(t, a, max, sum + 1)
        End If
        If b <= UBound(t) AndAlso t(b) <> "null" Then
            judge(t, b, max, sum + 1)
        End If
        max = Math.Max(max, sum)
    End Sub
End Class
