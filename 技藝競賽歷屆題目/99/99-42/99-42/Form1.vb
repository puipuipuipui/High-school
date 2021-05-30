Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
                solve(LineInput(i), i)
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(total As Integer, q As Integer)
        Dim fd, mon As New ArrayList
        Do Until EOF(q)
            Dim t = LineInput(q).Replace(" ", "").Split(",")
            fd.Add(t(0)) : mon.Add(t(1))
        Loop
        Dim food = fd.ToArray
        Dim money = Array.ConvertAll(mon.ToArray, Function(x) Int32.Parse(x))
        Dim re, re_money As New ArrayList, sum As Integer = 0
        Dim result As New ArrayList
        Array.Sort(money, food)
        combination(re, re_money, result, money, food, sum, total, 0)
        Dim result_array = result.ToArray, remoney_array = re_money.ToArray
        Array.Sort(remoney_array, result_array)
        For i = UBound(result_array) To 0 Step -1
            PrintLine(3, result_array(i) & " " & remoney_array(i))
        Next
    End Sub
    Sub combination(re As ArrayList, re_money As ArrayList, result As ArrayList, money() As Integer, food() As Object, ByRef sum As Integer, total As Integer, q As Integer)
        For i = q To UBound(money)
            If (sum + money(i)) <= total Then
                re.Add(food(i)) : result.Add(String.Join("", re.ToArray)) : sum += money(i) : re_money.Add(sum)
                combination(re, re_money, result, money, food, sum, total, i + 1)
                sum -= money(i) : re.RemoveAt(re.Count - 1)
            End If
        Next
    End Sub
End Class
