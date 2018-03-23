 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MUsers.aspx.cs" Inherits="MUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Page_Content" Runat="Server">
    <div class="mdl-tabs mdl-js-tabs">
  <div class="mdl-tabs__tab-bar">
    <a href="#tab1" class="mdl-tabs__tab">Search</a>
    <a href="#tab2" class="mdl-tabs__tab">Full list</a>
  </div>
  <div class="mdl-tabs__panel is-active" id="tab1">
    <div> Search User:<asp:TextBox runat="server" ID="Lbl_User"></asp:TextBox><br />
        <asp:Button runat="server" ID="Btn_Search" Text="Search" OnClick="Btn_Search_Click" /></div>
      <asp:Label runat="server" id="msg"></asp:Label>
      <asp:GridView ID="Grv2" runat="server"></asp:GridView>

  </div>
       
  <div class="mdl-tabs__panel" id="tab2">
    <div>
        <asp:gridview runat="server" AutoGenerateColumns="False" DataKeyNames="Username" DataSourceID="SqlDataSource1" OnPageIndexChanging="Unnamed_PageIndexChanging" ID="Grv1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="True" SortExpression="Username" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="FName" HeaderText="FName" SortExpression="FName" />
                <asp:BoundField DataField="LName" HeaderText="LName" SortExpression="LName" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                <asp:BoundField DataField="Manager" HeaderText="Manager" SortExpression="Manager" />
            </Columns>
        </asp:gridview>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString6 %>" DeleteCommand="DELETE FROM [Users] WHERE [Username] = ?" InsertCommand="INSERT INTO [Users] ([Username], [Password], [Email], [FName], [LName], [City], [Phone], [Manager]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)" ProviderName="<%$ ConnectionStrings:ConnectionString6.ProviderName %>" SelectCommand="SELECT * FROM [Users]" UpdateCommand="UPDATE [Users] SET [Password] = ?, [Email] = ?, [FName] = ?, [LName] = ?, [City] = ?, [Phone] = ?, [Manager] = ? WHERE [Username] = ?">
            <DeleteParameters>
                <asp:Parameter Name="Username" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Username" Type="String" />
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="FName" Type="String" />
                <asp:Parameter Name="LName" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Phone" Type="String" />
                <asp:Parameter Name="Manager" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="FName" Type="String" />
                <asp:Parameter Name="LName" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Phone" Type="String" />
                <asp:Parameter Name="Manager" Type="String" />
                <asp:Parameter Name="Username" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
  </div>
</div>
</asp:Content>

