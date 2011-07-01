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

        ''' <summary>
        ''' Load Profiles with Pageing ability
        ''' </summary>
        ''' <param name="startIndex">Index to start</param>
        ''' <param name="maxRows">Number of rows</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function getAllProfiles(ByVal startIndex As Integer, ByVal maxRows As Integer) As List(Of Profile)
            Dim list As List(Of Profile)
            Using data As New DataClassesDataContext
                list = (From p In data.Profiles Order By p.LastName, p.FirstName
                       Select New Profile With {
                           .Birthdate = p.Birthdate,
                           .EndDate = p.EndDate,
                           .FirstName = p.FirstName,
                           .Holidays = p.Holidays,
                           .Image = p.Image,
                           .LastName = p.LastName,
                           .Mobile = p.Mobile,
                           .Notes = p.Notes,
                           .Phone = p.phone,
                           .Qualification = p.Qualification,
                           .Salary = p.Salary,
                           .StartDate = p.StartDate,
                           .Street = p.Street,
                           .TaxClass = p.TaxClass,
                           .Town = p.town,
                           .userID = p.userID,
                           .WeeklyHours = p.WeeklyHours,
                           .Zip = p.Zip
                       }).Skip(startIndex).Take(maxRows).Cast(Of Profile)().ToList()
            End Using
            Return list
        End Function

        ''' <summary>
        ''' Load Profiles
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function getAllProfiles() As List(Of Profile)
            Dim list As List(Of Profile)
            Using data As New DataClassesDataContext
                list = (From p In data.Profiles Order By p.LastName, p.FirstName
                       Select New Profile With {
                           .Birthdate = p.Birthdate,
                           .EndDate = p.EndDate,
                           .FirstName = p.FirstName,
                           .Holidays = p.Holidays,
                           .Image = p.Image,
                           .LastName = p.LastName,
                           .Mobile = p.Mobile,
                           .Notes = p.Notes,
                           .Phone = p.phone,
                           .Qualification = p.Qualification,
                           .Salary = p.Salary,
                           .StartDate = p.StartDate,
                           .Street = p.Street,
                           .TaxClass = p.TaxClass,
                           .Town = p.town,
                           .userID = p.userID,
                           .WeeklyHours = p.WeeklyHours,
                           .Zip = p.Zip
                       }).Cast(Of Profile)().ToList()
            End Using
            Return list
        End Function



    End Class

End Namespace

