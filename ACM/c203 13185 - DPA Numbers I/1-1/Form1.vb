Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim pp As Integer = LineInput(1)
        For p = 1 To pp
            Dim n As Integer = LineInput(1)
            Dim re As New ArrayList
            Dim k As Integer = Int(Math.Sqrt(n))
            For i = 1 To k
                Dim q As Integer = n / i
                If n Mod i = 0 Then re.Add(i) : If q <> i Then re.Add(q)
            Next
            re.Remove(n)
            Dim sum = Array.ConvertAll(re.ToArray, Function(x) Int32.Parse(x)).Sum
            If sum = n Then PrintLine(3, "perfect") Else If sum < n Then PrintLine(3, "deficient") Else PrintLine(3, "abundant")
        Next
        Close()
    End Sub
End Class
