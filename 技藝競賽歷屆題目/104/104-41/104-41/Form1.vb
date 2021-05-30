Public Class Form1
    Structure tr
        Dim data, lchild, rchild As Integer
    End Structure
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i), LineInput(i).Split(","))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(n As Integer, t() As String)
        Dim tmp = Array.ConvertAll(t, Function(x) Int32.Parse(x))
        Dim orgdata(n - 1) As tr
        For i = 0 To UBound(tmp)
            orgdata(i).data = tmp(i) : orgdata(i).lchild = -1 : orgdata(i).rchild = -1
        Next

        For i = 1 To UBound(tmp)
            Dim pt As Integer = 0
            Do
                If tmp(i) < orgdata(pt).data Then
                    If orgdata(pt).lchild = -1 Then orgdata(pt).lchild = i : Exit Do Else pt = orgdata(pt).lchild
                End If
                If tmp(i) > orgdata(pt).data Then
                    If orgdata(pt).rchild = -1 Then orgdata(pt).rchild = i : Exit Do Else pt = orgdata(pt).rchild
                End If
            Loop
        Next
        Dim result As New ArrayList
        post(orgdata, result, 0)
        PrintLine(3, String.Join(",", result.ToArray))

    End Sub
    Sub post(orgdata() As tr, result As ArrayList, pt As Integer)
        If orgdata(pt).lchild <> -1 Then post(orgdata, result, orgdata(pt).lchild)
        If orgdata(pt).rchild <> -1 Then post(orgdata, result, orgdata(pt).rchild)
        result.Add(orgdata(pt).data)

    End Sub
End Class
