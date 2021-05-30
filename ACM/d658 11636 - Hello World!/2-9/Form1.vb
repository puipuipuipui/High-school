Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t As Integer = Val(LineInput(1))
        Dim data As New ArrayList, pt As Integer = 1
        Do
            Dim ad As Integer = 2 ^ pt
            If ad > 10001 Then data.Add(ad) : Exit Do Else data.Add(ad) : pt += 1
        Loop
        Do Until t < 0
            Dim ad As Integer = -1
            If t = 1 Then
                ad = 0
            Else
                For i = 0 To data.Count - 1
                    If data(i) > t Then
                        ad = i
                        If t Mod data(i - 1) > 0 Then ad += 1
                        Exit For
                    End If
                Next
            End If
            PrintLine(3, (ad).ToString)
            t = Val(LineInput(1))
        Loop

        Close()
    End Sub
End Class
