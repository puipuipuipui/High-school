Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim tt = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            Dim t = New ArrayList(tt) : t.RemoveAt(0) : Dim tmp = Array.ConvertAll(t.ToArray, Function(x) Int32.Parse(x))
            Dim m As Integer = t(0)
            Dim sum As Integer = tmp.Sum
            If sum Mod 4 <> 0 Then
                PrintLine(3, "no")
            Else
                sum = sum / 4
                Array.Sort(tmp) : Array.Reverse(tmp)
                If tmp(0) > sum Then
                    PrintLine(3, "no")
                Else
                    Dim pt As Integer = 0, tests As Boolean = True, ad As Integer = sum
                    Do
                        For j = 0 To UBound(tmp)
                            If tmp(j) <> 0 Then
                                If ad - tmp(j) >= 0 Then ad -= tmp(j) : tmp(j) = 0
                            End If
                        Next
                        If ad <> 0 Then tests = False : Exit Do
                        ad = sum : pt += 1
                        If pt = 3 Then Exit Do
                    Loop
                    If tests Then
                        If tmp.Sum <> sum Then PrintLine(3, "no") Else PrintLine(3, "yes")
                    Else
                        PrintLine("no")
                    End If
                End If
            End If
        Next
        Close()
    End Sub
End Class
