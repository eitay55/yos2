<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MAuctions.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Page_Content" Runat="Server">
     <div class="mdl-tabs mdl-js-tabs">
  <div class="mdl-tabs__tab-bar">
    <a href="#tab1" class="mdl-tabs__tab">Search</a>
    <a href="#tab2" class="mdl-tabs__tab">Full list</a>
  </div>
  <div class="mdl-tabs__panel is-active" id="tab1">
    <div> Search Auction:<asp:TextBox runat="server" ID="Lbl_Auction"></asp:TextBox><br />
        <asp:Button runat="server" ID="Btn_Search" Text="Search" OnClick="Btn_Search_Click" /></div>
      <asp:Label runat="server" id="msg"></asp:Label>
      <asp:GridView ID="Grv2" runat="server"></asp:GridView>

  </div>
       
  <div class="mdl-tabs__panel" id="tab2">
   <asp:GridView ID="Grv" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1">
       <Columns>
           <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
           <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
           <asp:BoundField DataField="PName" HeaderText="PName" SortExpression="PName" />
           <asp:BoundField DataField="SUser" HeaderText="SUser" SortExpression="SUser" />
           <asp:BoundField DataField="Buser" HeaderText="Buser" SortExpression="Buser" />
           <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
           <asp:BoundField DataField="EY" HeaderText="EY" SortExpression="EY" />
           <asp:BoundField DataField="EM" HeaderText="EM" SortExpression="EM" />
           <asp:BoundField DataField="ED" HeaderText="ED" SortExpression="ED" />
           <asp:BoundField DataField="EH" HeaderText="EH" SortExpression="EH" />
           <asp:BoundField DataField="EMIN" HeaderText="EMIN" SortExpression="EMIN" />
           <asp:BoundField DataField="Open" HeaderText="Open" SortExpression="Open" />
           <asp:BoundField DataField="ImgUrl" HeaderText="ImgUrl" SortExpression="ImgUrl" />
           <asp:BoundField DataField="Catagory" HeaderText="Catagory" SortExpression="Catagory" />
           <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
       </Columns>
      </asp:GridView>
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString5 %>" DeleteCommand="DELETE FROM [Auctions] WHERE [ID] = ?" InsertCommand="INSERT INTO [Auctions] ([ID], [PName], [SUser], [Buser], [price], [EY], [EM], [ED], [EH], [EMIN], [Open], [ImgUrl], [Catagory], [Description]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)" ProviderName="<%$ ConnectionStrings:ConnectionString5.ProviderName %>" SelectCommand="SELECT * FROM [Auctions]" UpdateCommand="UPDATE [Auctions] SET [PName] = ?, [SUser] = ?, [Buser] = ?, [price] = ?, [EY] = ?, [EM] = ?, [ED] = ?, [EH] = ?, [EMIN] = ?, [Open] = ?, [ImgUrl] = ?, [Catagory] = ?, [Description] = ? WHERE [ID] = ?">
          <DeleteParameters>
              <asp:Parameter Name="ID" Type="Int32" />
          </DeleteParameters>
          <InsertParameters>
              <asp:Parameter Name="ID" Type="Int32" />
              <asp:Parameter Name="PName" Type="String" />
              <asp:Parameter Name="SUser" Type="String" />
              <asp:Parameter Name="Buser" Type="String" />
              <asp:Parameter Name="price" Type="String" />
              <asp:Parameter Name="EY" Type="String" />
              <asp:Parameter Name="EM" Type="String" />
              <asp:Parameter Name="ED" Type="String" />
              <asp:Parameter Name="EH" Type="String" />
              <asp:Parameter Name="EMIN" Type="String" />
              <asp:Parameter Name="Open" Type="String" />
              <asp:Parameter Name="ImgUrl" Type="String" />
              <asp:Parameter Name="Catagory" Type="String" />
              <asp:Parameter Name="Description" Type="String" />
          </InsertParameters>
          <UpdateParameters>
              <asp:Parameter Name="PName" Type="String" />
              <asp:Parameter Name="SUser" Type="String" />
              <asp:Parameter Name="Buser" Type="String" />
              <asp:Parameter Name="price" Type="String" />
              <asp:Parameter Name="EY" Type="String" />
              <asp:Parameter Name="EM" Type="String" />
              <asp:Parameter Name="ED" Type="String" />
              <asp:Parameter Name="EH" Type="String" />
              <asp:Parameter Name="EMIN" Type="String" />
              <asp:Parameter Name="Open" Type="String" />
              <asp:Parameter Name="ImgUrl" Type="String" />
              <asp:Parameter Name="Catagory" Type="String" />
              <asp:Parameter Name="Description" Type="String" />
              <asp:Parameter Name="ID" Type="Int32" />
          </UpdateParameters>
      </asp:SqlDataSource>
</div>
         </div>
</asp:Content>

