Imports Microsoft.VisualBasic
Imports System.Data.Linq

Namespace Workplace

    Public Class ProjectDTO
        Public projectID As Guid
        Public Name As String
        Public Street As String
        Public Zip As String
        Public Town As String
        Public ContactID As Guid
        Public Phone As String
        Public Fax As String
        Public licenceID As Guid
        Public isActive As Boolean
    End Class

    Public Class Project
        Inherits ProjectDTO


        ''' <summary>
        ''' Load all Projects
        ''' </summary>
        ''' <returns>All projects</returns>
        ''' <remarks></remarks>
        Public Shared Function getAllProjects() As List(Of Project)
            Dim list As List(Of Project)
            Using data As New DataClassesDataContext
                list = From p In data.Projects Order By p.Name
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
                       }
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
                list = From p In data.Projects Where p.isActive = activationState Order By p.Name
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
                       }
            End Using
            Return list
        End Function

        ''' <summary>
        ''' Load Project
        ''' </summary>
        ''' <param name="projectID">Project uniqueidentifier</param>
        ''' <returns>project</returns>
        ''' <remarks></remarks>
        Public Function getProject(ByVal projectID As Guid) As Project
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
        Public Sub update()
            Using data As New DataClassesDataContext
                Dim _project As New Projects
                With _project
                    .ContactID = Me.ContactID
                    .Fax = Me.Fax
                    .isActive = Me.isActive
                    .licenceID = Me.licenceID
                    .Name = Me.Name
                    .Phone = Me.Phone
                    .projectID = Me.projectID
                    .Street = Me.Street
                    .Town = Me.Town
                    .Zip = Me.Zip
                End With
                data.Projects.Attach(_project)
                Dim _changeset As ChangeSet = data.GetChangeSet()
                data.SubmitChanges()
            End Using
        End Sub

        Public Sub delete()

        End Sub
    End Class

End Namespace

