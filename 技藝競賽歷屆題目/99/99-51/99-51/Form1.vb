Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            solve(LineInput(i))
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(t As String)
        Dim data1, data2 As New ArrayList
        For i = 0 To Len(t) - 1
            data1.Add(i + 1) : data2.Add(InStr(t, data1(i)))
        Next
        PrintLine(3, String.Join("", data1.ToArray))
        For i = 1 To 7
            Dim test = True, ori As String = String.Join("", data1.ToArray)
            For j = data2.Count - i To data2.Count - 1
                If data2(0) < data2(j) Then
                    data2.Insert(j, data2(0)) : data1.Insert(j, data1(0)) : data2.RemoveAt(0) : data1.RemoveAt(0)
                    test = False : Exit For
                End If
            Next
            If test Then data2.Add(data2(0)) : data1.Add(data1(0)) : data2.RemoveAt(0) : data1.RemoveAt(0)
            If String.Join("", data1.ToArray) = ori Then Exit Sub
            PrintLine(3, String.Join("", data1.ToArray))
        Next

    End Sub
End Class
