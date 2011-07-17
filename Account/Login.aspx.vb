
Partial Class Account_Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        linkRegister.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
    End Sub

    Protected Sub LoginUser_LoggedIn(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginUser.LoggedIn
        Try
            Dim login As Login = DirectCast(sender, Login)
            Dim usersProfile As ProfileCommon = Profile.GetProfile(login.UserName)
            If (usersProfile.projectID = Guid.Empty Or usersProfile.projectID.ToString = "00000000-0000-0000-0000-000000000000") Then
                Dim p As Workplace.Profile = Workplace.Profile.getProfileByID(Membership.GetUser(login.UserName).ProviderUserKey)
                usersProfile.projectID = p.projectID
                usersProfile.Save()
            End If
        Catch
        End Try
    End Sub
End Class