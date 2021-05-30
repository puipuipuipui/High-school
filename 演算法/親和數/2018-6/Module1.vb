Module Module1

    Sub Main()
        Dim t As String = Console.ReadLine()
        Dim tmp = t.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
        Dim A, B As New ArrayList
        solve(tmp(0), A) : solve(tmp(1), B)
        Dim rea = Array.ConvertAll(A.ToArray, Function(x) Int32.Parse(x)), reb = Array.ConvertAll(B.ToArray, Function(x) Int32.Parse(x))
        If rea.Sum = tmp(1) And reb.Sum = tmp(0) Then Console.WriteLine("true") Else Console.WriteLine("false")
        Console.Read()
    End Sub
    Sub solve(ByVal n As Integer, ByVal data As ArrayList)
        For i = 1 To n
            If i ^ 2 > n Then Exit For
            If n Mod i = 0 Then
                data.Add(i)
                If n / i <> n And n / i <> i Then data.Add(n / i)
            End If
        Next

    End Sub
End Module
