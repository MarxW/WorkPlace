Imports Microsoft.VisualBasic
Imports System.Data.Linq

Namespace Workplace

    Public Class ProfileDTO
        Public Property userID As Guid
        Public Property FirstName As String
        Public Property LastName As String
        Public Property Birthdate As Date
        Public Property Street As String
        Public Property Town As String
        Public Property Zip As String
        Public Property Qualification As String
        Public Property WeeklyHours As Decimal
        Public Property Holidays As Decimal
        Public Property TaxClass As String
        Public Property Salary As Decimal
        Public Property Image As String
        Public Property Phone As String
        Public Property Mobile As String
        Public Property Notes As String
        Public Property StartDate As Date
        Public Property EndDate As Date
    End Class

    Public Class Profile
        Inherits ProfileDTO


    End Class

End Namespace

