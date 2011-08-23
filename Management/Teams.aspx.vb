Imports Workplace

Partial Class Management_Teams
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            setupIntroductionText()
        End If
    End Sub

    Private Sub setupIntroductionText()
        labelIntroduction.Text = String.Format(Me.GetLocalResourceObject("labelIntroduction.PreformatedText"), _
                                             Workplace.Project.numberOfOpenTeams(Profile.projectID))
    End Sub

    Protected Sub buttonAddTeam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles buttonAddTeam.Click
        Dim teamName As String = Me.textboxAddTeamName.Text.Trim
        If (Team.teamExists(teamName, Profile.projectID)) Then
            Me.labelAddError.Text = "Teamname ist bereits vergeben"
            Me.literalHead.Text = "<script type='text/javascript'>$(document).ready(function () {showAddTeamForm();});</script>"
        ElseIf (Workplace.Project.numberOfOpenTeams(Profile.projectID) < 1) Then
            Me.labelAddError.Text = "Sie können zurzeit keine weitere Teams anlegen"
            Me.literalHead.Text = "<script type='text/javascript'>$(document).ready(function () {showAddTeamForm();});</script>"
        Else
            Me.literalHead.Text = ""
            Dim newTeam As New Team()
            newTeam.projectID = Profile.projectID
            newTeam.TeamName = Me.textboxAddTeamName.Text.Trim
            newTeam.Patient_Firstname = Me.textboxAddFirstName.Text.Trim
            newTeam.Patient_LastName = Me.textboxAddLastName.Text.Trim
            Team.addNewTeam(newTeam)
            Me.textboxAddTeamName.Text = ""
            Me.textboxAddLastName.Text = ""
            Me.textboxAddFirstName.Text = ""
            Me.datasourceTeams.DataBind()
            Me.datalistTeams.DataBind()
        End If
    End Sub

    Protected Sub datalistTeams_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles datalistTeams.EditCommand
        datalistTeams.EditItemIndex = e.Item.ItemIndex
        datalistTeams.DataBind()
    End Sub
End Class
