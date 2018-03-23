<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CompletedAuctions.aspx.cs" Inherits="ActiveAuctions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Page_Content" Runat="Server">
        <div class="mdl-grid" id="div_Products" runat="server">

        </div>
        <div class="mdl-grid">
        <div class="mdl-cell mdl-cell--5-col"></div>
    <div runat="server" id="Dprv" class="mdl-cell mdl-cell--1-col"></div>
        <div runat="server" id="Dnext" class="mdl-cell mdl-cell--1-col"></div>
    </div>
</asp:Content>

