Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        Dim prime As New ArrayList : prime.Add(2)
        For i = 3 To 1000 Step 2
            Dim test As Boolean = True
            For j = 0 To prime.Count - 1
                If prime(j) ^ 2 > i Then Exit For
                If i Mod prime(j) = 0 Then test = False : Exit For
            Next
            If test Then prime.Add(i)
        Next
        For k = 1 To n
            Dim t = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            Dim t1 As Integer = Val(t(0)), t2 As Integer = Val(t(1))
            Dim sum As Integer = 0



            For i = t1 To t2
                If judge(i, prime) Then
                    Dim ad As Integer = 0
                    For j = 0 To Len(i.ToString) - 1
                        Dim q As String = i.ToString
                        Dim a As Integer = Val(q(j))
                        ad += a
                    Next
                    If judge(ad, prime) Then sum += 1
                End If
            Next
            PrintLine(3, sum.ToString)



        Next

        Close()
    End Sub
    Function judge(ByVal n As Integer, ByVal prime As ArrayList) As Boolean
        If n > prime(prime.Count - 1) Then
            Dim test As Boolean = True
            For j = 0 To prime.Count - 1
                If n Mod prime(j) = 0 Then test = False : Exit For
            Next
            If test Then Return True Else Return False
        Else
            If prime.IndexOf(n) = -1 Then Return False Else Return True
        End If
    End Function
End Class
