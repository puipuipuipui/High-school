Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        Do Until n = 0
            Dim t = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            Dim re, result As New ArrayList, max As String = "0", ad(UBound(t)) As Integer
            permutation(re, result, t, max, ad)
            PrintLine(3, max)
            n = LineInput(1)
        Loop
        Close()
    End Sub
    Sub permutation(ByVal re As ArrayList, ByVal result As ArrayList, ByVal t() As String, ByRef max As String, ByVal ad() As Integer)
        If re.Count = UBound(t) + 1 Then
            result.Add(String.Join("", re.ToArray))
            Dim pt As String = result(result.Count - 1)
            If Len(pt) > Len(max) Then
                max = pt
            Else
                Do Until Len(pt) = Len(max)
                    pt = "0" & pt
                Loop
                For i = 0 To Len(pt) - 1
                    Dim a As Integer = Val(pt(i)), b As Integer = Val(max(i))
                    If a > b Then max = pt : Exit For
                Next
            End If

        Else
            For i = 0 To UBound(t)
                If ad(i) = 0 Then
                    re.Add(t(i)) : ad(i) = 1
                    permutation(re, result, t, max, ad)
                    re.RemoveAt(re.Count - 1) : ad(i) = 0
                End If
            Next
        End If
    End Sub

End Class
