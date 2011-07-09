Imports Extensions

Partial Class Administration_Users
    Inherits System.Web.UI.Page

#Region "Properties"

    Private Property TotalRowCount() As Integer
        Get
            Dim o As Object = ViewState("TotalRowCount")
            If o Is Nothing Then
                Return -1
            Else
                Return CInt(o)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("TotalRowCount") = value
        End Set
    End Property

    Private ReadOnly Property PageIndex() As Integer
        Get
            If Not String.IsNullOrEmpty(Request.QueryString("pageIndex")) Then
                Return Convert.ToInt32(Request.QueryString("pageIndex"))
            Else
                Return 0
            End If
        End Get
    End Property

    Private ReadOnly Property PageSize() As Integer
        Get
            If Not String.IsNullOrEmpty(Request.QueryString("pageSize")) Then
                Return Convert.ToInt32(Request.QueryString("pageSize"))
            Else
                Return 4
            End If
        End Get
    End Property

    Private ReadOnly Property PageCount() As Integer
        Get
            If TotalRowCount <= 0 OrElse PageSize <= 0 Then
                Return 1
            Else
                Return ((TotalRowCount + PageSize) - 1) / PageSize
            End If
        End Get
    End Property

#End Region

    Protected Sub datasourceProfiles_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles datasourceProfiles.Selected
        Dim data As List(Of Workplace.Profile) = DirectCast(e.ReturnValue, List(Of Workplace.Profile))
        TotalRowCount = data.Count
        literalHeadScript.Text = ""
    End Sub

    Protected Sub datalistProfiles_ItemCommand(ByVal source As Object, ByVal e As DataListCommandEventArgs) Handles datalistProfiles.ItemCommand
        literalHeadScript.Text = ""
        If (e.CommandName = "Password") Then
            Dim userID As Guid = CType(datalistProfiles.DataKeys(e.Item.ItemIndex), Guid)
            Workplace.Profile.resetPassword(userID)
            literalHeadScript.Text = "<script type=""text/javascript"">" & vbCrLf
            literalHeadScript.Text += "$(document).ready(function () {" & vbCrLf
            literalHeadScript.Text += "$('<div>" & Me.GetLocalResourceObject("dialogPasswordReset") & _
                                        "</div>').dialog({ modal: true, resizable: false, title: '" & _
                                        Me.GetLocalResourceObject("dialogPasswordResetTitle") & "' });" & vbCrLf
            literalHeadScript.Text += " });" & vbCrLf
            literalHeadScript.Text += "</script>"
        End If
    End Sub

    Protected Sub datalistProfiles_DeleteCommand(ByVal source As Object, ByVal e As DataListCommandEventArgs) Handles datalistProfiles.DeleteCommand
        literalHeadScript.Text = ""
        Dim userID As Guid = CType(datalistProfiles.DataKeys(e.Item.ItemIndex), Guid)
        Workplace.Profile.deleteProfile(userID)
        Membership.DeleteUser(Membership.GetUser(userID).UserName, True)
        datasourceProfiles.DataBind()
        datalistProfiles.DataBind()
    End Sub

    Protected Sub datalistProfiles_EditCommand(ByVal source As Object, ByVal e As DataListCommandEventArgs) Handles datalistProfiles.EditCommand
        datalistProfiles.EditItemIndex = e.Item.ItemIndex
        datalistProfiles.DataBind()
        literalHeadScript.Text = ""
    End Sub

    Protected Sub datalistProfiles_CancelCommand(ByVal source As Object, ByVal e As DataListCommandEventArgs) Handles datalistProfiles.CancelCommand
        datalistProfiles.EditItemIndex = -1
        datalistProfiles.DataBind()
        literalHeadScript.Text = ""
    End Sub

    Protected Sub datalistProfiles_UpdateCommand(ByVal source As Object, ByVal e As DataListCommandEventArgs) Handles datalistProfiles.UpdateCommand
        literalHeadScript.Text = ""
        Dim userID As Guid = CType(datalistProfiles.DataKeys(e.Item.ItemIndex), Guid)
        Dim currentProfile As Workplace.Profile = Workplace.Profile.getProfileByID(userID)
        With currentProfile
            .Birthdate = DirectCast(e.Item.FindControl("textboxEditBirthday"), TextBox).Text.Trim.toDate()
            .EndDate = DirectCast(e.Item.FindControl("textboxEditEndDate"), TextBox).Text.Trim.toDate
            .FirstName = DirectCast(e.Item.FindControl("textboxEditFirstName"), TextBox).Text.Trim
            .Holidays = DirectCast(e.Item.FindControl("textboxEditHolidays"), TextBox).Text.Trim.toDecimal
            .LastName = DirectCast(e.Item.FindControl("textboxEditLastName"), TextBox).Text.Trim
            .Mobile = DirectCast(e.Item.FindControl("textboxEditMobile"), TextBox).Text.Trim
            .Phone = DirectCast(e.Item.FindControl("textboxEditPhone"), TextBox).Text.Trim
            .Qualification = DirectCast(e.Item.FindControl("textboxEditQualification"), TextBox).Text.Trim
            .Salary = DirectCast(e.Item.FindControl("textboxEditSalary"), TextBox).Text.Trim.toDecimal
            .StartDate = DirectCast(e.Item.FindControl("textboxEditStartDate"), TextBox).Text.Trim.toDate
            .Street = DirectCast(e.Item.FindControl("textboxEditStreet"), TextBox).Text.Trim
            .TaxClass = DirectCast(e.Item.FindControl("textboxEditTaxClass"), TextBox).Text.Trim
            .Town = DirectCast(e.Item.FindControl("textboxEditTown"), TextBox).Text.Trim
            .WeeklyHours = DirectCast(e.Item.FindControl("textboxEditWeeklyHours"), TextBox).Text.Trim.toDecimal
            .Zip = DirectCast(e.Item.FindControl("textboxEditZip"), TextBox).Text.Trim
            .Role = DirectCast(e.Item.FindControl("dropdownEditRole"), DropDownList).SelectedValue
        End With
        Workplace.Profile.updateProfile(currentProfile)
        datalistProfiles.EditItemIndex = -1
        datasourceProfiles.DataBind()
        datalistProfiles.DataBind()
    End Sub

    Protected Sub buttonAddUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonAddUser.Click
        Dim errors As New List(Of String)
        If (Workplace.Project.canAddUsers(dropdownProjects.SelectedValue) = False) Then
            errors.Add(Me.GetLocalResourceObject("errorMaxUsers"))
        Else
            If (String.IsNullOrEmpty(textboxAddFirstName.Text.Trim())) Then
                errors.Add(Me.GetLocalResourceObject("requiredUserFirstName.ErrorMessage"))
            End If
            If (String.IsNullOrEmpty(textboxAddLastName.Text.Trim())) Then
                errors.Add(Me.GetLocalResourceObject("requiredUserLastName.ErrorMessage"))
            End If
            If (String.IsNullOrEmpty(textboxAddEmail.Text.Trim())) Then
                errors.Add(Me.GetLocalResourceObject("requiredUserEmail.ErrorMessage"))
            End If
        End If

        If (errors.Count > 0) Then
            For Each s As String In errors
                labelInsertError.Text += Me.GetLocalResourceObject("requiredProjectName.Text") & "<br />"
            Next s
        Else
            labelInsertError.Text = ""
            Dim password As String = Workplace.Profile.generatePassword(8)
            Dim email As String = textboxAddEmail.Text.Trim.ToLower
            Dim status As MembershipCreateStatus
            Dim newUser As MembershipUser = Membership.CreateUser(email, password, email, _
                                                                      "Password question", "Password answer", _
                                                                      True, status)
            If newUser Is Nothing Then
                labelInsertError.Text = Workplace.Profile.getAddUserErrorMessage(status)
            Else
                Roles.AddUserToRole(email, dropdownAddRole.SelectedValue)
                Dim newProfile As New Workplace.Profile
                With newProfile
                    .FirstName = textboxAddFirstName.Text.Trim
                    .Holidays = textboxAddHolidays.Text.Trim.toDecimal()
                    .LastName = textboxAddLastName.Text.Trim
                    .Mobile = textboxAddMobile.Text.Trim
                    .Phone = textboxAddPhone.Text.Trim
                    .projectID = Guid.Parse(dropdownProjects.SelectedValue)
                    .Qualification = textboxAddQualification.Text.Trim
                    .Street = textboxAddStreet.Text.Trim
                    .Zip = textboxAddZip.Text.Trim
                    .Town = textboxAddTown.Text.Trim
                    .WeeklyHours = textboxAddHours.Text.Trim.toDecimal()
                    .userID = newUser.ProviderUserKey
                End With
                Workplace.Profile.addNewProfileWithUserID(newProfile)
                Workplace.Mailer.sendNewUserEmail(email, password, newProfile.FirstName, newProfile.LastName)
                textboxAddEmail.Text = ""
                textboxAddFirstName.Text = ""
                textboxAddHolidays.Text = ""
                textboxAddLastName.Text = ""
                textboxAddMobile.Text = ""
                textboxAddPhone.Text = ""
                textboxAddQualification.Text = ""
                textboxAddStreet.Text = ""
                textboxAddZip.Text = ""
                textboxAddTown.Text = ""
                textboxAddHours.Text = ""
            End If
        End If
        If (String.IsNullOrEmpty(labelInsertError.Text)) Then
            literalHeadScript.Text = "<script type=""text/javascript"">" & vbCrLf
            literalHeadScript.Text += "$(document).ready(function () { showAddUserForm(); }" & vbCrLf
            literalHeadScript.Text += "</script>"
        Else
            literalHeadScript.Text = ""
        End If
    End Sub
End Class
