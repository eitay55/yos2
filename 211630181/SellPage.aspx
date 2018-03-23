<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SellPage.aspx.cs" Inherits="SellPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Page_Content" Runat="Server">
    <div class="mdl-grid">
        <div class="mdl-cell mdl-cell--3-col"></div>
        <div class="mdl-cell mdl-cell--6-col mdl-card">
            <div class="mdl-card mdl-card__supporting-text">
                Product's name:<asp:TextBox ID="PName" runat="server" Width="200px"></asp:TextBox>
                Product's description:<asp:TextBox ID="Despription" runat="server" Width="30px"></asp:TextBox>
                Catagory:<asp:DropDownList runat="server" ID="ddl_c"></asp:DropDownList>
                Starter price:<asp:TextBox runat="server" ID="Price" Width="200px"></asp:TextBox>
                Duration:<br />
                Hours:(up to 24)<asp:TextBox runat="server" ID="Hour" Width="200px"></asp:TextBox>
                Minutes:(up to 60) <asp:TextBox runat="server" ID="Min" Width="200px"></asp:TextBox>
                <asp:FileUpload ID="FileUpload1" runat="server" />
<asp:Button CssClass="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" />

            </div>
            
        </div>
    </div>
</asp:Content>

