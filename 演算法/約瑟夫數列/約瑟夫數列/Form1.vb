Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        FileOpen(1, "out.txt", 2)
        Dim data(40), pt, sum, da(40) As Integer
        pt = 1 : sum = 1
        Do
            For i = 0 To UBound(data)
                da(i) = i + 1
                If pt = 3 And data(i) = 0 Then data(i) = sum : pt = 1 : sum += 1
                If data(i) = 0 Then pt += 1
            Next
            If Array.IndexOf(data, 0) = -1 Then Exit Do
        Loop
        '41,40,39,38,37
        Array.Sort(data, da)
        For i = 40 To 36 Step -1
            PrintLine(1, da(i).ToString)
        Next

        Close()

    End Sub
End Class
