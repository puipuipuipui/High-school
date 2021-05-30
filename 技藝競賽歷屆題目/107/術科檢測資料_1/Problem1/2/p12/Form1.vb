Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim data(2, 2) As Integer, tmp As New ArrayList, test As Boolean = True
                For q = 0 To 2
                    tmp.Add(LineInput(i).Replace(" ", ""))
                Next
                For j = 0 To 2
                    If tmp(j) = "111" Then PrintLine(3, "1") : test = False : Exit For Else If tmp(j) = "222" Then PrintLine(3, "2") : test = False : Exit For
                    For q = 0 To 2
                        Dim t As String = tmp(j)(q).ToString
                        data(j, q) = t
                    Next
                Next
                If test Then
                    For j = 0 To 2
                        If data(0, j) = data(1, j) And data(1, j) = data(2, j) Then
                            If data(0, j) = "1" Then PrintLine(3, "1") : test = False Else If data(0, j) = "2" Then PrintLine(3, "2") : test = False
                        End If
                    Next
                End If
                If test Then
                    If (data(0, 0) = data(1, 1) And data(1, 1) = data(2, 2)) Or (data(0, 2) = data(1, 1) And data(1, 1) = data(2, 0)) Then
                        If data(1, 1) = "1" Then PrintLine(3, "1") Else If data(1, 1) = "2" Then PrintLine(3, "2") : test = False
                    End If
                End If
                If test Then PrintLine(3, "3")
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
End Class
