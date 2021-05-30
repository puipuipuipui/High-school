Module Module1

    Sub Main()
        Dim tmp As String = Console.ReadLine
        Dim tt As String = tmp.Replace("+", "#").Replace("-", "#").Replace("*", "#").Replace("/", "#").Replace("^", "#").Replace(".", "#")
        If tt.IndexOf("##") > -1 Then
            Console.WriteLine("N/A")
        Else
            For i = 0 To 9
                tt = tt.Replace(i.ToString, "#")
            Next
            Do Until tt = tt.Replace("##", "#")
                tt = tt.Replace("##", "#")
            Loop
            tt = tt.Replace("(#)", "")
            If tt.IndexOf("(") > -1 Or tt.IndexOf(")") > -1 Then
                Console.WriteLine("N/A")
            Else
                Console.WriteLine(solve(tmp))
            End If
        End If
        Console.Read()
    End Sub
    Function solve(ByVal t As String) As String
        Dim ad = {"()", "-+", "*/", "^"}
        t = t.Replace("+", " + ").Replace("-", " - ").Replace("*", " * ").Replace("/", " / ").Replace("^", " ^ ").Replace("(", " ( ").Replace(")", " ) ")
        Dim tmp = t.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
        Dim num, sign As New Stack
        Dim sum As Single = 0
        For i = 0 To UBound(tmp)
            Dim test As Boolean = True
            Dim pt As Integer = 0, tt As String = ""
            For j = 0 To UBound(ad)
                If InStr(ad(j), tmp(i)) > 0 Then pt = InStr(ad(j), tmp(i)) - 1 : tt = ad(j)(pt) : test = False : Exit For
            Next
            If test Then
                num.Push(tmp(i))
            Else
                If tt = "(" Then
                    sign.Push("(")
                ElseIf tt = ")" Then
                    Dim add As String = sign.Pop
                    Do Until add = "("
                        sum = judge(num.Pop, num.Pop, add)
                        num.Push(sum) : add = sign.Pop
                    Loop
                Else
                    If sign.Count <> 0 Then
                        Dim A, B As Integer
                        For k = 0 To UBound(ad)
                            If InStr(ad(k), tt) > 0 Then A = k
                            If InStr(ad(k), sign(0)) > 0 Then B = k
                        Next
                        If A > B Then
                            sign.Push(tt)
                        Else
                            sum = judge(num.Pop, num.Pop, sign.Pop)
                            num.Push(sum) : sign.Push(tt)
                        End If
                    Else
                        sign.Push(tt)
                    End If

                End If
            End If
        Next
        Do Until num.Count = 1
            sum = judge(num.Pop, num.Pop, sign.Pop)
            num.Push(sum)
        Loop
        Dim result = num.Pop : result = Int(result * 100 + 0.5) / 100
        Return result.ToString
    End Function
    Function judge(ByVal a As Single, ByVal b As Single, ByVal sign As String) As Single
        If sign = "+" Then
            Return a + b
        ElseIf sign = "-" Then
            Return b - a
        ElseIf sign = "*" Then
            Return a * b
        ElseIf sign = "/" Then
            Return b / a
        Else
            Return b ^ a
        End If
    End Function
End Module
