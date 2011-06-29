Imports Microsoft.VisualBasic
Imports System.Data.Linq

Namespace Workplace

    Public Class LicenceDTO
        Public Property licenceID As Guid
        Public Property Name As String
        Public Property MaxTeams As Integer
        Public Property MaxUsers As Integer
        Public Property NettoPrice As Decimal
    End Class

    Public Class Licence
        Inherits LicenceDTO

        ''' <summary>
        ''' Load Licences with Pageing ability
        ''' </summary>
        ''' <param name="startIndex">Index to start</param>
        ''' <param name="maxRows">Number of rows</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function getAllLicences(ByVal startIndex As Integer, ByVal maxRows As Integer) As List(Of Licence)
            Dim list As List(Of Licence)
            Using data As New DataClassesDataContext
                list = (From l In data.Licences Order By l.Name
                       Select New Licence With {
                           .licenceID = l.licenceID,
                           .MaxTeams = l.MaxTeams,
                           .MaxUsers = l.MaxUsers,
                           .NettoPrice = l.NettoPrice,
                           .Name = l.Name
                       }).Skip(startIndex).Take(maxRows).Cast(Of Licence)().ToList()
            End Using
            Return list
        End Function

        ''' <summary>
        ''' Load all Licences
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function getAllLicences() As List(Of Licence)
            Dim all As List(Of Licence)
            Using data As New DataClassesDataContext
                all = (From l In data.Licences Order By l.Name
                       Select New Licence With {
                           .licenceID = l.licenceID,
                           .MaxTeams = l.MaxTeams,
                           .MaxUsers = l.MaxUsers,
                           .NettoPrice = l.NettoPrice,
                           .Name = l.Name
                       }).Cast(Of Licence)().ToList()
            End Using
            Return all
        End Function

        ''' <summary>
        ''' Load Licence by ID
        ''' </summary>
        ''' <param name="licenceID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function getLicenceByID(ByVal licenceID As Guid) As Licence
            Dim _licence As Licence
            Using data As New DataClassesDataContext
                _licence = (From l In data.Licences Where l.licenceID = licenceID
                                           Select New Licence With {
                                               .licenceID = l.licenceID,
                                               .MaxTeams = l.MaxTeams,
                                               .MaxUsers = l.MaxUsers,
                                               .Name = l.Name,
                                               .NettoPrice = l.NettoPrice
                                           }).SingleOrDefault()
            End Using
            Return _licence
        End Function

        ''' <summary>
        ''' Load Licence by ID
        ''' </summary>
        ''' <param name="licenceID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function getLicenceByID(ByVal licenceID As String) As Licence
            Return getLicenceByID(Guid.Parse(licenceID))
        End Function

        ''' <summary>
        ''' Update the Licence
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub updateLicence(ByVal l As Licence)
            Using data As New DataClassesDataContext
                Dim _licence As Licences = (From org In data.Licences Where org.licenceID = l.licenceID).SingleOrDefault
                With _licence
                    .licenceID = l.licenceID
                    .MaxTeams = l.MaxTeams
                    .MaxUsers = l.MaxUsers
                    .Name = l.Name
                    .NettoPrice = l.NettoPrice
                End With
                data.SubmitChanges()
            End Using
        End Sub

        ''' <summary>
        ''' Delete Licence by ID
        ''' </summary>
        ''' <param name="licenceID">licence ID</param>
        ''' <remarks></remarks>
        Public Shared Sub deleteLicence(ByVal licenceID As Guid)
            Using data As New DataClassesDataContext
                Dim licenceToDelete As Licences = (From l In data.Licences Where l.licenceID = licenceID).SingleOrDefault
                data.Licences.DeleteOnSubmit(licenceToDelete)
                data.SubmitChanges()
            End Using
        End Sub

        ''' <summary>
        ''' Delete Licence by ID
        ''' </summary>
        ''' <param name="licenceID">licence ID</param>
        ''' <remarks></remarks>
        Public Shared Sub deleteLicence(ByVal licenceID As String)
            Try
                deleteLicence(Guid.Parse(licenceID))
            Catch ex As Exception

            End Try
        End Sub

        ''' <summary>
        ''' Delete Licence by ID
        ''' </summary>
        ''' <param name="l">licence</param>
        ''' <remarks></remarks>
        Public Shared Sub deleteLicence(ByVal l As Licence)
            deleteLicence(l.licenceID)
        End Sub

        ''' <summary>
        ''' Get the number of Projects
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function countAllLicences() As Integer
            Dim _count As Integer = 0
            Using data As New DataClassesDataContext
                _count = (From l In data.Licences Select l.licenceID).Count()
            End Using
            Return _count
        End Function

        ''' <summary>
        ''' Add a new Licence
        ''' </summary>
        ''' <param name="l"></param>
        ''' <remarks></remarks>
        Public Shared Sub addNewLicence(ByVal l As Licence)
            Using data As New DataClassesDataContext
                Dim _licence As New Licences
                With _licence
                    .licenceID = l.licenceID
                    .MaxTeams = l.MaxTeams
                    .MaxUsers = l.MaxUsers
                    .Name = l.Name
                    .NettoPrice = l.NettoPrice
                End With
                data.Licences.InsertOnSubmit(_licence)
                'Dim _changeset As ChangeSet = data.GetChangeSet()
                data.SubmitChanges()
            End Using
        End Sub

    End Class

End Namespace
