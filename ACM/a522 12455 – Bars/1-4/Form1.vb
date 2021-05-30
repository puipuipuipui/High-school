Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim check As Integer = LineInput(1)
            Dim ad As Integer = LineInput(1)
            Dim t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            If check = 0 Then
                PrintLine(3, "YES")
            Else
                Dim test As Boolean = False
                For j = 1 To ad
                    Dim re As New ArrayList
                    combination(t, test, j, re, check)
                    If test Then Exit For
                Next
                If test Then PrintLine(3, "YES") Else PrintLine(3, "NO")
            End If
        Next
        Close()
    End Sub
    Sub combination(ByVal t() As Integer, ByRef test As Boolean, ByVal r As Integer, ByVal re As ArrayList, ByVal check As Integer)
        If re.Count = r Then
            Dim res = Array.ConvertAll(re.ToArray, Function(x) Int32.Parse(x))
            If res.Sum = check Then test = True : Exit Sub
        Else
            For i = 0 To UBound(t)
                If re.IndexOf(t(i)) = -1 Then
                    re.Add(t(i))
                    combination(t, test, r, re, check)
                    If test Then Exit Sub
                    re.RemoveAt(re.Count - 1)
                End If
            Next
        End If
    End Sub
End Class
