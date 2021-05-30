Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        Dim t As String = LineInput(1)
        For k = 1 To n
            Dim stack As New Stack, re As String = "", wd As String = "0123456789"
            Dim ad = {"+-", "*/"}
            t = LineInput(1)
            Do Until t = ""
                If InStr(wd, t) > 0 Then
                    re &= t
                ElseIf t = "(" Then
                    stack.Push(t)
                ElseIf t = ")" Then
                    Do
                        Dim a As String = stack.Pop
                        If a = "(" Then Exit Do
                        re &= a
                    Loop
                Else
                    If stack.Count = 0 Then
                        stack.Push(t)
                    Else
                        Dim pt_t As Integer = -1, pt_in As Integer = -1
                        For i = 0 To UBound(ad)
                            If InStr(ad(i), t) > 0 Then pt_t = i
                            If InStr(ad(i), stack(0)) > 0 Then pt_in = i
                        Next
                        If pt_t <= pt_in Then
                            re &= stack.Pop
                            stack.Push(t)
                        Else
                            stack.Push(t)
                        End If
                    End If
                End If
                If EOF(1) Then Exit Do
                t = LineInput(1)
            Loop
            If stack.Count > 0 Then
                Do Until stack.Count = 0
                    re &= stack.Pop
                Loop
            End If
            PrintLine(3, re)
            PrintLine(3)
        Next

        Close()
    End Sub
End Class
