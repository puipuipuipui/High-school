Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), pt As Integer = 1
        Do Until t(0) = "0"
            Dim data(Val(t(0))) As Integer
            For i = 1 To UBound(data)
                data(i) = i
            Next
            For i = 1 To Val(t(1))
                Dim tt = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
                Dim L As Integer = high(data, tt(0)), R As Integer = high(data, tt(1))
                If L <> R Then data(tt(1)) = L : data(R) = L
            Next
            Dim ad As New ArrayList
            For i = 1 To UBound(data)
                Dim boss As Integer = high(data, data(i))
                If ad.IndexOf(boss) = -1 Then ad.Add(boss)
            Next
            PrintLine(3, "Case " & pt.ToString & ": " & ad.Count.ToString)
            t = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            pt += 1
        Loop


        Close()
    End Sub
    Function high(ByVal data() As Integer, ByVal t As Integer) As Integer
        If t = data(t) Then Return t Else Return high(data, data(t))
    End Function
End Class
