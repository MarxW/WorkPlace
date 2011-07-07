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
                            <asp:Label runat="server" ID="labelGridTitleQualification" meta:resourcekey="labelGridTitleQualification" />
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
                            <asp:Label ID="labelGridQualification" runat="server" Text='<%# Eval("Qualification") %>' />
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
                            <asp:Button ID="buttonAdd" runat="server" CommandName="Insert" meta:resourcekey="buttonAdd" ValidationGroup="addUserValidationGroup"/>
                        </td>
                        <td width="150px">
                            <asp:TextBox Width="140px" ID="textboxAddLastName" runat="server" Text="" /><asp:RequiredFieldValidator ID="requiredUserLastName" meta:resourcekey="requiredUserLastName" runat="server" ControlToValidate="textboxAddLastName" CssClass="error" ValidationGroup="addUserValidationGroup" />
                        </td>
                        <td width="150px">
                            <asp:TextBox Width="140px" ID="textboxAddFirstName" runat="server" Text="" /><asp:RequiredFieldValidator ID="requiredUserFirstName" meta:resourcekey="requiredUserFirstName" runat="server" ControlToValidate="textboxAddFirstName" CssClass="error" ValidationGroup="addUserValidationGroup" />
                        </td>
                        <td  width="150px">
                            <asp:TextBox Width="140px" ID="textboxAddQualification" runat="server" Text="" />
                        </td>
                        <td  width="150px">
                            <asp:TextBox Width="140px" ID="textboxAddMobile" runat="server" Text="" />
                        </td>
                        <td  width="60px" style="text-align:center;">
                            <asp:TextBox Width="50px" ID="textboxAddHours" runat="server" Text="" />
                        </td>
                    </tr>
                    <tr class="footerRow">
                        <td colspan="6" style="text-align:center;">
                            <asp:ValidationSummary ID="validationsummaryAddUser" runat="server" CssClass="error" 
                                    ValidationGroup="addUserValidationGroup" DisplayMode="List"/>
                            <asp:Label runat="server" ID="labelInsertError" CssClass="error"></asp:Label>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
        </asp:DataList>
    </div>
    <div id="overlay" class="modal"></div>
</asp:Content>

