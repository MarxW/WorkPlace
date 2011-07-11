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

#Region "Properties"

        ''' <summary>
        ''' Get string value of contract start
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ContractStartString As String
            Get
                If (ContractStart = Date.MinValue Or ContractStart = Date.MaxValue) Then
                    Return ""
                End If
                Return ContractStart.ToShortDateString()
            End Get
        End Property

        ''' <summary>
        ''' Get string value of contract end
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ContractEndString As String
            Get
                If (ContractEnd = Date.MinValue Or ContractEnd = Date.MaxValue) Then
                    Return ""
                End If
                Return ContractEnd.ToShortDateString()
            End Get
        End Property

        ''' <summary>
        ''' Get string value of Patient Birthdate
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Patient_BirthdateString As String
            Get
                If (Patient_Birthdate = Date.MinValue Or Patient_Birthdate = Date.MaxValue) Then
                    Return ""
                End If
                Return Patient_Birthdate.ToShortDateString()
            End Get
        End Property

#End Region

#Region "loadTeams"

        ''' <summary>
        ''' Load Teams with Pageing ability
        ''' </summary>
        ''' <param name="startIndex">Index to start</param>
        ''' <param name="maxRows">Number of rows</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function getAllTeams(ByVal startIndex As Integer, ByVal maxRows As Integer) As List(Of Team)
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

        ''' <summary>
        ''' Load all Teams
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function getAllTeams() As List(Of Team)
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
                       }).Cast(Of Team)().ToList()
            End Using
            Return list
        End Function

        ''' <summary>
        ''' Load Teams by ProjectID with Pageing ability
        ''' </summary>
        ''' <param name="projectID">projectID</param>
        ''' <param name="startIndex">Index to start</param>
        ''' <param name="maxRows">Number of rows</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function getAllTeams(ByVal projectID As Guid, ByVal startIndex As Integer, ByVal maxRows As Integer) As List(Of Team)
            Dim list As List(Of Team)
            Using data As New DataClassesDataContext
                list = (From t In data.Teams Where t.projectID = projectID Order By t.TeamName
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

        ''' <summary>
        ''' Load all Teams for a defined projectid
        ''' </summary>
        ''' <param name="projectID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function getAllTeamsByProjectID(ByVal projectID As Guid) As List(Of Team)
            Dim list As List(Of Team)
            Using data As New DataClassesDataContext
                list = (From t In data.Teams Where t.projectID = projectID Order By t.TeamName
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
                       }).Cast(Of Team)().ToList()
            End Using
            Return list
        End Function

        ''' <summary>
        ''' Load team by ID
        ''' </summary>
        ''' <param name="teamID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function getTeamByID(ByVal teamID As Guid) As Team
            Dim _team As Team
            Using data As New DataClassesDataContext
                _team = (From t In data.Teams Where t.teamID = teamID Order By t.TeamName
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
                       }).SingleOrDefault()
            End Using
            Return _team
        End Function

#End Region

#Region "Add / Update / Delete Teams"

        ''' <summary>
        ''' Update team
        ''' </summary>
        ''' <param name="t"></param>
        ''' <remarks></remarks>
        Public Shared Sub updateTeam(ByVal t As Team)
            Using data As New DataClassesDataContext
                Dim _team As Teams = (From org In data.Teams Where org.teamID = t.teamID).SingleOrDefault()
                With _team
                    .Analysis = t.Analysis
                    .ContractEnd = t.ContractEnd
                    .ContractStart = t.ContractStart
                    .HoursPerDay = t.HoursPerDay
                    .Notes = t.Notes
                    .Patient_Birthdate = t.Patient_Birthdate
                    .Patient_Firstname = t.Patient_Firstname
                    .Patient_LastName = t.Patient_LastName
                    .Patient_Medicare = t.Patient_Medicare
                    .Phone = t.Phone
                    .Street = t.Street
                    .TeamName = t.TeamName
                    .Town = t.Town
                    .Zip = t.Zip
                End With
                data.SubmitChanges()
            End Using
        End Sub

        ''' <summary>
        ''' Delete team
        ''' </summary>
        ''' <param name="t"></param>
        ''' <remarks></remarks>
        Public Shared Sub deleteTeam(ByVal t As Team)
            deleteTeamByID(t.teamID)
        End Sub

        ''' <summary>
        ''' Delete Team
        ''' </summary>
        ''' <param name="teamID"></param>
        ''' <remarks></remarks>
        Public Shared Sub deleteTeamByID(ByVal teamID As Guid)
            Using data As New DataClassesDataContext
                Dim teamToDelete As Teams = (From t In data.Teams Where t.teamID = teamID).SingleOrDefault
                data.Teams.DeleteOnSubmit(teamToDelete)
                data.SubmitChanges()
            End Using
        End Sub

        ''' <summary>
        ''' Delete Team
        ''' </summary>
        ''' <param name="teamID"></param>
        ''' <remarks></remarks>
        Public Shared Sub deleteTeamByID(ByVal teamID As String)
            Try
                deleteTeamByID(Guid.Parse(teamID))
            Catch ex As Exception

            End Try
        End Sub

        ''' <summary>
        ''' Add new Team
        ''' </summary>
        ''' <param name="t"></param>
        ''' <remarks></remarks>
        Public Shared Sub addNewTeam(ByVal t As Team)
            Using data As New DataClassesDataContext
                Dim _team As New Teams
                With _team
                    .Analysis = t.Analysis
                    .ContractEnd = t.ContractEnd
                    .ContractStart = t.ContractStart
                    .HoursPerDay = t.HoursPerDay
                    .Notes = t.Notes
                    .Patient_Birthdate = t.Patient_Birthdate
                    .Patient_Firstname = t.Patient_Firstname
                    .Patient_LastName = t.Patient_LastName
                    .Patient_Medicare = t.Patient_Medicare
                    .Phone = t.Phone
                    .Street = t.Street
                    .TeamName = t.TeamName
                    .Town = t.Town
                    .Zip = t.Zip
                    .projectID = t.projectID
                    .teamID = Guid.NewGuid
                End With
                data.Teams.InsertOnSubmit(_team)
                data.SubmitChanges()
            End Using
        End Sub

#End Region

    End Class

End Namespace

