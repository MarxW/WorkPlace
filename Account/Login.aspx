<%@ Page Title="<%$ Resources:PageTitle %>" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="Login.aspx.vb" Inherits="Account_Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <asp:Label runat="server" ID="labelTitle" meta:resourcekey="labelTitle"/>
    </h2>
    <p>
        <asp:Literal runat="server" ID="literalActionDescriptionStart" meta:resourcekey="literalActionDescriptionStart"/>
        <!--
        <asp:HyperLink ID="linkRegister" runat="server" EnableViewState="false" meta:resourcekey="linkRegister" /> 
        <asp:Literal runat="server" ID="literalActionDescriptionEnd" meta:resourcekey="literalActionDescriptionEnd"/>
        -->
    </p>
    <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">
        <LayoutTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>
                        <asp:Literal runat="server" ID="literalLoginHead" meta:resourcekey="literalLoginHead" />
                    </legend>
                    <p>
                        <asp:Label ID="labelUserName" meta:resourcekey="labelUserName" runat="server" AssociatedControlID="UserName" />
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredUserName" runat="server" ControlToValidate="UserName" meta:resourcekey="requiredUserName"
                             CssClass="failureNotification" ValidationGroup="LoginUserValidationGroup" />
                    </p>
                    <p>
                        <asp:Label ID="labelPassword" meta:resourcekey="labelPassword" runat="server" AssociatedControlID="Password" />
                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredPassword" runat="server" ControlToValidate="Password" meta:resourcekey="requiredPassword"
                             CssClass="failureNotification" ValidationGroup="LoginUserValidationGroup" />
                    </p>
                    <p>
                        <asp:CheckBox ID="RememberMe" runat="server"/>
                        <asp:Label ID="labelRememberMe" meta:resourcekey="labelRememberMe" runat="server" AssociatedControlID="RememberMe" CssClass="inline" />
                    </p>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="buttonLogin" meta:resourcekey="buttonLogin" runat="server" CommandName="Login" ValidationGroup="LoginUserValidationGroup"/>
                </p>
            </div>
        </LayoutTemplate>
    </asp:Login>
</asp:Content>