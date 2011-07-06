<%@ Page Title="<%$ Resources:PageTitle %>" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Projects.aspx.vb" Inherits="Administration_Projects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="../Styles/DataStyles.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="margin:5px;">
        <asp:ObjectDataSource ID="dataSourceProjects" runat="server" 
            DataObjectTypeName="Workplace.Project" DeleteMethod="deleteProject" 
            InsertMethod="addNewProject" SelectMethod="getAllProjects" 
            TypeName="Workplace.Project" UpdateMethod="updateProject"></asp:ObjectDataSource>
        <asp:DataList ID="datalistProjects" runat="server" DataSourceID="dataSourceProjects" ItemStyle-CssClass="contentRowOne" 
            AlternatingItemStyle-CssClass="contentRowTwo" RepeatLayout="Table" DataKeyField="projectID">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0">
                    <tr class="headRow">
                        <th width="190px"></th>
                        <th width="150px">
                            <asp:Label runat="server" ID="labelGridTitleName" meta:resourcekey="labelGridTitleName" />
                        </th>
                        <th width="150px">
                            <asp:Label runat="server" ID="labelGridTitleStreet" meta:resourcekey="labelGridTitleStreet" />
                        </th>
                        <th width="150px">
                            <asp:Label runat="server" ID="labelGridTitleTown" meta:resourcekey="labelGridTitleTown" />
                        </th>
                        <th width="100px" >
                            <asp:Label runat="server" ID="labelGridTitleZip" meta:resourcekey="labelGridTitleZip" />
                        </th>
                        <th  width="60px" style="text-align:right;">
                            <asp:Label runat="server" ID="labelGridTitleActive" meta:resourcekey="labelGridTitleActive" />
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
                            <asp:Label ID="labelGridName" runat="server" Text='<%# Eval("Name") %>' />
                        </td>
                        <td width="150px">
                            <asp:Label ID="labelGridStreet" runat="server" Text='<%# Eval("Street") %>' />
                        </td>
                        <td  width="150px">
                            <asp:Label ID="labelGridTown" runat="server" Text='<%# Eval("Town") %>' />
                        </td>
                        <td  width="100px">
                            <asp:Label ID="labelGridZip" runat="server" Text='<%# Eval("Zip") %>' />
                        </td>
                        <td  width="60px" style="text-align:right;">
                            <asp:Label ID="labelGridActive" runat="server" Text='<%# Eval("isActive") %>' />
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
                        <td  width="100px"></td>
                        <td  width="60px"></td>
                    </tr>
                    <tr class="contentRow">
                        <td width="190px" style="vertical-align: top">
                            <asp:Button ID="buttonSave" runat="server" meta:resourcekey="buttonSave" CommandName="Update" CausesValidation="False" />
                            <asp:Button ID="buttonCancel" runat="server" meta:resourcekey="buttonCancel" CommandName="Cancel" CausesValidation="False" />
                        </td>
                        <td colspan="5">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="labelEditName" meta:resourcekey="labelEditName" runat="server" AssociatedControlID="textboxEditName" CssClass="itemLabel" />
                                        <asp:TextBox ID="textboxEditName" runat="server" Text='<%#Eval("Name") %>' CssClass="textEntryMiddel" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="labelEditStreet" meta:resourcekey="labelEditStreet" runat="server" AssociatedControlID="textboxEditStreet" CssClass="itemLabel" />
                                        <asp:TextBox ID="textboxEditStreet" runat="server" Text='<%#Eval("Street") %>' CssClass="textEntryMiddel" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="labelEditTown" meta:resourcekey="labelEditTown" runat="server" AssociatedControlID="textboxEditTown" CssClass="itemLabel" />
                                        <asp:TextBox ID="textboxEditTown" runat="server" Text='<%#Eval("Town") %>' CssClass="textEntryShort" />
                                    </td>
                                    <td style="width:10px;"></td>
                                    <td>
                                        <asp:Label ID="labelEditZip" meta:resourcekey="labelEditZip" runat="server" AssociatedControlID="textboxEditZip" CssClass="itemLabel" />
                                        <asp:TextBox ID="textboxEditZip" runat="server" Text='<%#Eval("Zip") %>' CssClass="textEntryTiny" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="labelEditPhone" meta:resourcekey="labelEditPhone" runat="server" AssociatedControlID="textboxEditPhone" CssClass="itemLabel" />
                                        <asp:TextBox ID="textboxEditPhone" runat="server" Text='<%#Eval("Phone") %>' CssClass="textEntryShort" />
                                    </td>
                                    <td style="width:10px;"></td>
                                    <td>
                                        <asp:Label ID="labelEditFax" meta:resourcekey="labelEditFax" runat="server" AssociatedControlID="textboxEditFax" CssClass="itemLabel" />
                                        <asp:TextBox ID="textboxEditFax" runat="server" Text='<%#Eval("Fax") %>' CssClass="textEntryShort" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="labelEditLicence" meta:resourcekey="labelEditLicence" runat="server" AssociatedControlID="dropdownEditLicence" CssClass="itemLabel" />
                                        <asp:ObjectDataSource ID="datasourceLicences" runat="server" DataObjectTypeName="Workplace.Licence" SelectMethod="getAllLicences" TypeName="Workplace.Licence" />
                                        <asp:DropDownList runat="server" ID="dropdownEditLicence" DataTextField="Name" DataSourceID="datasourceLicences" DataValueField="licenceID" SelectedValue='<%#Eval("LicenceID") %>' ></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="labelEditIsActive" meta:resourcekey="labelEditIsActive" runat="server" AssociatedControlID="checkboxEditIsActive" CssClass="itemLabel" />
                                        <asp:CheckBox runat="server" ID="checkboxEditIsActive" Checked='<%#Eval("isActive") %>' />
                                    </td>
                                </tr>
                            </table>
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
                            <asp:TextBox Width="145px" ID="textboxAddStreet" runat="server" Text="" />
                        </td>
                        <td  width="150px">
                            <asp:TextBox Width="145px" ID="textboxAddTown" runat="server" Text="" />
                        </td>
                        <td  width="100px">
                            <asp:TextBox Width="95px" ID="textboxAddZip" runat="server" Text="" />
                        </td>
                        <td  width="60px" style="text-align:center;">
                            <asp:CheckBox runat="server" id="checkboxIsActive" />
                        </td>
                    </tr>
                    <tr class="footerRow">
                        <td colspan="6" style="text-align:center;">
                            <asp:RequiredFieldValidator ID="requiredProjectName" meta:resourcekey="requiredProjectName" runat="server" ControlToValidate="textboxAddName" CssClass="error" />
                            <asp:Label runat="server" ID="labelInsertError" CssClass="error"></asp:Label>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
        </asp:DataList>
        







        
    </div>

</asp:Content>

