
Partial Class Administration_Projects
    Inherits System.Web.UI.Page

    Protected Sub datalistProjects_ItemCommand(ByVal source As Object, ByVal sender As DataListCommandEventArgs) Handles datalistProjects.ItemCommand
        If (sender.CommandName = "Insert") Then
            If (String.IsNullOrEmpty(DirectCast(sender.Item.FindControl("textboxAddName"), TextBox).Text.Trim())) Then
                DirectCast(sender.Item.FindControl("labelInsertError"), Label).Text = Me.GetLocalResourceObject("requiredProjectName.Text")
            Else
                DirectCast(sender.Item.FindControl("labelInsertError"), Label).Text = ""
                Dim project As New Workplace.Project
                With project
                    .Name = DirectCast(sender.Item.FindControl("textboxAddName"), TextBox).Text.Trim()
                    .Street = DirectCast(sender.Item.FindControl("textboxAddStreet"), TextBox).Text.Trim()
                    .Zip = DirectCast(sender.Item.FindControl("textboxAddZip"), TextBox).Text.Trim()
                    .Town = DirectCast(sender.Item.FindControl("textboxAddTown"), TextBox).Text.Trim()
                    .isActive = DirectCast(sender.Item.FindControl("checkboxIsActive"), CheckBox).Checked
                End With
                Workplace.Project.addNewProject(project)
                DirectCast(sender.Item.FindControl("textboxAddName"), TextBox).Text = ""
                DirectCast(sender.Item.FindControl("textboxAddStreet"), TextBox).Text = ""
                DirectCast(sender.Item.FindControl("textboxAddZip"), TextBox).Text = ""
                DirectCast(sender.Item.FindControl("textboxAddTown"), TextBox).Text = ""
                DirectCast(sender.Item.FindControl("checkboxIsActive"), CheckBox).Checked = False
                dataSourceProjects.DataBind()
                datalistProjects.DataBind()
            End If
        End If
    End Sub

    Protected Sub datalistProjects_EditCommand(ByVal source As Object, ByVal e As DataListCommandEventArgs) Handles datalistProjects.EditCommand
        datalistProjects.EditItemIndex = e.Item.ItemIndex
        datalistProjects.DataBind()
    End Sub

    Protected Sub datalistCustomers_CancelCommand(ByVal source As Object, ByVal e As DataListCommandEventArgs) Handles datalistProjects.CancelCommand
        datalistProjects.EditItemIndex = -1
        datalistProjects.DataBind()
    End Sub

    Protected Sub datalistProjects_DeleteCommand(ByVal source As Object, ByVal e As DataListCommandEventArgs) Handles datalistProjects.DeleteCommand
        Dim projectID As Guid = CType(datalistProjects.DataKeys(e.Item.ItemIndex), Guid)
        Workplace.Project.deleteProject(projectID)
        dataSourceProjects.DataBind()
        datalistProjects.DataBind()
    End Sub

    Protected Sub datalistProjects_UpdateCommand(ByVal source As Object, ByVal e As DataListCommandEventArgs) Handles datalistProjects.UpdateCommand
        Dim projectID As Guid = CType(datalistProjects.DataKeys(e.Item.ItemIndex), Guid)
        Dim project As Workplace.Project = Workplace.Project.getProject(projectID)
        With project
            .Fax = DirectCast(e.Item.FindControl("textboxEditFax"), TextBox).Text.Trim
            .isActive = DirectCast(e.Item.FindControl("checkboxEditIsActive"), CheckBox).Checked
            .licenceID = Guid.Parse(DirectCast(e.Item.FindControl("dropdownEditLicence"), DropDownList).SelectedValue)
            .Phone = DirectCast(e.Item.FindControl("textboxEditPhone"), TextBox).Text.Trim

        End With
        Workplace.Project.updateProject(project)
        datalistProjects.EditItemIndex = -1
        datalistProjects.DataBind()
    End Sub

End Class
