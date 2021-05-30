Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t = LineInput(i).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
                solve(t)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(ByVal t() As String)
        Dim wd As String = "+-*/"
        Dim stack As New Stack
        For i = 0 To UBound(t)
            Dim pt As Integer = InStr(wd, t(i))
            If pt = 0 Then
                stack.Push(t(i))
            Else
                Dim b As Integer = Val(stack.Pop), a As Integer = Val(stack.Pop)
                Dim sum As Integer = 0
                If pt = 1 Then
                    sum = a + b
                ElseIf pt = 2 Then
                    sum = a - b
                ElseIf pt = 3 Then
                    sum = a * b
                Else
                    sum = a / b
                End If
                stack.Push(sum)
            End If
        Next
        PrintLine(3, stack(0).ToString)
    End Sub
End Class
