<%@ Page Title="<%$ Resources:PageTitle %>" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Users.aspx.vb" Inherits="Administration_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="margin:5px;">
        <asp:ObjectDataSource ID="datasourceProjects" runat="server" SelectMethod="getAllProjects" TypeName="Workplace.Project" />
        <asp:Label ID="labelDropDownProject" runat="server" meta:resourcekey="labelDropDownProject" />
        <asp:DropDownList ID="dropdownProjects" runat="server" AutoPostBack="True" DataSourceID="datasourceProjects" DataTextField="Name" DataValueField="projectID"></asp:DropDownList>
        <div style="height:10px;"></div>
        <asp:ObjectDataSource ID="datasourceProfiles" runat="server" DataObjectTypeName="Workplace.Profile" DeleteMethod="deleteProfile" 
            InsertMethod="addNewProfileWithUserID" SelectMethod="getAllProfiles" TypeName="Workplace.Profile" UpdateMethod="updateProfile" >
            <SelectParameters>
                <asp:ControlParameter ControlID="dropdownProjects" DbType="Guid" Name="projectID" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:DataList ID="datalistProfiles" runat="server" DataSourceID="datasourceProfiles" ItemStyle-CssClass="contentRowOne" 
            AlternatingItemStyle-CssClass="contentRowTwo" RepeatLayout="Table" DataKeyField="userID">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0">
                    <tr class="headRow">
                        <th width="190px"></th>
                        <th width="150px">
                            <asp:Label runat="server" ID="labelGridTitleLastName" meta:resourcekey="labelGridTitleLastName" />
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
        </asp:DataList>
    </div>
</asp:Content>

