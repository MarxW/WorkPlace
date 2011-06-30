Imports Extensions

Partial Class Administration_Licences
    Inherits System.Web.UI.Page

    Protected Sub datalistLicences_ItemCommand(ByVal source As Object, ByVal sender As DataListCommandEventArgs) Handles datalistLicences.ItemCommand
        If (sender.CommandName = "Insert") Then
            If (String.IsNullOrEmpty(DirectCast(sender.Item.FindControl("textboxAddName"), TextBox).Text.Trim())) Then
                DirectCast(sender.Item.FindControl("labelInsertError"), Label).Text = Me.GetLocalResourceObject("requiredLicenceName.Text")
            Else
                DirectCast(sender.Item.FindControl("labelInsertError"), Label).Text = ""
                Dim _licence As New Workplace.Licence
                With _licence
                    .Name = DirectCast(sender.Item.FindControl("textboxAddName"), TextBox).Text.Trim()
                    .MaxTeams = DirectCast(sender.Item.FindControl("textboxAddMaxTeams"), TextBox).Text.Trim().toInteger()
                    .MaxUsers = DirectCast(sender.Item.FindControl("textboxAddMaxUsers"), TextBox).Text.Trim().toInteger()
                    .NettoPrice = DirectCast(sender.Item.FindControl("textboxAddNettoPrice"), TextBox).Text.Trim().toDecimal()
                End With
                Workplace.Licence.addNewLicence(_licence)
                DirectCast(sender.Item.FindControl("textboxAddName"), TextBox).Text = ""
                DirectCast(sender.Item.FindControl("textboxAddMaxTeams"), TextBox).Text = ""
                DirectCast(sender.Item.FindControl("textboxAddMaxUsers"), TextBox).Text = ""
                DirectCast(sender.Item.FindControl("textboxAddNettoPrice"), TextBox).Text = ""
                datasourceLicences.DataBind()
                datalistLicences.DataBind()
            End If
        End If
    End Sub

    Protected Sub datalistLicences_DeleteCommand(ByVal source As Object, ByVal e As DataListCommandEventArgs) Handles datalistLicences.DeleteCommand
        Dim licenceID As Guid = CType(datalistLicences.DataKeys(e.Item.ItemIndex), Guid)
        Workplace.Licence.deleteLicence(licenceID)
        datasourceLicences.DataBind()
        datalistLicences.DataBind()
    End Sub

    Protected Sub datalistLicences_EditCommand(ByVal source As Object, ByVal e As DataListCommandEventArgs) Handles datalistLicences.EditCommand
        datalistLicences.EditItemIndex = e.Item.ItemIndex
        datalistLicences.DataBind()
    End Sub

    Protected Sub datalistLicences_CancelCommand(ByVal source As Object, ByVal e As DataListCommandEventArgs) Handles datalistLicences.CancelCommand
        datalistLicences.EditItemIndex = -1
        datalistLicences.DataBind()
    End Sub

    Protected Sub datalistLicences_UpdateCommand(ByVal source As Object, ByVal e As DataListCommandEventArgs) Handles datalistLicences.UpdateCommand
        Dim licenceID As Guid = CType(datalistLicences.DataKeys(e.Item.ItemIndex), Guid)

        Dim _licence As Workplace.Licence = Workplace.Licence.getLicenceByID(licenceID)
        With _licence
            .Name = DirectCast(e.Item.FindControl("textboxName"), TextBox).Text.Trim()
            .MaxTeams = DirectCast(e.Item.FindControl("textboxMaxTeams"), TextBox).Text.Trim().toInteger()
            .MaxUsers = DirectCast(e.Item.FindControl("textboxMaxUsers"), TextBox).Text.Trim().toInteger()
            .NettoPrice = DirectCast(e.Item.FindControl("textboxNettoPrice"), TextBox).Text.Trim().toDecimal()
        End With
        Workplace.Licence.updateLicence(_licence)
        datalistLicences.EditItemIndex = -1
        datalistLicences.DataBind()
    End Sub
    

End Class
