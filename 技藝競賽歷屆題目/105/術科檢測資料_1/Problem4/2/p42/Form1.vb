Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For j = 1 To n
                Dim t = Array.ConvertAll(LineInput(i).Replace(" ", "").Split(","), Function(x) Int32.Parse(x))
                Dim data = New ArrayList(t)
                solve(data)


            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(ByVal data As ArrayList)
        Dim datas = data.Clone
        Dim father, son As New ArrayList
        Do
            data.Sort()
            Dim sum As Integer = data(0) + data(1)
            father.Add(sum) : father.Add(sum) : son.Add(data(0)) : son.Add(data(1))
            data.RemoveRange(0, 2) : data.Add(sum)
            If data.Count = 1 Then Exit Do
        Loop
        Dim re As New ArrayList
        For i = 0 To datas.Count - 1
            Dim sum As Integer = 0
            Dim r As Integer = datas(i)
            Do
                If r = data(0) Then Exit Do
                r = father(son.IndexOf(r))
                sum += 1
            Loop
            re.Add(sum)
        Next
        PrintLine(3, String.Join(",", re.ToArray))
    End Sub
End Class
