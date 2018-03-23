<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="manager.aspx.cs" Inherits="manager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Page_Content" Runat="Server">
    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/MUsers.aspx" runat="server">Users</asp:HyperLink>
    <asp:HyperLink ID="HyperLink2" NavigateUrl="~/MAuctions.aspx" runat="server">Active auctions</asp:HyperLink>
    <asp:HyperLink ID="HyperLink3" NavigateUrl="~/MPAuctions.aspx"  runat="server">Pending Auctions</asp:HyperLink>
</asp:Content>

