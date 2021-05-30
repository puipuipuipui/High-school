Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t As String = LineInput(i)
                Dim data As New ArrayList
                For j = 0 To Len(t) - 1
                    Dim a As Integer = Val(t(j)), ad As Integer = 0
                    If j Mod 2 = 1 Then ad = a Else ad = a * 2
                    Dim sum As Integer = 0, aa As String = ad.ToString
                    For q = 0 To Len(aa) - 1
                        Dim b As Integer = Val(aa(q))
                        sum += b
                    Next
                    data.Add(sum)
                Next
                Dim datas = Array.ConvertAll(data.ToArray, Function(x) Int32.Parse(x))
                If datas.Sum Mod 10 = 0 Then PrintLine(3, "T") Else PrintLine(3, "F")
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
End Class
