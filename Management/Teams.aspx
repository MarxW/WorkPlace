<%@ Page Title="<%$ Resources:PageTitle %>" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Teams.aspx.vb" Inherits="Management_Teams" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="../Styles/DataStyles.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="margin:5px;">
        <p>
            <asp:Label ID="labelIntroduction" meta:resourcekey="labelIntroduction" runat="server" />
        </p>
        <asp:ObjectDataSource ID="datasourceTeams" runat="server" SelectMethod="getAllTeams" TypeName="Workplace.Team">
            <SelectParameters>
                <asp:ProfileParameter DbType="Guid" Name="projectID" PropertyName="projectID" />
                <asp:QueryStringParameter DefaultValue="0" Name="startIndex" QueryStringField="startIndex" Type="Int32" />
                <asp:Parameter DefaultValue="15" Name="maxRows" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:DataList ID="datalistTeams" runat="server" DataSourceID="datasourceTeams" ItemStyle-CssClass="contentRowOne" AlternatingItemStyle-CssClass="contentRowTwo" RepeatLayout="Table" DataKeyField="teamID">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0">
                    <tr class="headRow">
                        <th width="190px"></th>
                        <th width="150px">
                            <asp:Label runat="server" ID="labelGridTitleTeamName" meta:resourcekey="labelGridTitleTeamName" />
                        </th>
                        <th width="150px">
                            <asp:Label runat="server" ID="labelGridTitlePatientMedicare" meta:resourcekey="labelGridTitlePatientMedicare" />
                        </th>
                        <th width="150px">
                            <asp:Label runat="server" ID="labelGridTitlePatientFirstName" meta:resourcekey="labelGridTitlePatientFirstName" />
                        </th>
                        <th width="150px">
                            <asp:Label runat="server" ID="labelGridTitlePatientLastName" meta:resourcekey="labelGridTitlePatientLastName" />
                        </th>
                        <th  width="80px" style="text-align:right;">
                            <asp:Label runat="server" ID="labelGridTitleHoursPerDay" meta:resourcekey="labelGridTitleHoursPerDay" />
                        </th>
                    </tr>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0">
                    <tr class="contentRow">
                        <td width="190px">
                            <asp:Button ID="buttonDelete" runat="server" CommandName="Delete" meta:resourcekey="buttonDelete" CausesValidation="False" />
                            <asp:Button ID="buttonEdit" runat="server" CommandName="Edit" meta:resourcekey="buttonEdit" CausesValidation="False" />
                        </td>
                        <td width="150px">
                            <asp:Label runat="server" ID="labelGridTeamName" Text='<%# Eval("TeamName") %>' />
                        </td>
                        <td width="150px">
                            <asp:Label runat="server" ID="labelGridPatientMedicare" Text='<%# Eval("Patient_Medicare") %>' />
                        </td>
                        <td width="150px">
                            <asp:Label runat="server" ID="labelGridPatientFirstName" Text='<%# Eval("Patient_Firstname") %>' />
                        </td>
                        <td width="150px">
                            <asp:Label runat="server" ID="labelGridPatientLastName" Text='<%# Eval("Patient_LastName") %>' />
                        </td>
                        <td  width="80px" style="text-align:right;">
                            <asp:Label runat="server" ID="labelGridHoursPerDay" Text='<%# Eval("HoursPerDay") %>' />
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
                            <asp:Button ID="buttonAdd" OnClientClick="showAddTeamForm();return false;"  runat="server" CommandName="Insert" meta:resourcekey="buttonAdd" />
                        </td>
                        <td width="150px"></td>
                        <td width="150px"></td>
                        <td width="150px"></td>
                        <td width="150px"></td>
                        <td  width="80px"></td>
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
                    <td colspan="3">
                        <asp:label id="labelAddTeamName" meta:resourcekey="labelAddTeamName" runat="server" />
                        <asp:TextBox Width="310px" ID="textboxAddTeamName" CssClass="addTeamForm" runat="server" Text="" />
                        <asp:RequiredFieldValidator ID="requiredTeamName" meta:resourcekey="requiredTeamName" runat="server" ControlToValidate="textboxAddFirstName" CssClass="error" ValidationGroup="addTeamValidationGroup" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="labelAddFirstName" meta:resourcekey="labelAddFirstName" runat="server" />
                        <asp:TextBox Width="140px" ID="textboxAddFirstName" CssClass="addTeamForm" runat="server" Text="" />
                        <asp:RequiredFieldValidator ID="requiredUserFirstName" meta:resourcekey="requiredUserFirstName" runat="server" ControlToValidate="textboxAddFirstName" CssClass="error" ValidationGroup="addTeamValidationGroup" />
                    </td>
                    <td style="width: 10px;"></td>
                    <td>
                        <asp:label id="labelAddLastName" meta:resourcekey="labelAddLastName" runat="server" />
                        <asp:TextBox Width="140px" ID="textboxAddLastName" CssClass="addTeamForm" runat="server" Text="" />
                        <asp:RequiredFieldValidator ID="requiredUserLastName" meta:resourcekey="requiredUserLastName" runat="server" ControlToValidate="textboxAddLastName" CssClass="error" ValidationGroup="addTeamValidationGroup" />
                    </td>
                </tr>
                
                <tr>
                    <td colspan="3" >
                        <asp:Button ID="buttonAddTeam" ValidationGroup="addUserValidationGroup" meta:resourcekey="buttonAddTeam" runat="server" />
                        <asp:Button ID="buttonAddTeamCancel" meta:resourcekey="buttonAddTeamCancel" runat="server" OnClientClick="cancelAddTeam();return false;" />
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
            $('.userdatepicker').datepicker({ dateFormat: 'dd.mm.yy', changeYear: true });
            $('#dialogWrap').realcenter();
            $('#overlay').hide();
            $('#dialogWrap').hide();
        });
        function showAddTeamForm() {
            $('#overlay').show();
            $('#dialogWrap').show();
            $('#dialogWrap').realcenter();
        }
        function cancelAddTeam() {
            $('.addTeamForm').each(function () {
                $(this).val('');
            });
            $('#overlay').hide();
            $('#dialogWrap').hide();
        }
    </script>
</asp:Content>

