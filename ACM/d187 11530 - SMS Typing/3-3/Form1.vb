Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim t As String = LineInput(1), sum As Integer = 0
            Dim data = {"abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"}
            For j = 0 To Len(t) - 1
                Dim ad As String = t(j).ToString
                If ad = " " Then
                    sum += 1
                Else
                    For k = 0 To UBound(data)
                        Dim pt As Integer = InStr(data(k), ad)
                        If pt > 0 Then sum += pt
                    Next
                End If
            Next
            PrintLine(3, sum.ToString)
        Next
        Close()
    End Sub
End Class
