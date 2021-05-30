Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(t As Integer)
        Dim fib As New ArrayList : fib.Add(0) : fib.Add(1)
        Do
            Dim sum As Integer = fib(fib.Count - 1) + fib(fib.Count - 2)
            If fib.Count = 19 Then Exit Do Else fib.Add(sum)
        Loop
        fib.RemoveAt(0) : fib.RemoveAt(0)
        Dim ans(16) As Integer, summ As Integer = t, test As Boolean = False
        judge(fib, summ, ans, fib.Count - 1, test)
        Array.Reverse(ans)
        Dim result% = Val(String.Join("", ans))
        PrintLine(3, t.ToString & "=" & result.ToString)

    End Sub
    Sub judge(fib As ArrayList, sum As Integer, ans() As Integer, pt As Integer, ByRef test As Boolean)
        For i = pt To 0 Step -1
            Dim ad As Integer = sum - fib(i)
            If ad = 0 Then test = True : ans(i) = 1 : Exit Sub
            If ad > 0 Then
                ans(i) = 1
                judge(fib, ad, ans, i - 2, test)
                If test Then Exit Sub Else ans(i) = 0
            End If
        Next
    End Sub
End Class


