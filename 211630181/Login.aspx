<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Page_Content" runat="Server">
    <div style="width: 320px; left: 39%; position: absolute;" class="mdl-card-square mdl-shadow--8dp">
        <div class="mdl-card__title">
            <h2 class="mdl-card__title-text">Sign In</h2>
            <div id="tt2" style="left: 50px" class="icon material-icons">help</div>
            <div style="left: 50px" class="mdl-tooltip mdl-tooltip--large" for="tt2">
                If you don't have an account you can register
            </div>

        </div>

        <div class="mdl-card__subtitle-text">
        </div>
        <div class="mdl-card__supporting-text">
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <asp:TextBox runat="server" class="mdl-textfield__input" type="text" ID="TB_User"></asp:TextBox>
                <label class="mdl-textfield__label" for="sample3">Username</label>
            </div>
            <br />
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">

                <asp:TextBox runat="server" class="mdl-textfield__input" type="text" ID="TB_password"></asp:TextBox>
                <label class="mdl-textfield__label" for="sample3">Password</label>

            </div>
            <br />
            <asp:Label runat="server" ID="LBL_output">&nbsp</asp:Label>
        </div>

        <div style="text-align: center" class="mdl-card__actions mdl-card--border">
            <br />
            <asp:Button runat="server" ID="Btn_Login" Text="Login" OnClick="Btn_Login_Click" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" />
            <asp:Button runat="server" ID="Btn_Clear" Text="Clear" OnClick="Btn_Clear_Click" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" />
            <br />
            &nbsp
        </div>
    </div>
</asp:Content>

