Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim ptt As Integer = 1
        Do Until EOF(1)
            Dim t = Array.ConvertAll(LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries), Function(x) Int32.Parse(x))
            Dim n As Integer = Val(t(0)), xx As Integer = Val(t(1))
            Dim tmp = New ArrayList(t) : tmp.RemoveRange(0, 2)
            Dim data(n) As Integer
            For i = 1 To UBound(data)
                data(i) = 1
            Next

            Dim test As Boolean = False
            For i = 0 To tmp.Count - 1
                Dim pt As Integer = 0

                For j = 1 To UBound(data)
                    If data(j) <> 0 Then pt += 1
                    If pt = tmp(i) Then data(j) = 0 : pt = 0
                    If data.Sum = xx Then test = True : Exit For
                Next
                If test Then Exit For
            Next
            PrintLine(3, "Selection #" & ptt.ToString)
            Dim re As New ArrayList
            For i = 1 To UBound(data)
                If data(i) = 1 Then re.Add(i)
            Next
            PrintLine(3, String.Join(" ", re.ToArray))
            PrintLine(3)
            ptt += 1
        Loop
        Close()
    End Sub
End Class
