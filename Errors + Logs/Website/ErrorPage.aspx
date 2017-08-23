<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Website.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        <h1>404</h1>
        <p class="lead">Don't Blame the user! <small>(even if it <i>is</i> their fault)</small> <asp:Label ID="FromUrl" runat="server" /></p>
        <p><a href="https://alistapart.com/article/perfect404" class="btn btn-primary btn-lg">Learn more about writing a 404 page &raquo;</a></p>
    </div>
</asp:Content>
