<%@ Page Title="<%$ Resources:PageTitle %>" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Teams.aspx.vb" Inherits="Management_Teams" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
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

    </div>
</asp:Content>

