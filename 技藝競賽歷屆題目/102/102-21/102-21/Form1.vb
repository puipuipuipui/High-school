Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(t As String)
        Dim tmp = Split(t.Replace(" ", ""), "},{")
        Dim A = tmp(0).Replace("{", "").Replace("}", "").Split(","), B = tmp(1).Replace("{", "").Replace("}", "").Split(",")
        Array.Sort(A) : Array.Sort(B)
        Dim uni, int, setd, sym As New ArrayList
        For i = 0 To UBound(A)
            uni.Add(A(i))
            If Array.IndexOf(B, A(i)) > -1 Then int.Add(A(i)) Else setd.Add(A(i))
        Next
        For i = 0 To UBound(B)
            If uni.IndexOf(B(i)) = -1 Then uni.Add(B(i))
        Next
        For i = 0 To uni.Count - 1
            If int.IndexOf(uni(i)) = -1 Then sym.Add(uni(i))
        Next
        Dim result As New ArrayList : uni.Sort() : int.Sort() : setd.Sort() : sym.Sort()
        result.Add(String.Join(", ", uni.ToArray)) : result.Add(String.Join(", ", int.ToArray))
        result.Add(String.Join(", ", setd.ToArray)) : result.Add(String.Join(", ", sym.ToArray))
        For i = 0 To result.Count - 1
            If Len(result(i)) = 0 Then result(i) = "N" Else result(i) = "{" & result(i) & "}"
        Next
        PrintLine(3, String.Join(", ", result.ToArray))
    End Sub
   
    
End Class
