
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

End Class
