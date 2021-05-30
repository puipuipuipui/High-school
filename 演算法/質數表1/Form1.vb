Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim prime As New ArrayList
        Dim is_prime(100000) As Boolean
        is_prime(0) = True : is_prime(1) = True
        For i = 2 To UBound(is_prime)
            If Not (is_prime(i)) Then prime.Add(i)
            For j = 2 * i To UBound(is_prime) Step i
                is_prime(j) = True
            Next
        Next

        Close()

    End Sub
End Class
