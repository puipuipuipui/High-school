Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(t_8 As String)
        Dim t_16 As String = t_8
        Dim ans8 As String = "", ans16 As String = ""
        Do Until Len(t_8) Mod 3 = 0 And Len(t_16) Mod 4 = 0
            If Len(t_8) Mod 3 <> 0 Then t_8 = "0" & t_8
            If Len(t_16) Mod 4 <> 0 Then t_16 = "0" & t_16
        Loop
        Do Until InStr(t_8, "000") <> 1 And InStr(t_16, "0000") <> 1
            If InStr(t_8, "000") = 1 Then ans8 &= "0" : t_8 = t_8.Substring(3)
            If InStr(t_16, "0000") = 1 Then ans16 &= "0" : t_16 = t_16.Substring(4)
        Loop
        Dim a = UCase(Convert.ToString(Convert.ToInt32(t_16, 2), 16))
        Dim b = UCase(Convert.ToString(Convert.ToInt32(t_8, 2), 8))
        PrintLine(3, ans16 & a & "," & ans8 & b)

    End Sub
End Class
