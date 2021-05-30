Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For k = 1 To n
                Dim t As String = LineInput(i)
                Dim data = "I,V,X,L,C,D,M".Split(","), num = Array.ConvertAll("1,5,10,50,100,500,1000".Split(","), Function(x) Int32.Parse(x))
                Dim sum As Integer = num(Array.IndexOf(data, t(0).ToString)) : t = t.Substring(1)
                If Len(t) = 0 Then
                    PrintLine(3, sum.ToString)
                Else

                    Do
                        Dim a As Integer = sum, b As Integer = num(Array.IndexOf(data, (t(0).ToString)))
                        Dim pt As Integer = 1
                        If b > a Then
                            sum = b - a
                        ElseIf b <= a Then
                            sum = a + b
                            If Len(t) >= 2 Then
                                b = num(Array.IndexOf(data, (t(1).ToString)))
                                If b < a Then
                                    sum += b : pt += 1
                                    If Len(t) >= 3 Then
                                        b = num(Array.IndexOf(data, (t(2).ToString)))
                                        If b < a Then sum += b : pt += 1
                                    End If

                                End If
                            End If

                        End If
                        t = t.Substring(pt)
                        If t = "" Then Exit Do
                    Loop
                    PrintLine(3, sum.ToString)
                End If


            Next
            PrintLine(3)
        Next
        Close()
    End Sub
End Class
