Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t = LineInput(i).Replace(" ", "").Split("/")
                solve(t)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(ByVal t() As String)
        Dim ip = Array.ConvertAll(t(0).Split("."), Function(x) Int32.Parse(x)), ipp = Array.ConvertAll(t(1).Split("."), Function(x) Int32.Parse(x))
        Dim re1(UBound(ip)) As Integer, re2(UBound(ip)) As Integer
        For i = 0 To UBound(re1)
            re1(i) = ip(i) And ipp(i)
        Next
        Dim ipps(UBound(ipp)) As String
        For i = 0 To UBound(ipp)
            Dim tmp As String = Convert.ToString(ipp(i), 2)
            Do Until Len(tmp) = 8
                tmp = "0" & tmp
            Loop
            For j = 0 To Len(tmp) - 1
                Dim a As Integer = Val(tmp(j))
                If a = 1 Then ipps(i) &= "0" Else ipps(i) &= "1"
            Next
            ipp(i) = Convert.ToInt32(ipps(i), 2)
        Next
        For i = 0 To UBound(re2)
            re2(i) = ip(i) Or ipp(i)
        Next
        PrintLine(3, String.Join(".", re1) & "/" & String.Join(".", re2))
    End Sub
End Class
