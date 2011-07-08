Imports Microsoft.VisualBasic
Imports System.Data.Linq

Namespace Workplace

    Public Class ProfileDTO
        Public Property userID As Guid
        Public Property projectID As Guid
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

        Public Const ROLE_MANAGER As String = "Manager"
        Public Const ROLE_TEAMLEADER As String = "TeamLeader"
        Public Const ROLE_WORKER As String = "Worker"

        Public Const ROLE_DEFAULT As String = ROLE_WORKER

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
                           .projectID = p.projectID,
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
        ''' Load Profiles with Pageing ability
        ''' </summary>
        ''' <param name="startIndex">Index to start</param>
        ''' <param name="maxRows">Number of rows</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function getAllProfiles(ByVal projectID As Guid, ByVal startIndex As Integer, ByVal maxRows As Integer) As List(Of Profile)
            Dim list As List(Of Profile)
            Using data As New DataClassesDataContext
                list = (From p In data.Profiles Where p.projectID = projectID Order By p.LastName, p.FirstName
                       Select New Profile With {
                           .projectID = p.projectID,
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
                           .projectID = p.projectID,
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

        ''' <summary>
        ''' Load Profiles by Project
        ''' </summary>
        ''' <param name="projectID">Project ID</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function getAllProfiles(ByVal projectID As Guid) As List(Of Profile)
            Dim list As List(Of Profile)
            Using data As New DataClassesDataContext
                list = (From p In data.Profiles Order By p.LastName, p.FirstName
                       Select New Profile With {
                           .projectID = projectID,
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

        ''' <summary>
        ''' Load Profile by ID
        ''' </summary>
        ''' <param name="userID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function getProfileByID(ByVal userID As Guid) As Profile
            Dim _profile As Profile
            Using data As New DataClassesDataContext
                _profile = (From p In data.Profiles Where p.userID = userID
                            Select New Profile With {
                                .projectID = p.projectID,
                                .Birthdate = p.Birthdate,
                                .EndDate = p.EndDate,
                                .FirstName = p.FirstName,
                                .Holidays = p.Holidays,
                                .Image = p.Image,
                                .LastName = p.LastName,
                                .Mobile = p.Mobile,
                                .Notes = p.Notes,
                                .Phone = p.Phone,
                                .Qualification = p.Qualification,
                                .Salary = p.Salary,
                                .StartDate = p.StartDate,
                                .Street = p.Street,
                                .TaxClass = p.TaxClass,
                                .Town = p.Town,
                                .userID = p.userID,
                                .WeeklyHours = p.WeeklyHours,
                                .Zip = p.Zip
                            }).SingleOrDefault()
            End Using
            Return _profile
        End Function

        ''' <summary>
        ''' Load Profile by ID
        ''' </summary>
        ''' <param name="userID">User ID</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function getProfileByID(ByVal userID As String) As Profile
            Return getProfileByID(Guid.Parse(userID))
        End Function

        ''' <summary>
        ''' Update the Profile
        ''' </summary>
        ''' <param name="p">Profile</param>
        ''' <remarks></remarks>
        Public Shared Sub updateProfile(ByVal p As Profile)
            Using data As New DataClassesDataContext
                Dim _profile As Profiles = (From org In data.Profiles Where org.userID = p.userID).SingleOrDefault()
                With _profile
                    .projectID = p.projectID
                    .Birthdate = p.Birthdate
                    .EndDate = p.EndDate
                    .FirstName = p.FirstName
                    .Holidays = p.Holidays
                    .Image = p.Image
                    .LastName = p.LastName
                    .Mobile = p.Mobile
                    .Notes = p.Notes
                    .Phone = p.Phone
                    .Qualification = p.Qualification
                    .Salary = p.Salary
                    .StartDate = p.StartDate
                    .Street = p.Street
                    .TaxClass = p.TaxClass
                    .Town = p.Town
                    .WeeklyHours = p.WeeklyHours
                    .Zip = p.Zip
                End With
                data.SubmitChanges()
            End Using
        End Sub

        ''' <summary>
        ''' Delete Profile by ID
        ''' </summary>
        ''' <param name="userID">user ID</param>
        ''' <remarks></remarks>
        Public Shared Sub deleteProfile(ByVal userID As Guid)
            Using data As New DataClassesDataContext
                Dim _profile As Profiles = (From p In data.Profiles Where p.userID = userID).SingleOrDefault()
                data.Profiles.DeleteOnSubmit(_profile)
                data.SubmitChanges()
            End Using
        End Sub

        ''' <summary>
        ''' Delete Profile by ID
        ''' </summary>
        ''' <param name="userID">userID</param>
        ''' <remarks></remarks>
        Public Shared Sub deleteProfile(ByVal userID As String)
            Try
                deleteProfile(Guid.Parse(userID))
            Catch ex As Exception

            End Try
        End Sub

        ''' <summary>
        ''' Delete Profile
        ''' </summary>
        ''' <param name="p">Profile</param>
        ''' <remarks></remarks>
        Public Shared Sub deleteProfile(ByVal p As Profile)
            deleteProfile(p.userID)
        End Sub

        ''' <summary>
        ''' Get the number of Profiles
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function countAllProfiles() As Integer
            Dim _count As Integer = 0
            Using data As New DataClassesDataContext
                _count = (From p In data.Profiles Select p.userID).Count()
            End Using
            Return _count
        End Function

        ''' <summary>
        ''' Add a new Profile that already has a Unique user ID
        ''' </summary>
        ''' <param name="p"></param>
        ''' <remarks></remarks>
        Public Shared Sub addNewProfileWithUserID(ByVal p As Profile)
            Using data As New DataClassesDataContext
                If Guid.Empty = p.userID Then
                    p.userID = Guid.NewGuid()
                End If
                Dim _profile As New Profiles
                With _profile
                    With _profile
                        .projectID = p.projectID
                        .userID = p.userID
                        .Birthdate = p.Birthdate
                        .EndDate = p.EndDate
                        .FirstName = p.FirstName
                        .Holidays = p.Holidays
                        .Image = p.Image
                        .LastName = p.LastName
                        .Mobile = p.Mobile
                        .Notes = p.Notes
                        .Phone = p.Phone
                        .Qualification = p.Qualification
                        .Salary = p.Salary
                        .StartDate = p.StartDate
                        .Street = p.Street
                        .TaxClass = p.TaxClass
                        .Town = p.Town
                        .WeeklyHours = p.WeeklyHours
                        .Zip = p.Zip
                    End With
                End With
                data.Profiles.InsertOnSubmit(_profile)
                'Dim _changeset As ChangeSet = data.GetChangeSet()
                data.SubmitChanges()
            End Using
        End Sub

        ''' <summary>
        ''' Generate a user password
        ''' </summary>
        ''' <param name="length">number of chars (optional default = 8)</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function generatePassword(Optional ByVal length As Integer = 8) As String
            Dim _allowedChars As String = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789"
            If length < 1 Then
                length = 1
            End If
            Dim randomNumber As New Random()
            Dim chars(length - 1) As Char
            Dim allowedCharCount As Integer = _allowedChars.Length
            For i As Integer = 0 To length - 1
                chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
            Next i
            Return New String(chars)
        End Function

    End Class

End Namespace

