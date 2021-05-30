Module Module1

    Sub Main()
        Dim t As String = Console.ReadLine()
        Dim tmp = t.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
        Dim ad(1) As Integer, data(3) As Integer
        Console.WriteLine("x = " & tmp(0) & ", " & "y = " & tmp(1))
        judge(tmp, ad, data)
        Dim re1 As Integer = data(0) * data(2), re2 As Integer = data(1) * data(3), re4 As Integer = data(0) * data(3) + data(1) * data(2)
        Dim sum As Integer = re1 + re2 + re4
        Console.WriteLine(sum.ToString)

        Console.Read()
    End Sub
    Sub judge(ByVal tmp() As String, ByVal ad() As Integer, ByVal data() As Integer)
        If Len(tmp(0)) = 1 Or Len(tmp(1)) = 1 Then data(0) = tmp(0) : data(2) = tmp(1) : Exit Sub
        Dim n1 As Integer = Len(tmp(0)), n2 As Integer = Len(tmp(1))
        If n1 Mod 2 = 1 Then n1 -= 1 : If n2 Mod 2 = 1 Then n2 -= 1
        n1 = n1 / 2 : n2 = n2 / 2
        Dim a As String = Mid(tmp(0), 1, Len(tmp(0)) - n1), b As String = tmp(0).Substring(Len(tmp(0)) - n1)
        Dim c As String = Mid(tmp(1), 1, Len(tmp(1)) - n2), d As String = tmp(1).Substring(Len(tmp(1)) - n2)
        Console.WriteLine("x = " & a & ", " & "y = " & c)
        tmp(0) = a : tmp(1) = c
        If Len(a) > 1 And Len(c) > 1 Then judge(tmp, ad, data)
        Console.WriteLine("x = " & b & ", " & "y = " & d)
        tmp(0) = b : tmp(1) = d
        If Len(b) > 1 And Len(d) > 1 Then judge(tmp, ad, data)
        Dim sum1 As Integer = Val(a) + Val(b), sum2 As Integer = Val(c) + Val(d)
        Console.WriteLine("x = " & sum1.ToString & ", " & "y = " & sum2.ToString)
        tmp(0) = sum1 : tmp(1) = sum2
        If Len(sum1.ToString) > 1 And Len(sum2.ToString) > 1 Then judge(tmp, ad, data)
        data(0) = Val(a) * 10 ^ n1 : data(1) = Val(b) : data(2) = Val(c) * 10 ^ n2 : data(3) = Val(d)
    End Sub
End Module
