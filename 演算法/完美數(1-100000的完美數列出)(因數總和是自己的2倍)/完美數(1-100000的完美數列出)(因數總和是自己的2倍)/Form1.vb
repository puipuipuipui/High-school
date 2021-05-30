Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim result As New ArrayList
        For i = 2 To 100000
            Dim re As New ArrayList
            For j = 1 To i
                If j ^ 2 > i Then Exit For
                If i Mod j = 0 Then re.Add(j) : re.Add(i / j)
            Next
            Dim ree = Array.ConvertAll(re.ToArray, Function(x) Int32.Parse(x))
            If ree.Sum = i * 2 Then result.Add(i)
        Next
        Close()
    End Sub
End Class
