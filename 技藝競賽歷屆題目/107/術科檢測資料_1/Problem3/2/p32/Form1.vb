Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t = Array.ConvertAll(LineInput(i).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
                Dim sum As Integer = 0
                For j = t(0) To t(1)
                    For q = t(2) To t(3)
                        For qq = t(4) To t(5)
                            Dim x1 As Integer = j + q, x2 As Integer = j - q
                            Dim aa As Integer = x1 Mod qq, bb As Integer = 0
                            If x2 < 0 Then
                                x2 = (Math.Abs(x2) Mod qq) * -1
                                If x2 <> 0 Then bb = qq + x2 Else bb = 0
                            Else
                                bb = x2 Mod qq
                            End If
                            If aa = bb Then sum += 1
                        Next
                    Next
                Next
                PrintLine(3, sum.ToString)
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
End Class
