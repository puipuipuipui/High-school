Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n% = LineInput(i)
            For j = 1 To n
                solve(LineInput(i).Replace(" ", "").Split(","))
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Sub solve(ByVal t() As String)
        Dim data(UBound(t)), lchild(UBound(t)), rchild(UBound(t)) As Integer
        For i = 0 To UBound(t)
            data(i) = t(i)
            lchild(i) = -1 : rchild(i) = -1
        Next
        For i = 1 To UBound(t)
            For j = 0 To UBound(t)
                If lchild(j) = -1 Then lchild(j) = t(i) : Exit For Else If rchild(j) = -1 Then rchild(j) = t(i) : Exit For
            Next
        Next
        Dim testmin As Boolean = True, testmax As Boolean = True, testbin As Boolean = True
        For i = 0 To UBound(data)
            If lchild(i) <> -1 Then
                If data(i) > lchild(i) Then testmin = False Else If data(i) < lchild(i) Then testmax = False
                If data(i) < lchild(i) Then testbin = False
            End If
            If rchild(i) <> -1 Then
                If data(i) > rchild(i) Then testmin = False Else If data(i) < rchild(i) Then testmax = False
                If data(i) > rchild(i) Then testbin = False
            End If
        Next
        If testmax Or testmin Then PrintLine(3, "H") : Exit Sub
        If testbin Then PrintLine(3, "B") : Exit Sub
        PrintLine(3, "F")
    End Sub
  
End Class
