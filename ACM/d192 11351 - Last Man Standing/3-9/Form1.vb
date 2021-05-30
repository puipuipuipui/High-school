Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = Val(LineInput(1))
        For q = 1 To n
            Dim t = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            Dim data(t(0) - 1) As Integer, pt As Integer = 0, k As Integer = Val(t(1))
            Do
                For i = 0 To UBound(data)
                    If data(i) = 0 Then
                        pt += 1
                        If pt = k Then data(i) = 1 : pt = 0
                        If data.Sum = t(0) - 1 Then Exit Do
                    End If
                Next
            Loop
            PrintLine(3, (Array.IndexOf(data, 0) + 1).ToString)
        Next
        Close()
    End Sub
End Class
