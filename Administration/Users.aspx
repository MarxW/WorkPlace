<%@ Page Title="<%$ Resources:PageTitle %>" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Users.aspx.vb" Inherits="Administration_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="margin:5px;">
        <asp:ObjectDataSource ID="datasourceProjects" runat="server" SelectMethod="getAllProjects" TypeName="Workplace.Project" />
        <asp:Label ID="labelDropDownProject" runat="server" meta:resourcekey="labelDropDownProject" />
        <asp:DropDownList ID="dropdownProjects" runat="server" AutoPostBack="True" DataSourceID="datasourceProjects" DataTextField="Name" DataValueField="projectID"></asp:DropDownList>
        <div style="height:10px;"></div>
        <asp:ObjectDataSource ID="datasourceProfiles" runat="server" />
    </div>
</asp:Content>

