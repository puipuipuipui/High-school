Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        Do Until n = 0
            Dim tmp = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            Do Until tmp(0) = 0
                Dim t = Array.ConvertAll(New ArrayList(tmp).ToArray, Function(x) Int32.Parse(x))
                Array.Sort(t)
                If String.Join("", t) = String.Join("", tmp) Then
                    PrintLine(3, "Yes")
                Else
                    Dim A, sta As New Stack, B(UBound(tmp)) As Integer
                    Dim pt As Integer = UBound(tmp) + 1
                    For i = 0 To UBound(tmp)
                        A.Push(pt) : B(i) = tmp(i) : pt -= 1
                    Next

                    solve(A, sta, B)

                End If

                tmp = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            Loop
            PrintLine(3)
            n = LineInput(1)
        Loop
        Close()
    End Sub
    Sub solve(ByVal A As Stack, ByVal sta As Stack, ByVal b() As Integer)
        Dim re_test As Boolean = True
        For i = 0 To UBound(b)
            Dim test As Boolean = True
            Do
                If sta.Count = 0 And A.Count = 0 Then Exit Do
                If sta.Count > 0 Then
                    If b(i) = sta(0) Then sta.Pop() : Exit Do
                End If
                If A.Count > 0 Then
                    If b(i) = A(0) Then A.Pop() : Exit Do Else sta.Push(A.Pop)
                End If
                If A.Count = 0 Then test = False : Exit Do
            Loop
            If Not (test) Then re_test = False : Exit For
        Next
        If re_test Then PrintLine(3, "Yes") Else PrintLine(3, "No")
    End Sub
End Class
