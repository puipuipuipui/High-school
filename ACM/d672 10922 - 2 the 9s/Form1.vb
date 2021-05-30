Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t As String = LineInput(1)
        Do Until t = "0"
            Dim ad As Integer = 0
            Dim re As Integer = sum(t, ad)
            If ad = 0 Then ad += 1
            re = re Mod 9
            If re = 0 Then PrintLine(3, t & " is a multiple of 9 and has 9-degree " & ad.ToString & ".") Else PrintLine(3, t & " is not a multiple of 9.")
            t = LineInput(1)
        Loop

        Close()
    End Sub
    Function sum(ByVal t As String, ByRef ad As Integer) As Integer
        If Len(t) = 1 Then Return Val(t)
        Dim data As New ArrayList
        For i = Len(t) - 1 To 0 Step -2
            Dim a As Integer = Val(t(i))
            If i - 1 < 0 Then
                data.Add(a)
            Else
                Dim b As Integer = Val(t(i - 1))
                data.Add(a + b)
            End If
        Next
        Dim datas = Array.ConvertAll(data.ToArray, Function(x) Int32.Parse(x))
        ad += 1
        Return sum(datas.Sum, ad)

    End Function
End Class
