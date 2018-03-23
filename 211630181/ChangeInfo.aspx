<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangeInfo.aspx.cs" Inherits="ChangeInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Page_Content" Runat="Server">
     <div style="width: 320px; left: 39%; position: absolute;" class="mdl-card-square mdl-shadow--8dp">
        <div class="mdl-card__title">
            <h2 class="mdl-card__title-text">Change Info</h2>
          
        </div>
        <div class="mdl-card__supporting-text">
            <asp:Label runat="server" ID="LBL_output"></asp:Label>
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <asp:TextBox runat="server" class="mdl-textfield__input" type="text" ID="TB_password"></asp:TextBox>
                <label class="mdl-textfield__label" for="sample3">Password</label>
            </div>
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <asp:TextBox runat="server" class="mdl-textfield__input" type="text" ID="TB_Conforirmpassword"></asp:TextBox>
                <label class="mdl-textfield__label" for="sample3">Confirm password</label>
            </div>
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <asp:TextBox runat="server" class="mdl-textfield__input" type="text" ID="TB_Email"></asp:TextBox>
                <label class="mdl-textfield__label" for="sample3">Email</label>
            </div>
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">

                <asp:TextBox runat="server" class="mdl-textfield__input" type="text" ID="TB_FN"></asp:TextBox>
                <label class="mdl-textfield__label" for="sample3">First Name</label>
            </div>
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">

                <asp:TextBox runat="server" class="mdl-textfield__input" type="text" ID="TB_LN"></asp:TextBox>
                <label class="mdl-textfield__label" for="sample3">Last Name</label>
            </div>
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <asp:DropDownList runat="server" ID="TB_City"></asp:DropDownList>
            </div>
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">

                <asp:TextBox runat="server" class="mdl-textfield__input" type="text" ID="TB_PN"></asp:TextBox>
                <label class="mdl-textfield__label" for="sample3">Phone number</label>
            </div>
            


            <br />
            


            <div style="text-align: center" class="mdl-card__actions mdl-card--border">
                <asp:Button runat="server" ID="Btn_SignUp" Text="Update" OnClick="Btn_SignUp_Click" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" />
            </div>
        </div>
        
    </div>
</asp:Content>

