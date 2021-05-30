Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t = LineInput(i).Replace(" ", "").Split("/")
                Dim ip = Array.ConvertAll(t(0).Split("."), Function(x) Int32.Parse(x))
                Dim ipp = Array.ConvertAll(t(1).Split("."), Function(x) Int32.Parse(x))
                Dim re As New ArrayList
                For j = 0 To UBound(ip)
                    Dim b As String = Convert.ToString(ipp(j), 2)
                    Do Until Len(b) = 8
                        If Len(b) < 8 Then b = "0" & b
                    Loop
                    Dim aa As String = "", bb As String = ""
                    For q = 0 To Len(b) - 1
                        Dim ww As Integer = Val(b(q))
                        If ww = 1 Then bb &= "0" Else bb &= "1"
                    Next
                    Dim yy As Integer = Convert.ToInt32(bb, 2)
                    re.Add(ip(j) Or yy)
                Next
                PrintLine(3, String.Join(".", re.ToArray))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
End Class
