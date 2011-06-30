<%@ Page Title="<%$ Resources:PageTitle %>" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Licences.aspx.vb" Inherits="Administration_Licences" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="../Styles/DataStyles.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="margin:5px;">
        <asp:ObjectDataSource ID="datasourceLicences" runat="server" 
            DataObjectTypeName="Workplace.Licence" DeleteMethod="deleteLicence" 
            InsertMethod="addNewLicence" SelectMethod="getAllLicences" 
            TypeName="Workplace.Licence" UpdateMethod="updateLicence" />
        <asp:DataList ID="datalistLicences" runat="server" DataSourceID="datasourceLicences" ItemStyle-CssClass="contentRowOne" AlternatingItemStyle-CssClass="contentRowTwo" RepeatLayout="Table" DataKeyField="licenceID">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0">
                    <tr class="headRow">
                        <th width="190px"></th>
                        <th width="150px">
                            <asp:Label runat="server" ID="labelGridTitleName" meta:resourcekey="labelGridTitleName" />
                        </th>
                        <th width="150px">
                            <asp:Label runat="server" ID="labelGridTitleMaxTeams" meta:resourcekey="labelGridTitleMaxTeams" />
                        </th>
                        <th width="150px">
                            <asp:Label runat="server" ID="labelGridTitleMaxUsers" meta:resourcekey="labelGridTitleMaxUsers" />
                        </th>
                        <th  width="80px" style="text-align:right;">
                            <asp:Label runat="server" ID="labelGridTitlePrice" meta:resourcekey="labelGridTitlePrice" />
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
                        <td width="150px">
                            <asp:Label runat="server" ID="labelGridName" Text='<%# Eval("Name") %>' />
                        </td>
                        <td width="150px">
                            <asp:Label runat="server" ID="labelGridMaxTeams" Text='<%# Eval("MaxTeams") %>' />
                        </td>
                        <td width="150px">
                            <asp:Label runat="server" ID="labelGridMaxUsers" Text='<%# Eval("MaxUsers") %>' />
                        </td>
                        <td  width="80px" style="text-align:right;">
                            <asp:Label runat="server" ID="labelGridPrice" Text='<%# Eval("NettoPrice") %>' />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <EditItemTemplate>
                <table cellpadding="0" cellspacing="0">
                    <tr class="contentRow">
                        <td width="190px" style="text-align:right;"></td>
                        <td width="150px"></td>
                        <td width="150px"></td>
                        <td  width="150px"></td>
                        <td  width="80px"></td>
                    </tr>
                    <tr class="contentRow">
                        <td width="190px">
                            <asp:Button ID="buttonSave" runat="server" meta:resourcekey="buttonSave" CommandName="Update" CausesValidation="False" />
                            <asp:Button ID="buttonCancel" runat="server" meta:resourcekey="buttonCancel" CommandName="Cancel" CausesValidation="False" />
                        </td>
                        <td width="150px">
                            <asp:TextBox Width="145px" ID="textboxName" runat="server" Text='<%# Eval("Name") %>' />
                        </td>
                        <td width="150px">
                            <asp:TextBox Width="145px" ID="textboxMaxTeams" runat="server" Text='<%# Eval("MaxTeams") %>' />
                        </td>
                        <td width="150px">
                            <asp:TextBox Width="145px" ID="textboxMaxUsers" runat="server" Text='<%# Eval("MaxUsers") %>' />
                        </td>
                        <td  width="80px" style="text-align:right;">
                            <asp:TextBox Width="75px" ID="textboxNettoPrice" runat="server" Text='<%# Eval("NettoPrice") %>' />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <FooterTemplate>
                <table cellpadding="0" cellspacing="0">
                    <tr class="footerRow">
                        <td colspan="6" style="text-align:center;line-height:10px;"></td>
                    </tr>
                    <tr class="footerRow">
                        <td width="190px" style="text-align:right;">
                            <asp:Button ID="buttonAdd" runat="server" CommandName="Insert" meta:resourcekey="buttonAdd"/>
                        </td>
                        <td width="150px">
                            <asp:TextBox Width="145px" ID="textboxAddName" runat="server" Text="" />
                        </td>
                        <td width="150px">
                            <asp:TextBox Width="145px" ID="textboxAddMaxTeams" runat="server" Text="" />
                        </td>
                        <td width="150px">
                            <asp:TextBox Width="145px" ID="textboxAddMaxUsers" runat="server" Text="" />
                        </td>
                        <td  width="80px" style="text-align:right;">
                            <asp:TextBox Width="75px" ID="textboxAddNettoPrice" runat="server" Text="" />
                        </td>
                    </tr>
                    <tr class="footerRow">
                        <td colspan="6" style="text-align:center;">
                            <asp:RequiredFieldValidator ID="requiredLicenceName" meta:resourcekey="requiredLicenceName" 
                                runat="server" ControlToValidate="textboxAddName" CssClass="error" />
                            <asp:Label runat="server" ID="labelInsertError" CssClass="error"></asp:Label>
                        </td>
                    </tr>
            </FooterTemplate>
        </asp:DataList>
    </div>
</asp:Content>

