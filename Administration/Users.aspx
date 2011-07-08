<%@ Page Title="<%$ Resources:PageTitle %>" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Users.aspx.vb" Inherits="Administration_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="../Styles/DataStyles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery.tools.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="margin:5px;">
        <asp:ObjectDataSource ID="datasourceProjects" runat="server" SelectMethod="getAllProjects" TypeName="Workplace.Project" />
        <asp:Label ID="labelDropDownProject" runat="server" meta:resourcekey="labelDropDownProject" />
        <asp:DropDownList ID="dropdownProjects" runat="server" AutoPostBack="True" DataSourceID="datasourceProjects" DataTextField="Name" DataValueField="projectID"></asp:DropDownList>
        
        <div style="height:10px;"></div>
        
        <asp:ObjectDataSource ID="datasourceProfiles" runat="server" SelectMethod="getAllProfiles" TypeName="Workplace.Profile" >
            <SelectParameters>
                <asp:ControlParameter ControlID="dropdownProjects" DbType="Guid" Name="projectID" PropertyName="SelectedValue" />
                <asp:QueryStringParameter DefaultValue="0" Name="startIndex" QueryStringField="pageIndex" Type="Int32" />
                <asp:Parameter DefaultValue="15" Name="maxRows" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:DataList ID="datalistProfiles" runat="server" DataSourceID="datasourceProfiles" ItemStyle-CssClass="contentRowOne" AlternatingItemStyle-CssClass="contentRowTwo">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0">
                    <tr class="headRow">
                        <th width="190px"></th>
                        <th width="150px">
                            <asp:Label runat="server" ID="labelGridTitleLastName" meta:resourcekey="labelGridTitleLastName" />
                        </th>
                        <th width="150px">
                            <asp:Label runat="server" ID="labelGridTitleFirstName" meta:resourcekey="labelGridTitleFirstName" />
                        </th>
                        <th width="150px">
                            <asp:Label runat="server" ID="labelGridTitlePhone" meta:resourcekey="labelGridTitlePhone" />
                        </th>
                        <th width="150px" >
                            <asp:Label runat="server" ID="labelGridTitleMobile" meta:resourcekey="labelGridTitleMobile" />
                        </th>
                        <th  width="60px" style="text-align:right;">
                            <asp:Label runat="server" ID="labelGridTitleWeeklyHours" meta:resourcekey="labelGridTitleWeeklyHours" />
                        </th>
                    </tr>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0">
                    <tr class="contentRow">
                        <td width="190px" style="text-align:right;">
                            <asp:Button ID="buttonDelete" runat="server" CommandName="Delete" meta:resourcekey="buttonDelete" CausesValidation="False" />
                            <asp:Button ID="buttonEdit" runat="server" CommandName="Edit" meta:resourcekey="buttonEdit" CausesValidation="False" />
                        </td>
                        <td width="150px" class="nameCell" onclick="getProject('<%# Eval("projectID") %>');">
                            <asp:Label ID="labelGridLastName" runat="server" Text='<%# Eval("LastName") %>' />
                        </td>
                        <td width="150px">
                            <asp:Label ID="labelGridFirstName" runat="server" Text='<%# Eval("FirstName") %>' />
                        </td>
                        <td  width="150px">
                            <asp:Label ID="labelGridQualification" runat="server" Text='<%# Eval("Phone") %>' />
                        </td>
                        <td  width="150px">
                            <asp:Label ID="labelGridMobile" runat="server" Text='<%# Eval("Mobile") %>' />
                        </td>
                        <td  width="60px" style="text-align:right;">
                            <asp:Label ID="labelGridWeeklyHours" runat="server" Text='<%# Eval("WeeklyHours") %>' />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <FooterTemplate>
                <table cellpadding="0" cellspacing="0">
                    <tr class="footerRow">
                        <td colspan="6" style="text-align:center;line-height:10px;"></td>
                    </tr>
                    <tr class="footerRow">
                        <td width="190px" style="text-align:right;">
                            <asp:Button ID="buttonAdd" OnClientClick="showAddUserForm();return false;"  runat="server" CommandName="Insert" meta:resourcekey="buttonAdd" />
                        </td>
                        <td width="150px">
                        </td>
                        <td width="150px">
                        </td>
                        <td  width="150px">
                        </td>
                        <td  width="150px">
                        </td>
                        <td  width="60px" style="text-align:center;">
                        </td>
                    </tr>
                    <tr class="footerRow">
                        <td colspan="6" style="text-align:center;"></td>
                    </tr>
                </table>
            </FooterTemplate>
        </asp:DataList>
    </div>
    <div id="dialogWrap" style="display: block; z-index: 1004; outline: 0px none; position: absolute; height: auto; 
        width: 400px; " class="ui-dialog ui-widget ui-widget-content ui-corner-all" tabindex="-1" role="dialog" aria-labelledby="ui-dialog-title-dialog-modal">
        <div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix">
            <span class="ui-dialog-title" id="ui-dialog-title-dialog-modal">
                <asp:Literal runat="server" ID="literalDialogTitle" meta:resourcekey="literalDialogTitle"/>
            </span>
            <a id="closeAddUserDialog" href="#" class="ui-dialog-titlebar-close ui-corner-all" role="button">
                <span class="ui-icon ui-icon-closethick">close</span>
            </a>
        </div>
        <div id="dialogModal" class="ui-dialog-content ui-widget-content" style="width: auto; min-height: 0px; height: 380px;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:label id="labelAddFirstName" meta:resourcekey="labelAddFirstName" runat="server" />
                        <asp:TextBox Width="140px" ID="textboxAddFirstName" CssClass="addUserForm" runat="server" Text="" />
                        <asp:RequiredFieldValidator ID="requiredUserFirstName" meta:resourcekey="requiredUserFirstName" runat="server" ControlToValidate="textboxAddFirstName" CssClass="error" ValidationGroup="addUserValidationGroup" />
                    </td>
                    <td style="width: 10px;"></td>
                    <td>
                        <asp:label id="labelAddLastName" meta:resourcekey="labelAddLastName" runat="server" />
                        <asp:TextBox Width="140px" ID="textboxAddLastName" CssClass="addUserForm" runat="server" Text="" />
                        <asp:RequiredFieldValidator ID="requiredUserLastName" meta:resourcekey="requiredUserLastName" runat="server" ControlToValidate="textboxAddLastName" CssClass="error" ValidationGroup="addUserValidationGroup" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:label id="labelAddEmail" meta:resourcekey="labelAddEmail" runat="server" />
                        <asp:TextBox Width="310px" ID="textboxAddEmail" CssClass="addUserForm" runat="server" Text="" />
                        <asp:RequiredFieldValidator ID="requiredUserEmail" meta:resourcekey="requiredUserEmail" runat="server" ControlToValidate="textboxAddEmail" CssClass="error" ValidationGroup="addUserValidationGroup" />
                        <asp:RegularExpressionValidator ID="regexValidatorEmail" meta:resourcekey="regexValidatorEmail" ControlToValidate="textboxAddEmail" CssClass="error" runat="server" ValidationGroup="addUserValidationGroup" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:label id="labelAddQualification" meta:resourcekey="labelAddQualification" runat="server" />
                        <asp:TextBox Width="310px" ID="textboxAddQualification" CssClass="addUserForm" TextMode="MultiLine" Height="40px" runat="server" Text="" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:label id="labelAddStreet" meta:resourcekey="labelAddStreet" runat="server" />
                        <asp:TextBox Width="310px" ID="textboxAddStreet" CssClass="addUserForm" runat="server" Text="" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="labelAddTown" meta:resourcekey="labelAddTown" runat="server" />
                        <asp:TextBox Width="140px" ID="textboxAddTown" CssClass="addUserForm" runat="server" Text="" />
                    </td>
                    <td style="width: 10px;"></td>
                    <td>
                        <asp:label id="labelAddZip" meta:resourcekey="labelAddZip" runat="server" />
                        <asp:TextBox Width="80px" ID="textboxAddZip" CssClass="addUserForm" runat="server" Text="" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="labelAddMobile" meta:resourcekey="labelAddMobile" runat="server" />
                        <asp:TextBox Width="140px" ID="textboxAddMobile" CssClass="addUserForm" runat="server" Text="" />
                    </td>
                    <td style="width: 10px;"></td>
                    <td>
                        <asp:label id="labelAddPhone" meta:resourcekey="labelAddPhone" runat="server" />
                        <asp:TextBox Width="140px" ID="textboxAddPhone" CssClass="addUserForm" runat="server" Text="" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="labelAddHours" meta:resourcekey="labelAddHours" runat="server" />
                        <asp:TextBox Width="140px" ID="textboxAddHours" CssClass="addUserForm" runat="server" Text="" />
                    </td>
                    <td style="width: 10px;"></td>
                    <td>
                        <asp:label id="labelAddHolidays" meta:resourcekey="labelAddHolidays" runat="server" />
                        <asp:TextBox Width="140px" ID="textboxAddHolidays" CssClass="addUserForm" runat="server" Text="" />
                    </td>
                </tr>
                <tr style="height:10px;">
                    <td colspan="3">
                        <asp:ValidationSummary ID="validationsummaryAddUser" runat="server" CssClass="error" 
                                    ValidationGroup="addUserValidationGroup" DisplayMode="List"/>
                        <asp:Label runat="server" ID="labelInsertError" CssClass="error"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" >
                        <asp:Button ID="buttonAddUser" ValidationGroup="addUserValidationGroup" meta:resourcekey="buttonAddUser" runat="server" />
                        <asp:Button ID="buttonAddUserCancel" meta:resourcekey="buttonAddUserCancel" runat="server" OnClientClick="cancelAddUser();return false;" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="overlay" class="ui-widget-overlay" style="z-index: 1003;"></div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#closeAddUserDialog').bind('click', function () {
                $('#overlay').hide();
                $('#dialogWrap').hide();
            });
            $('#dialogWrap').realcenter();
        });
        function showAddUserForm() {
            $('#overlay').show();
            $('#dialogWrap').show();
            $('#dialogWrap').realcenter();
        }
        function cancelAddUser() {
            $('.addUserForm').each(function () {
                $(this).val('');
            });
            $('#overlay').hide();
            $('#dialogWrap').hide();
        }
    </script>
</asp:Content>

