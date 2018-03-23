<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AuctionHistory.aspx.cs" Inherits="Database_AuctionHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Page_Content" Runat="Server">
    <div class="mdl-grid">
        <div class="mdl-cell mdl-cell--3-col">

        </div>
        <div class="mdl-cell mdl-cell--6-col">
            
            <div class="mdl-card mdl-shadow--2dp" style="width:100%">
                <div class="mdl-card__supporting-text">
                    <h4>Auctions history</h4>
                     <table class="mdl-data-table mdl-js-data-table" style="width:100%;">
  <thead>
    <tr>
      <th class="mdl-data-table__cell--non-numeric">Product's name</th>
      <th>Bid</th>
    </tr>
  </thead>
  <tbody runat="server" id="tbody">
  </tbody>
</table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

