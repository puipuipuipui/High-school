Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i).Split(","), i)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(n() As String, q As Integer)
        Dim nn = Array.ConvertAll(n, Function(x) Int32.Parse(x))
        Dim A(nn(0) - 1, nn(1) - 1), B(nn(2) - 1, nn(3) - 1), AB(nn(0) - 1, nn(3) - 1) As Integer
        Dim test As Boolean = False, xx% = -1, yy As Integer = -1
        For i = 0 To UBound(A)
            Dim t = LineInput(q).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            For j = 0 To UBound(A, 2)
                Dim aa As Integer = Val(t(j))
                If aa = 9999 Then test = True : xx = i : yy = j
                A(i, j) = aa
            Next
        Next
        For i = 0 To UBound(B)
            Dim t = LineInput(q).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            For j = 0 To UBound(B, 2)
                Dim bb As Integer = Val(t(j))
                If bb = 9999 Then test = False : xx = i : yy = j
                B(i, j) = bb
            Next
        Next
        For i = 0 To UBound(AB)
            Dim t = LineInput(q).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            For j = 0 To UBound(AB, 2)
                Dim abb As Integer = Val(t(j))
                AB(i, j) = abb
            Next
        Next

        Dim testss As Boolean = True
        For i = -20 To 20
            Dim sum As Integer = 0 : testss = True
            If test Then
                A(xx, yy) = i
                For j = 0 To UBound(B, 2)
                    sum = 0
                    For k = 0 To UBound(A, 2)
                        sum += A(xx, k) * B(k, j)
                    Next
                    If AB(xx, j) <> sum Then testss = False
                Next
                If testss Then PrintLine(3, i.ToString) : Exit Sub
            Else
                B(xx, yy) = i
                For j = 0 To UBound(A)
                    sum = 0
                    For k = 0 To UBound(B)
                        sum += A(j, k) * B(k, yy)
                    Next
                    If AB(j, yy) <> sum Then testss = False
                Next
                If testss Then PrintLine(3, i.ToString) : Exit Sub
            End If
        Next
    End Sub
End Class
