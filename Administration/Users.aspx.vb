
Partial Class Administration_Users
    Inherits System.Web.UI.Page

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

    Protected Sub datasourceProfiles_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles datasourceProfiles.Selected
        Dim data As List(Of Workplace.Profile) = DirectCast(e.ReturnValue, List(Of Workplace.Profile))
        TotalRowCount = data.Count
    End Sub

    Protected Sub datalistProfiles_ItemCommand(ByVal source As Object, ByVal sender As DataListCommandEventArgs) Handles datalistProfiles.ItemCommand
        If (sender.CommandName = "Insert") Then
            Dim errors As New List(Of String)
            If (String.IsNullOrEmpty(DirectCast(sender.Item.FindControl("textboxAddFirstName"), TextBox).Text.Trim())) Then
                errors.Add(Me.GetLocalResourceObject("requiredUserFirstName.ErrorMessage"))
            End If
            If (String.IsNullOrEmpty(DirectCast(sender.Item.FindControl("textboxAddLastName"), TextBox).Text.Trim())) Then
                errors.Add(Me.GetLocalResourceObject("requiredUserLastName.ErrorMessage"))
            End If

            If (errors.Count < 1) Then
                For Each s As String In errors
                    DirectCast(sender.Item.FindControl("labelInsertError"), Label).Text += Me.GetLocalResourceObject("requiredProjectName.Text") & "<br />"
                Next s
            Else
                DirectCast(sender.Item.FindControl("labelInsertError"), Label).Text = ""

                'Dim project As New Workplace.Project
                'With project
                '    .Name = DirectCast(sender.Item.FindControl("textboxAddName"), TextBox).Text.Trim()
                '    .Street = DirectCast(sender.Item.FindControl("textboxAddStreet"), TextBox).Text.Trim()
                '    .Zip = DirectCast(sender.Item.FindControl("textboxAddZip"), TextBox).Text.Trim()
                '    .Town = DirectCast(sender.Item.FindControl("textboxAddTown"), TextBox).Text.Trim()
                '    .isActive = DirectCast(sender.Item.FindControl("checkboxIsActive"), CheckBox).Checked
                'End With
                'Workplace.Project.addNewProject(project)
                'DirectCast(sender.Item.FindControl("textboxAddName"), TextBox).Text = ""
                'DirectCast(sender.Item.FindControl("textboxAddStreet"), TextBox).Text = ""
                'DirectCast(sender.Item.FindControl("textboxAddZip"), TextBox).Text = ""
                'DirectCast(sender.Item.FindControl("textboxAddTown"), TextBox).Text = ""
                'DirectCast(sender.Item.FindControl("checkboxIsActive"), CheckBox).Checked = False
                'datasourceProjects.DataBind()
                'datalistProfiles.DataBind()
            End If
        End If
    End Sub
End Class
