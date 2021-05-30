Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(3, "out.txt", 2)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim k As Integer = LineInput(1)
            Dim father, son As New ArrayList
            Dim test As New ArrayList
            For j = 1 To k
                Dim t = LineInput(1).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
                father.Add(t(0)) : son.Add(t(1)) : test.Add(True)
            Next
            Dim sum(father.Count - 1) As Integer
            For j = 0 To father.Count - 1
                Dim ad As Integer = j
                Dim tests = test.Clone : tests(j) = False
                Dim summ As Integer = 0
                Do
                    ad = father.IndexOf(son(ad))
                    If tests(ad) Then summ += 1 : tests(ad) = False Else Exit Do
                Loop
                sum(j) = summ
            Next
            Dim arrafather = father.ToArray
            Array.Sort(sum, arrafather)
            Dim result As New ArrayList, first As Integer = sum(UBound(sum))
            For j = UBound(sum) To 0 Step -1
                If sum(j) = first Then result.Add(j)
            Next
            If result.Count = 1 Then PrintLine(3, (result(0) + 1).ToString) Else result.Sort() : PrintLine(3, (result(0) + 1).ToString)
        Next
        Close()
    End Sub
End Class
