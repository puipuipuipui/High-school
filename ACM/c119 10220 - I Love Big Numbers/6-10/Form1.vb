Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim prime As New ArrayList : prime.Add(2)
        For i = 3 To 1000
            Dim test As Boolean = True
            For j = 0 To prime.Count - 1
                If prime(j) ^ 2 > i Then Exit For
                If i Mod prime(j) = 0 Then test = False : Exit For
            Next
            If test Then prime.Add(i)
        Next
        Do Until EOF(1)
            Dim t As Integer = LineInput(1)
            Dim base, num As New ArrayList
            For k = t To 2 Step -1
                Dim n As Integer = k
                For i = 0 To prime.Count - 1
                    If n Mod prime(i) = 0 Then
                        Dim pt As Integer = 0
                        If base.IndexOf(prime(i)) = -1 Then base.Add(prime(i)) : num.Add(0) : pt = num.Count - 1 Else pt = base.IndexOf(prime(i))
                        Do Until n Mod prime(i) <> 0
                            n /= prime(i)
                            num(pt) += 1
                        Loop
                    End If
                Next
            Next

            Dim data As String = "1"
            For i = 0 To base.Count - 1
                For j = 1 To num(i)
                    Dim re As String = "", pt As Integer = 0
                    For k = Len(data) - 1 To 0 Step -1
                        Dim a As Integer = Val(data(k))
                        Dim sum As Integer = a * base(i) + pt
                        re = (sum Mod 10).ToString & re
                        pt = sum \ 10
                    Next
                    If pt > 0 Then re = pt.ToString & re
                    data = re
                Next
            Next
            Dim result As Integer = 0
            For i = 0 To Len(data) - 1
                Dim a As Integer = Val(data(i))
                result += a
            Next
            PrintLine(3, result.ToString)
        Loop

        Close()
    End Sub
End Class
