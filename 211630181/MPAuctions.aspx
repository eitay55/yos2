<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MPAuctions.aspx.cs" Inherits="MPAuctions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Page_Content" Runat="Server">
    search Auction:<asp:TextBox runat="server" ID="SearchT"></asp:TextBox>
    <div>
        Title<asp:TextBox runat="server" ID="title"></asp:TextBox><br />
        Seller's username:<asp:TextBox runat="server" ID="User"></asp:TextBox><br />
        Minimum price:<asp:TextBox runat="server" ID="Price"></asp:TextBox><br />
        Time:<br />
        hours:<asp:TextBox ID="Hours" runat="server"></asp:TextBox><br />
        Minutes:<asp:TextBox ID="mins" runat="server"></asp:TextBox><br />
        image:<asp:Image ID="Pimg" runat="server" /><br />
        catagory:<asp:TextBox runat="server" ID="category"></asp:TextBox><br />
        Product's description:<asp:TextBox runat="server" ID="desc"></asp:TextBox><br />
        <asp:Button  ID="Activate" Text="Activate" OnClick="Activate_Click" runat="server"/> <asp:Button OnClick="Search_Click" id="Search" Text="Search" runat="server"/>

    </div>
</asp:Content>

