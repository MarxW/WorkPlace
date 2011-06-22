<%@ Page Title="Registrieren" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="Register.aspx.vb" Inherits="Account_Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:CreateUserWizard ID="RegisterUser" runat="server" EnableViewState="false">
        <LayoutTemplate>
            <asp:PlaceHolder ID="wizardStepPlaceholder" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="navigationPlaceholder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep ID="RegisterUserWizardStep" runat="server">
                <ContentTemplate>
                    <h2>
                        <asp:Label runat="server" ID="labelTitle" meta:resourcekey="labelTitle"/>
                    </h2>
                    <p>
                        <asp:Literal runat="server" ID="literalContent" Text='<%$ Resources:literalContent.Text %>' />
                    </p>
                    <p>
                        <asp:Literal runat="server" ID="literalPasswordInformation" Text="" />
                    </p>
                    <span class="failureNotification">
                        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                    </span>
                    <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="RegisterUserValidationGroup"/>
                    <div class="accountInfo">
                        <fieldset class="register">
                            <legend>
                                <asp:Literal runat="server" ID="literalRegisterHead" meta:resourcekey="literalRegisterHead" />
                            </legend>
                            <p>
                                <asp:Label ID="labelUserName" meta:resourcekey="labelUserName" runat="server" AssociatedControlID="UserName" />
                                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="requiredUserName" meta:resourcekey="requiredUserName" runat="server" ControlToValidate="UserName" 
                                     CssClass="failureNotification" ValidationGroup="RegisterUserValidationGroup" />
                            </p>
                            <p>
                                <asp:Label ID="labelEmail" runat="server" meta:resourcekey="labelEmail" AssociatedControlID="Email" />
                                <asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="requiredEmail" meta:resourcekey="requiredEmail" runat="server" ControlToValidate="Email" 
                                     CssClass="failureNotification" ValidationGroup="RegisterUserValidationGroup" />
                            </p>
                            <p>
                                <asp:Label ID="labelPassword" meta:resourcekey="labelPassword" runat="server" AssociatedControlID="Password" />
                                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="requiredPassword" meta:resourcekey="requiredPassword" runat="server" ControlToValidate="Password" 
                                     CssClass="failureNotification" ValidationGroup="RegisterUserValidationGroup" />
                            </p>
                            <p>
                                <asp:Label ID="labelConfirmPassword" meta:resourcekey="labelConfirmPassword" runat="server" AssociatedControlID="ConfirmPassword" />
                                <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic" 
                                     meta:resourcekey="requiredConfirmPassword" ID="requiredConfirmPassword" runat="server" 
                                     ValidationGroup="RegisterUserValidationGroup" />
                                <asp:CompareValidator ID="comparePassword" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                     meta:resourcekey="comparePassword" CssClass="failureNotification" Display="Dynamic" 
                                     ValidationGroup="RegisterUserValidationGroup" />
                            </p>
                        </fieldset>
                        <p class="submitButton">
                            <asp:Button ID="buttonCreateUser" meta:resourcekey="buttonCreateUser" runat="server" CommandName="MoveNext" ValidationGroup="RegisterUserValidationGroup"/>
                        </p>
                    </div>
                </ContentTemplate>
                <CustomNavigationTemplate>
                </CustomNavigationTemplate>
            </asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>