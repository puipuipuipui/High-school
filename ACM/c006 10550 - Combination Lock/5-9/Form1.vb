Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Do
            Dim t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            If t.Sum = 0 Then Exit Do
            Dim sum As Integer = 360 * 3, pt As Integer = 0, ad As Integer = 360 / 40
            If t(0) > t(1) Then pt += t(0) - t(1) Else pt += 40 - t(1) + t(0)
            If t(1) > t(2) Then pt += 40 - t(1) + t(2) Else pt += t(2) - t(1)
            If t(2) > t(3) Then pt += t(2) - t(3) Else pt += 40 - t(3) + t(2)
            sum += pt * ad
            PrintLine(3, sum.ToString)
        Loop

        Close()
    End Sub
   
End Class
