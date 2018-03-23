<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PayPage.aspx.cs" Inherits="PayPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Page_Content" Runat="Server">
    <div class="mdl-grid">
    <div class="mdl-card mdl-cell mdl-cell--4-col">
   <div class="mdl-card__title">
                    <h4 runat="server" id="title" class="mdl-card__title-text"></h4>
                </div>
                <div class="mdl-card__supporting-text ">
                    <div>
                        Seller's name: <asp:Label runat="server" ID="SUser"></asp:Label>
                        <br />
                        Your offer: <asp:Label runat="server" ID="PriceTP" Text="kkk"></asp:Label>
                        <br />
                        Product's Description:<asp:Label runat="server" ID="PDesc"></asp:Label>
                        <br />
                        pay with:
                        <asp:RadioButtonList runat="server" ID="PaymentMethod" >
                            <asp:ListItem Text="Balance" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Credit Card" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Button runat="server" ID="Check" Text="Check" OnClick="Check_Click"/>
                      
                    </div>
                </div>
               
            </div>
    <div class="mdl-cell mdl-cell--1-col"></div>
        <asp:Panel runat="server" Visible="false" ID="Panel_Payment" CssClass=" mdl-cell mdl-cell--3-col">
    <div class=" mdl-card">
           <div class="mdl-card__title">
                    <h4 runat="server" id="H1" class="mdl-card__title-text">Payment method</h4>
                </div>
        <div class="mdl-card__supporting-text">
                        <asp:Panel runat="server" Visible="false" ID="PaymentM1">
                            Your account's balance: <asp:label runat="server" id="Balance"/>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="PaymentM2" Visible="false">
                        Credit Card:<asp:TextBox runat="server" id="CCNum"></asp:TextBox><br />
                        CVV:  <asp:TextBox runat="server" id="CVV"></asp:TextBox><br />
                        Expdate: <asp:TextBox runat="server" id="ExpDate"></asp:TextBox><br />
                        ID: <asp:TextBox runat="server" id="Person_ID"></asp:TextBox><br />
                        </asp:Panel>
                 <asp:Label runat="server" ID="Output"></asp:Label>
        </div>
 <div class="mdl-card__actions">
                    <asp:Button runat="server" ID="Submit" Text="Pay" OnClick="Submit_Click" />
                </div>
    </div>
</asp:Panel>
       
    </div>
</asp:Content>

