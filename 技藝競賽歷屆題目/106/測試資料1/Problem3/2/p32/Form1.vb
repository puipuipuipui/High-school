Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t = LineInput(i).Replace(" ", "").Split(",")
                Dim re As New ArrayList : re.Add(1)
                Dim v(UBound(t)) As Integer : v(0) = 1
                For j = 1 To UBound(t)
                    v(j) = j + 1
                    For q = 0 To re.Count - 1
                        Dim test As Boolean = bigs(t(j), t(re(q) - 1))
                        If test Then re.Insert(q, j + 1) : Exit For
                        If q = re.Count - 1 Then re.Add(j + 1) : Exit For
                    Next
                Next
                Dim result = re.ToArray
                Array.Sort(result, v)
                PrintLine(3, String.Join(",", v))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Function bigs(ByVal x As String, ByVal y As String) As Boolean
        If Len(y) > Len(x) Then Return True
        If Len(y) < Len(x) Then Return False
        For i = 0 To Len(x) - 1
            Dim a As Integer = Val(x(i)), b As Integer = Val(y(i))
            If b > a Then Return True
            If b < a Then Return False
        Next
        Return True
    End Function
End Class
