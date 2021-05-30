Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            Dim re As New ArrayList, max As Integer = -999999, retest(UBound(t)) As Boolean
            combination(t, re, max, retest)
            PrintLine(3, max.ToString)
        Next
        Close()
    End Sub
    Sub combination(ByVal t() As Integer, ByVal re As ArrayList, ByRef max As Integer, ByVal retest() As Boolean)
        If re.Count = 2 Then
            gcd(re(0), re(1), max)
        Else
            For i = 0 To UBound(t)
                If Not (retest(i)) Then
                    re.Add(t(i)) : retest(i) = True
                    combination(t, re, max, retest)
                    retest(i) = False : re.RemoveAt(re.Count - 1)
                End If
            Next
        End If
    End Sub
    Sub gcd(ByVal a As Integer, ByVal b As Integer, ByRef max As Integer)
        Dim r As Integer = a Mod b
        If r = 0 Then
            If max <> a Then max = Math.Max(max, b)
        Else
            gcd(b, r, max)
        End If
    End Sub
End Class
