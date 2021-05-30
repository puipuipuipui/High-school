Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FileOpen(1, "in1.txt", 1)
        FileOpen(2, "in2.txt", 1)
        FileOpen(3, "out.txt", 2)
        For i = 1 To 2
            Dim n As Integer = LineInput(i)
            For j = 1 To n
                Dim t = Array.ConvertAll(LineInput(i).Replace(" ", "").Split(","), Function(x) Int32.Parse(x))
                Dim tree(UBound(t)), left(UBound(t)), right(UBound(t)) As Integer
                For k = 0 To UBound(t)
                    tree(k) = t(k) : left(k) = -1 : right(k) = -1
                Next
                For k = 1 To UBound(t)
                    For q = 0 To UBound(tree)
                        If left(q) = -1 Then left(q) = t(k) : Exit For
                        If right(q) = -1 Then right(q) = t(k) : Exit For
                    Next
                Next
                Dim heaps As Boolean = heap(tree, left, right)
                Dim binary As Boolean = bin(tree, left, right)
                If heaps Then PrintLine(3, "H") Else If binary Then PrintLine(3, "B") Else PrintLine(3, "F")
            Next
            PrintLine(3)
        Next
        Close()
    End Sub
    Function heap(ByVal tree() As Integer, ByVal left() As Integer, ByVal right() As Integer) As Boolean
        Dim testb As Boolean = True, tests As Boolean = True
        For i = 0 To UBound(tree)
            If left(i) <> -1 Then
                If tree(i) > left(i) Then tests = False
                If tree(i) < left(i) Then testb = False
            End If
            If right(i) <> -1 Then
                If tree(i) > right(i) Then tests = False
                If tree(i) < right(i) Then testb = False
            End If
        Next
        If testb Or tests Then Return True Else Return False
    End Function
    Function bin(ByVal tree() As Integer, ByVal left() As Integer, ByVal right() As Integer) As Boolean
        Dim test As Boolean = True
        For i = 0 To UBound(tree)
            If left(i) <> -1 Then
                If tree(i) < left(i) Then test = False : Exit For
            End If
            If right(i) <> -1 Then
                If tree(i) > right(i) Then test = False : Exit For
            End If
        Next
        Return test
    End Function
End Class
