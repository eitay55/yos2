<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductPage.aspx.cs" Inherits="ProductPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="Server">
    <style>
        
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Page_Content" runat="Server">
    <asp:ScriptManager ID="sc2" runat="server"></asp:ScriptManager>
    <div class="mdl-grid">
        <div class="mdl-card mdl-shadow--2dp">
          <header class="mdl-cell mdl-cell--3-col-desktop mdl-color--teal-100">
               <asp:Image runat="server" ID="PPic" />
          </header>
            </div>
        <div class="mdl-card mdl-cell mdl-cell--8-col mdl-tabs mdl-js-tabs mdl-js-ripple-effect">
            <div class="mdl-tabs__tab-bar">
                <a href="#tab1" class="mdl-tabs__tab">Product</a>
                <a href="#tab2" class="mdl-tabs__tab">Auctions</a>
            </div>
            <div class="mdl-tabs__panel is-active" id="tab1">
                <div class="mdl-card__title">
                    <h4 runat="server" id="title" class="mdl-card__title-text"></h4>
                </div>
                <div class="mdl-card__supporting-text ">
                    <div>
                        Current offer:
         <asp:Label runat="server" ID="price"></asp:Label>
                        <br />
                    <%--    <br />
                        Description:
         <asp:Label runat="server" ID="Description"></asp:Label>
                        <br />--%>
                        <br />
                        Time left:
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <asp:Label runat="server" ID="Time"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                        <br />
                        <br />
                        Offer:
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                                <asp:TextBox runat="server" CssClass="mdl-textfield__input" pattern="-?[0-9]*(\.[0-9]+)?" ID="Offer"></asp:TextBox>
                                <label class="mdl-textfield__label" for="sample4">Offer...</label>
                                <span class="mdl-textfield__error">Input is not a number!</span>
                            </div>
                        <br />
                        <br />

                    </div>

                </div>
                <div class="mdl-card__actions">
                    <asp:Button runat="server" ID="Btn_Offer" OnClick="Btn_Offer_Click" Text="Offer" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" />
                </div>
            </div>

            <div class="mdl-tabs__panel" id="tab2">
                 <table class="mdl-data-table mdl-js-data-table" style="width:100%;">
  <thead>
    <tr>
      <th class="mdl-data-table__cell--non-numeric">Username</th>
      <th>Bid</th>
    </tr>
  </thead>
  <tbody runat="server" id="tbody">
  </tbody>
</table>
            </div>

        </div>
    </div>


    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
    </asp:Timer>
</asp:Content>

