Imports Microsoft.VisualBasic
Imports System.Data.Linq

Namespace Workplace

    Public Class TeamDTO
        Public Property teamID As Guid
        Public Property projectID As Guid
        Public Property TeamName As String
        Public Property Street As String
        Public Property Town As String
        Public Property Zip As String
        Public Property Phone As String
        Public Property Patient_Firstname As String
        Public Property Patient_LastName As String
        Public Property Patient_Birthdate As Date
        Public Property Patient_Medicare As String
        Public Property HoursPerDay As Decimal
        Public Property ContractStart As Date
        Public Property ContractEnd As Date
        Public Property Notes As String
        Public Property Analysis As String
    End Class

    Public Class Team
        Inherits TeamDTO

        ''' <summary>
        ''' Load Teams with Pageing ability
        ''' </summary>
        ''' <param name="startIndex">Index to start</param>
        ''' <param name="maxRows">Number of rows</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function getAllProjects(ByVal startIndex As Integer, ByVal maxRows As Integer) As List(Of Team)
            Dim list As List(Of Team)
            Using data As New DataClassesDataContext
                list = (From t In data.Teams Order By t.TeamName
                       Select New Team With {
                           .Analysis = t.Analysis,
                           .ContractEnd = t.ContractEnd,
                           .ContractStart = t.ContractStart,
                           .HoursPerDay = t.HoursPerDay,
                           .Notes = t.Notes,
                           .Patient_Birthdate = t.Patient_Birthdate,
                           .Patient_Firstname = t.Patient_Firstname,
                           .Patient_LastName = t.Patient_LastName,
                           .Patient_Medicare = t.Patient_Medicare,
                           .Phone = t.Phone,
                           .projectID = t.projectID,
                           .Street = t.Street,
                           .teamID = t.teamID,
                           .TeamName = t.TeamName,
                           .Town = t.Town,
                           .Zip = t.Zip
                       }).Skip(startIndex).Take(maxRows).Cast(Of Team)().ToList()
            End Using
            Return list
        End Function

    End Class

End Namespace

