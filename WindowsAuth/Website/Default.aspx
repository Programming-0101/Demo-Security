<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Website._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /*body {
            font-family: 'Oswald', sans-serif;
        }*/

        .panel-heading {
            font-weight: bold;
            font-stretch: expanded;
        }
    </style>
    <div class="page-header">
        <h1 class="text-primary">This ASP.NET Web Application</h1>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>User Security</h2>
            <div class="cards">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Project Security
                        <span class="glyphicon glyphicon-info-sign" title="This is the type of authentication chosen when this project was created"></span>
                    </div>
                    <div class="panel-body">
                        <asp:Label ID="AuthType" runat="server" />
                    </div>
                </div>
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Logged In User
                        <span class="glyphicon glyphicon-info-sign" title="The user name (if logged in)"></span>
                    </div>
                    <div class="panel-body">
                        <asp:Label ID="LoggedInUser" runat="server" />&nbsp;&nbsp;<asp:CheckBox ID="IsLoggedIn" runat="server" Enabled="false" />
                        <asp:Label ID="LoggedInLabel" runat="server" AssociatedControlID="IsLoggedIn">Is Authenticated</asp:Label>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Network Domain Name
                        <span class="glyphicon glyphicon-info-sign" title="The network domain name associated with the current user"></span>
                    </div>
                    <div class="panel-body">
                        <asp:Label ID="NetworkDomainName" runat="server" />
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Role Check
                        <span class="glyphicon glyphicon-info-sign" title="Use this form to check if the user is in a particular role name"></span>
                    </div>
                    <div class="panel-body">
                        <asp:TextBox ID="RoleName" runat="server" />
                        <br />
                        <asp:LinkButton ID="CheckRole" runat="server" CssClass="btn btn-primary">Check</asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;
            <asp:Label ID="IsInRole" runat="server" />
                    </div>
                </div>
            </div>

        </div>
        <div class="col-md-4">
            <h2>Web App</h2>
            <div class="cards">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        App Identity
                        <span class="glyphicon glyphicon-info-sign" title="This application executes using this account"></span>
                    </div>
                    <div class="panel-body">
                        <asp:Label ID="WebAppIdentity" runat="server" />
                    </div>
                </div>
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Add To Role
                        <span class="glyphicon glyphicon-info-sign" title="Add the user to a particular role name that is managed by this application"></span>
                    </div>
                    <div class="panel-body">
                        <asp:TextBox ID="GivenRoleName" runat="server" />
                        <br />
                        <asp:LinkButton ID="AddToRole" runat="server" CssClass="btn btn-primary" OnClick="AddToRole_Click">Add To Role</asp:LinkButton>
                    </div>
                </div>
            </div>

        </div>
        <div class="col-md-4">
            <h2>Server</h2>
            <div class="cards">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        IIS Version
                        <span class="glyphicon glyphicon-info-sign" title="This is the version of the web server (requested through the server variables)"></span>
                    </div>
                    <div class="panel-body">
                        <asp:Label ID="IISVersion" runat="server" />
                    </div>
                </div>
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Authentication Type
                        <span class="glyphicon glyphicon-info-sign" title="This is the authentication type on the security principle as recognized through the web server settings"></span>
                    </div>
                    <div class="panel-body">
                        <asp:Label ID="AuthenticationType" runat="server" />
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Domain Info
                        <span class="glyphicon glyphicon-info-sign" title="The URI Authority and IP address"></span>
                    </div>
                    <div class="panel-body">
                        <asp:Label ID="DomainInfo" runat="server" />
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Machine Name
                        <span class="glyphicon glyphicon-info-sign" title="This is the Environment.MachineName. The machine name is also the name of the web server"></span>
                    </div>
                    <div class="panel-body">
                        <asp:Label ID="MachineName" runat="server" />
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        OS Version
                        <span class="glyphicon glyphicon-info-sign" title="This is the operating system version (Environment.OSVersion)."></span>
                    </div>
                    <div class="panel-body">
                        <asp:Label ID="OSVersion" runat="server" />
                    </div>
                </div>
                <%--<div class="panel panel-default">
                    <div class="panel-heading">
                        Friendly OS Version
                        <span class="glyphicon glyphicon-info-sign" title=""></span>
                    </div>
                    <div class="panel-body">
                        <asp:Label ID="OSVersionFriendly" runat="server" />
                    </div>
                </div>--%>
            </div>

        </div>
    </div>
</asp:Content>
