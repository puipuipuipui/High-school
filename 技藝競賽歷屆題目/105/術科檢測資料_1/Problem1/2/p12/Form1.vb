Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For j = 1 To n
                Dim wd = "----- .---- ..--- ...-- ....- ..... -.... --... ---.. ----.".Split({" "}, StringSplitOptions.RemoveEmptyEntries)
                Dim t As String = LineInput(i).Replace(" ", "")
                Dim re As String = ""
                Do Until t = ""
                    For k = 0 To UBound(wd)
                        Dim a As Integer = InStr(t, wd(k))
                        If a = 1 Then re &= k.ToString : t = t.Substring(5) : Exit For
                    Next
                Loop
                PrintLine(3, re)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
End Class
