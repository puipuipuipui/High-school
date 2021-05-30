Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        Dim prime As New ArrayList : prime.Add(2)
        For i = 3 To 10
            Dim test As Boolean = True
            For j = 0 To prime.Count - 1
                If prime(j) ^ 2 > i Then Exit For
                If i Mod prime(j) = 0 Then test = False : Exit For
            Next
            If test Then prime.Add(i)
        Next
        For i = 1 To n
            Dim t As Integer = LineInput(1)
            If t = 1 Then
                PrintLine(3, "1")
            Else
                Dim data As New ArrayList
                For j = 0 To prime.Count - 1
                    If t Mod prime(j) = 0 Then
                        Do Until t Mod prime(j) <> 0
                            data.Add(prime(j))
                            t /= prime(j)
                        Loop
                    End If
                Next
                If t <> 1 Then
                    PrintLine(3, "-1")
                Else
                    Dim re As New ArrayList, sum As Integer = 1
                    For j = 0 To data.Count - 1
                        Dim ad As Integer = sum * data(j)
                        If Len(ad.ToString) > 1 Then
                            re.Add(sum) : sum = data(j)
                        Else
                            sum = ad
                        End If
                        If j = data.Count - 1 Then re.Add(sum)
                    Next
                    re.Sort()
                    PrintLine(3, String.Join("", re.ToArray))
                End If
            End If
            
        Next
        Close()
    End Sub
End Class
