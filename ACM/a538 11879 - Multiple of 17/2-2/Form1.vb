Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim t As String = LineInput(1)
        Do Until t = "0"
            Dim d As String = (Val(t.Substring(Len(t) - 1)) * 5).ToString
            Dim n As String = Mid(t, 1, Len(t) - 1)

            If Len(d) > Len(n) Then Dim ad As String = n : n = d : d = ad
            If Len(d) = Len(n) Then
                For i = 0 To Len(n) - 1
                    If d(i) > n(i) Then Dim ad As String = n : n = d : d = ad : Exit For
                Next
            End If
            Do Until Len(n) = Len(d)
                d = "0" & d
            Loop
            Dim re As New ArrayList, pt As Integer = 0
            For i = Len(n) - 1 To 0 Step -1
                Dim a As Integer = Val(n(i)), b As Integer = Val(d(i))
                Dim sum As Integer = a - b + pt
                If sum < 0 Then sum += 10 : pt = -1 : re.Add(sum) Else pt = 0 : re.Add(sum)
            Next
            re.Reverse()
            Dim res As String = String.Join("", re.ToArray)
            Dim data As String = ""
            For i = 0 To Len(res) - 1
                data &= res(i).ToString
                Dim sum As Integer = Val(data) Mod 17
                data = sum.ToString
            Next
            If data <> "0" Then PrintLine(3, "0") Else PrintLine(3, "1")
            t = LineInput(1)
        Loop
        Close()
    End Sub
End Class
