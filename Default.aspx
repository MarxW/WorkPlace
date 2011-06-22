<%@ Page Title="Startseite" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <asp:Label runat="server" ID="labelHead" meta:resourcekey="labelHead" />
    </h2>
    <p>
        <asp:Literal runat="server" ID="literalContent" meta:resourcekey="literalContent" />
    </p>
</asp:Content>