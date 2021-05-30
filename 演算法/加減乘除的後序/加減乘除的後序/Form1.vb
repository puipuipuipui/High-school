Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tmp As String = "(a+b)*(c+d)"
        Dim ad = "-+,/*,(,)".Split(",")
        Dim stack As New Stack
        Dim result As String = ""
        For i = 0 To Len(tmp) - 1
            Dim t As String = tmp(i).ToString
            Dim ptin As Integer = -1
            Dim pt As Integer = -1
            For j = 0 To UBound(ad)
                If InStr(ad(j), t) > 0 Then pt = j
                If InStr(ad(j), stack(0)) > 0 Then ptin = j
            Next


            If pt = -1 Then
                result &= t
            Else

                If t = "(" Then
                    stack.Push(t)
                ElseIf t = ")" Then
                    Dim temp As String = stack.Pop
                    Do Until temp = "("
                        result &= temp
                        temp = stack.Pop
                    Loop
                Else


                    If stack.Count = 0 Or stack(0) = "(" Then
                        stack.Push(t)
                    Else
                        If ptin < pt Then
                            stack.Push(t)
                        Else
                            Do
                                ptin = -1
                                For j = 0 To UBound(ad)
                                    If InStr(ad(j), stack(0)) > 0 Then ptin = j
                                Next
                                If ptin >= pt Then result &= stack.Pop Else stack.Push(t) : Exit Do
                                If stack.Count = 0 Then stack.Push(t) : Exit Do
                            Loop
                        End If
                    End If


                End If
            End If
        Next
        Do Until stack.Count = 0
            result &= stack.Pop
        Loop

    End Sub
End Class
