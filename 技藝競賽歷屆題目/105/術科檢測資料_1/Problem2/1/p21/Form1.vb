Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For j = 1 To n
                Dim t = LineInput(i).Replace(" ", "").Split("/")
                Dim ip = t(0).Split("."), ipp = t(1).Split(".")
                Dim re(UBound(ip)) As Integer
                For k = 0 To UBound(ip)
                    re(k) = ip(k) And ipp(k)
                Next
                PrintLine(3, String.Join(".", re))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
End Class
