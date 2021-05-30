Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim wd = "I,V,X,L,C,D,M".Split(","), num = "1,5,10,50,100,500,1000".Split(",")
                Dim t As String = LineInput(i)
                Dim data As New ArrayList
                For j = 0 To Len(t) - 1
                    Dim pt As Integer = Array.IndexOf(wd, t(j).ToString)
                    Dim a As Integer = Val(num(pt))
                    data.Add(a)
                Next
                For j = 1 To data.Count - 1
                    If data(j - 1) < data(j) Then data(j - 1) *= -1
                Next
                Dim re = Array.ConvertAll(data.ToArray, Function(x) Int32.Parse(x))
                PrintLine(3, re.Sum.ToString)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
End Class
