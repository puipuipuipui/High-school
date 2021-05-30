Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t As Integer = LineInput(1)
        Dim prime As New ArrayList : prime.Add(2)
        For i = 3 To 100000
            Dim test As Boolean = True
            For j = 0 To prime.Count - 1
                If prime(j) ^ 2 > i Then Exit For
                If i Mod prime(j) = 0 Then test = False : Exit For
            Next
            If test Then prime.Add(i)
        Next

        Do Until t = 0
            Dim tt As Integer = t
            If prime.IndexOf(t) > -1 Then
                PrintLine(3, (t - 1).ToString)
            Else
                Dim test As Boolean = True
                If t > prime(prime.Count - 1) Then
                    For i = 0 To prime.Count - 1
                        If prime(i) ^ 2 > t Then Exit For
                        If t Mod prime(i) = 0 Then test = False : Exit For
                    Next
                Else
                    test = False
                End If
                If test Then
                    PrintLine(3, (t - 1).ToString)
                Else
                    Dim data As New ArrayList
                    For i = 0 To prime.Count - 1
                        If tt Mod prime(i) = 0 Then
                            data.Add(prime(i))
                            Do Until tt Mod prime(i) <> 0
                                tt = tt / prime(i)
                            Loop
                        End If
                        If tt = 1 Then Exit For
                    Next

                    Dim re(data.Count - 1) As Integer
                    For i = 0 To UBound(re)
                        re(i) = t \ data(i)
                    Next
                    Dim ad As New ArrayList
                    For i = 0 To data.Count - 2
                        For j = i + 1 To data.Count - 1
                            Dim gcds As Integer = gcd(data(i), data(j))
                            Dim a As Integer = (data(i) / gcds) * (data(j) / gcds)
                            ad.Add(t \ a)
                        Next
                    Next
                    Dim arrad = Array.ConvertAll(ad.ToArray, Function(x) Int32.Parse(x))
                    Dim result As Integer = re.Sum - arrad.Sum
                    PrintLine(3, (t - result).ToString)
                End If

            End If

            t = LineInput(1)
        Loop
        Close()
    End Sub
    Function gcd(ByVal a As Integer, ByVal b As Integer) As Integer
        If b = 0 Then Return a
        Dim r As Integer = a Mod b
        Return gcd(b, r)
    End Function
End Class
