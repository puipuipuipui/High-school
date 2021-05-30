Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For j = 1 To n
                solve(LineInput(i).Split(","), i)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(ByVal t() As String, ByVal q As Integer)
        Dim m As Integer = Val(t(0)), r As Integer = Val(t(1)), n As Integer = Val(t(3))
        Dim A(m, r) As Integer, B(r, n) As Integer, C(m, n) As Integer
        Dim x As Integer = -1, y As Integer = -1, test As Boolean = False
        abc(q, A, m, r, x, y) : If x > -1 Then test = True
        abc(q, B, r, n, x, y) : abc(q, C, m, n, x, y)
        Dim result As Integer = -999
        For k = -20 To 20
            If test Then A(x, y) = k Else B(x, y) = k
            Dim tests As Boolean = True
            For i = 0 To UBound(C)
                For j = 0 To UBound(C, 2)
                    Dim sum As Integer = 0
                    For r = 0 To UBound(B)
                        sum += A(i, r) * B(r, j)
                    Next
                    If C(i, j) <> sum Then tests = False : Exit For
                Next
                If tests = False Then Exit For
            Next
            If tests Then PrintLine(3, k.ToString) : Exit For
        Next
    End Sub
    Sub abc(ByVal q As Integer, ByVal data(,) As Integer, ByVal m As Integer, ByVal n As Integer, ByRef x As Integer, ByRef y As Integer)
        For i = 1 To m
            Dim tt = LineInput(q).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            For j = 0 To n - 1
                If tt(j) = 9999 Then x = i - 1 : y = j
                data(i - 1, j) = Val(tt(j))
            Next
        Next
    End Sub
   
End Class
