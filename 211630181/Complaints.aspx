<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Complaints.aspx.cs" Inherits="Complaints" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Page_Content" Runat="Server">
    <div>
    <asp:DropDownList ID="DDL" runat="server"></asp:DropDownList><br />
    Title:<asp:label runat="server" ID="Ltitle"></asp:label><br />
    Username:<asp:label runat="server" ID="LUser"></asp:label><br />
    Complaint:<br />
        <p id="CCC" runat="server">
                
              </p><br />
    Response:<asp:TextBox runat="server" ID="Res"></asp:TextBox><br />
    <asp:button runat="server" Text="confirm" ID="btn1" OnClick="Unnamed_Click" /><br />
    <asp:button runat="server" Text="Choose" ID="btn2" OnClick="btn2_Click" />
    </div>
</asp:Content>

