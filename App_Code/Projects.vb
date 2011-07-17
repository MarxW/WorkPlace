Imports Microsoft.VisualBasic
Imports System.Data.Linq

Namespace Workplace

    Public Class ProjectDTO
        Public Property projectID As Guid
        Public Property Name As String
        Public Property Street As String
        Public Property Zip As String
        Public Property Town As String
        Public Property ContactID As Guid
        Public Property Phone As String
        Public Property Fax As String
        Public Property licenceID As Guid
        Public Property isActive As Boolean


    End Class

    Public Class Project
        Inherits ProjectDTO

        ''' <summary>
        ''' Load Projects with Pageing ability
        ''' </summary>
        ''' <param name="startIndex">Index to start</param>
        ''' <param name="maxRows">Number of rows</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function getAllProjects(ByVal startIndex As Integer, ByVal maxRows As Integer) As List(Of Project)
            Dim list As List(Of Project)
            Using data As New DataClassesDataContext
                list = (From p In data.Projects Order By p.Name
                       Select New Project With {
                           .ContactID = p.ContactID,
                           .Fax = p.Fax,
                           .isActive = p.isActive,
                           .licenceID = p.licenceID,
                           .Name = p.Name,
                           .Phone = p.Phone,
                           .projectID = p.projectID,
                           .Street = p.Street,
                           .Town = p.Town,
                           .Zip = p.Zip
                       }).Skip(startIndex).Take(maxRows).Cast(Of Project)().ToList()
            End Using
            Return list
        End Function

        ''' <summary>
        ''' Load all Projects
        ''' </summary>
        ''' <returns>All projects</returns>
        ''' <remarks></remarks>
        Public Shared Function getAllProjects() As List(Of Project)
            Dim list As New List(Of Project)
            Using data As New DataClassesDataContext
                list = (From p In data.Projects Order By p.Name
                       Select New Project With {
                           .ContactID = p.ContactID,
                           .Fax = p.Fax,
                           .isActive = p.isActive,
                           .licenceID = p.licenceID,
                           .Name = p.Name,
                           .Phone = p.Phone,
                           .projectID = p.projectID,
                           .Street = p.Street,
                           .Town = p.Town,
                           .Zip = p.Zip
                       }).Cast(Of Project)().ToList()
            End Using
            Return list
        End Function

        ''' <summary>
        ''' Load all Projects by activation state
        ''' </summary>
        ''' <param name="activationState">The activationstate as boolean</param>
        ''' <returns>List of Projects</returns>
        ''' <remarks>activationstate: true = active projects</remarks>
        Public Shared Function getAllProjects(ByVal activationState As Boolean) As List(Of Project)
            Dim list As List(Of Project)
            Using data As New DataClassesDataContext
                list = (From p In data.Projects Where p.isActive = activationState Order By p.Name
                       Select New Project With {
                           .ContactID = p.ContactID,
                           .Fax = p.Fax,
                           .isActive = p.isActive,
                           .licenceID = p.licenceID,
                           .Name = p.Name,
                           .Phone = p.Phone,
                           .projectID = p.projectID,
                           .Street = p.Street,
                           .Town = p.Town,
                           .Zip = p.Zip
                       }).Cast(Of Project)().ToList()
            End Using
            Return list
        End Function

        ''' <summary>
        ''' Load Project
        ''' </summary>
        ''' <param name="projectID">Project uniqueidentifier</param>
        ''' <returns>project</returns>
        ''' <remarks></remarks>
        Public Shared Function getProject(ByVal projectID As Guid) As Project
            Dim _project As Project
            Using data As New DataClassesDataContext
                _project = (From p In data.Projects Where p.projectID = projectID
                                           Select New Project With {
                                               .ContactID = p.ContactID,
                                               .Fax = p.Fax,
                                               .isActive = p.isActive,
                                               .licenceID = p.licenceID,
                                               .Name = p.Name,
                                               .Phone = p.Phone,
                                               .projectID = p.projectID,
                                               .Street = p.Street,
                                               .Town = p.Town,
                                               .Zip = p.Zip
                                           }).SingleOrDefault
            End Using
            Return _project
        End Function

        ''' <summary>
        ''' Update the Project
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub updateProject(ByVal p As Project)
            Using data As New DataClassesDataContext
                Dim _project As Projects = (From org In data.Projects Where org.projectID = p.projectID).SingleOrDefault
                With _project
                    .ContactID = p.ContactID
                    .Fax = p.Fax
                    .isActive = p.isActive
                    .licenceID = p.licenceID
                    .Name = p.Name
                    .Phone = p.Phone
                    .Street = p.Street
                    .Town = p.Town
                    .Zip = p.Zip
                End With
                data.SubmitChanges()
            End Using
        End Sub

        ''' <summary>
        ''' Delete Project by ID
        ''' </summary>
        ''' <param name="projectID">project ID</param>
        ''' <remarks></remarks>
        Public Shared Sub deleteProject(ByVal projectID As Guid)
            Using data As New DataClassesDataContext
                Dim projectToDelete As Projects = (From p In data.Projects Where p.projectID = projectID).SingleOrDefault
                data.Projects.DeleteOnSubmit(projectToDelete)
                data.SubmitChanges()
            End Using
        End Sub

        ''' <summary>
        ''' Delete Project by ID
        ''' </summary>
        ''' <param name="projectID">project ID</param>
        ''' <remarks></remarks>
        Public Shared Sub deleteProject(ByVal projectID As String)
            Try
                deleteProject(Guid.Parse(projectID))
            Catch ex As Exception
            End Try
        End Sub

        ''' <summary>
        ''' Delete Project
        ''' </summary>
        ''' <param name="p"></param>
        ''' <remarks></remarks>
        Public Shared Sub deleteProject(ByVal p As Project)
            deleteProject(p.projectID)
        End Sub

        ''' <summary>
        ''' Get the number of Projects
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function countAllProjects() As Integer
            Dim _count As Integer = 0
            Using data As New DataClassesDataContext
                _count = (From p In data.Projects Select p.projectID).Count()
            End Using
            Return _count
        End Function

        ''' <summary>
        ''' Add a new Project
        ''' </summary>
        ''' <param name="p"></param>
        ''' <remarks></remarks>
        Public Shared Sub addNewProject(ByVal p As Project)
            Using data As New DataClassesDataContext
                Dim _project As New Projects
                With _project
                    .ContactID = p.ContactID
                    .Fax = p.Fax
                    .isActive = p.isActive
                    .licenceID = p.licenceID
                    .Name = p.Name
                    .Phone = p.Phone
                    .projectID = Guid.NewGuid
                    .Street = p.Street
                    .Town = p.Town
                    .Zip = p.Zip
                End With
                data.Projects.InsertOnSubmit(_project)
                'Dim _changeset As ChangeSet = data.GetChangeSet()
                data.SubmitChanges()
            End Using
        End Sub

        ''' <summary>
        ''' Check if the project can add users
        ''' </summary>
        ''' <param name="projectID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function canAddUsers(ByVal projectID As String) As Boolean
            Return canAddUsers(Guid.Parse(projectID))
        End Function

        ''' <summary>
        ''' Check if the project can add users
        ''' </summary>
        ''' <param name="projectID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function canAddUsers(ByVal projectID As Guid) As Boolean
            Return canAddUsers(getProject(projectID))
        End Function

        ''' <summary>
        ''' Check if the project can add users
        ''' </summary>
        ''' <param name="p"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function canAddUsers(ByVal p As Project) As Boolean
            Return numberOfOpenUsers(p) > 0
        End Function

        ''' <summary>
        ''' Return how many users can be added.
        ''' </summary>
        ''' <param name="p"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function numberOfOpenUsers(ByVal p As Project) As Integer
            Dim users As List(Of Profile) = Profile.getAllProfiles(p.projectID)
            Dim currentLicence As Licence = Licence.getLicenceByID(p.licenceID)
            Return currentLicence.MaxUsers - users.Count
        End Function

        ''' <summary>
        ''' Return how many teams can be created
        ''' </summary>
        ''' <param name="p"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function numberOfOpenTeams(ByVal p As Project) As Integer
            Dim currentLicence As Licence = Licence.getLicenceByID(p.licenceID)
            Dim teams As List(Of Team) = Team.getAllTeamsByProjectID(p.projectID)
            Return currentLicence.MaxTeams - teams.Count
        End Function

        ''' <summary>
        ''' Return how many teams can be created
        ''' </summary>
        ''' <param name="projectID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function numberOfOpenTeams(ByVal projectID As Guid) As Integer
            Return numberOfOpenTeams(Project.getProject(projectID))
        End Function
    End Class

End Namespace

