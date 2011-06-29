Imports Microsoft.VisualBasic

Namespace Extensions

    Public Module StringExtensions



        <System.Runtime.CompilerServices.Extension()> _
        Public Function isValidEmail(ByVal s As String) As Boolean
            If String.IsNullOrEmpty(s) Then
                Return False
            End If
            Dim pattern As String = "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
            Return Regex.IsMatch(s, pattern)
        End Function

        <System.Runtime.CompilerServices.Extension()> _
        Public Function toInteger(ByVal s As String) As Integer
            Try
                Return Integer.Parse(s)
            Catch ex As Exception
                Return 0
            End Try
        End Function

        <System.Runtime.CompilerServices.Extension()> _
        Public Function toDecimal(ByVal s As String) As Decimal
            Try
                Return Decimal.Parse(s)
            Catch ex As Exception
                Return 0.0
            End Try
        End Function
    End Module

End Namespace

