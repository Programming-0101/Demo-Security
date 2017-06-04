<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Website._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Exploring LDAP in C#</h1>
        <p class="lead"><b>L</b>ightweight <b>D</b>irectory <b>A</b>ccess <b>P</b>rotocol provides a means of accessing <i>Active Directory</i> (AD) information in an organization.</p>
        <p>Learn more at <a class="btn btn-success" href="https://www.ldap.com/" target="_blank">LDAP.com</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Connecting</h2>
            <p>Enter your LDAP connection details, or use the defaults to connect to an <a href="http://www.forumsys.com/tutorials/integration-how-to/ldap/online-ldap-test-server/" target="_blank">Online LDAP Test Server</a>.</p>
            <fieldset>
                <legend>LDAP Connection</legend>

                <asp:Label ID="Label1" runat="server" AssociatedControlID="LdapHost" data-toggle="tooltip" data-placement="right" title="The host is the url of the LDAP server">Host</asp:Label>
                <asp:TextBox ID="LdapHost" runat="server" CssClass="form-control" />

                <asp:Label ID="Label2" runat="server" AssociatedControlID="Port" data-toggle="tooltip" data-placement="right" title="The default port for LDAP servers is 389">Port</asp:Label>
                <asp:TextBox ID="Port" runat="server" CssClass="form-control" TextMode="Number" />

                <asp:Label ID="Label3" runat="server" AssociatedControlID="BaseDN" data-toggle="tooltip" data-placement="right" title="The baseDN is the starting point of all LDAP searches">Base DN</asp:Label>
                <asp:TextBox ID="BaseDN" runat="server" CssClass="form-control" />

                <asp:Label ID="Label4" runat="server" AssociatedControlID="UserDN" data-toggle="tooltip" data-placement="right" title="The 'user' under whose credentials you are attaching to the LDAP server (includes the baseDN)">User DN</asp:Label>
                <asp:TextBox ID="UserDN" runat="server" CssClass="form-control" />

                <asp:Label ID="Label5" runat="server" AssociatedControlID="Password" data-toggle="tooltip" data-placement="right" title="The password for the user">Password</asp:Label>
                <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password" />
            </fieldset>
        </div>
        <div class="col-md-4">
            <h2>Search Query</h2>
            <p>
                Enter a search query to explore the LDAP server. Leave blank to get all accessible objects on the server. The search query (aka: ldap filter) plus the Base DN together represent a <b>D</b>istinguished <b>N</b>ame (DN), which is essentially a "key" to an "entry" in the directory.
            </p>
            <fieldset>
                <legend>LDAP Query</legend>
                <asp:Label ID="QueryLabel" runat="server" AssociatedControlID="Query" data-toggle="tooltip" data-placement="right">Query</asp:Label>
                <asp:TextBox ID="Query" runat="server" CssClass="form-control" list="commonQueries" />
                <datalist id="commonQueries">
                    <option>ou=mathematicians</option>
                    <option>ou=scientists</option>
                    <option>ou=chemists</option>
                </datalist>
            </fieldset>
            <asp:LinkButton ID="QueryLdap" runat="server" CssClass="btn btn-primary" OnClick="QueryLdap_Click">Query LDAP</asp:LinkButton>
            <hr />
            <p><span class="label label-info">Note:</span> The <b>Base DN</b> will be automatically appended to each search for you by this program; you do not need to enter it as part of the query. By default, this query uses the following LDAP filter to get all object types in the base object and child objects: <code>objectClass=*</code></p>
            <p><span class="label label-info">Note:</span> You can also search the <a href="http://www.forumsys.com/tutorials/integration-how-to/ldap/online-ldap-test-server/" target="_blank">Online LDAP Test Server</a> on <b><a href="https://direx.azurewebsites.net/home/connect?host=ldap.forumsys.com&port=389&baseDn=dc=example,dc=com&userDn=cn=read-only-admin,dc=example,dc=com&password=password&usg=AFQjCNH3oOFd6Nxzqzg5UcQ2EBYw0xPVww&sig2=P4l-lqO5i5oHL71EEBY2TQ" target="_blank">DirEx</a></b>.</p>
            <hr />
            <h3>LDAP Abbreviations</h3>
            <dl>
                <dt>cn</dt>
                <dd>Common Name</dd>
                <dt>dc</dt>
                <dd>Domain Component</dd>
                <dt>dn</dt>
                <dd>Distinguished Name</dd>
                <dt>o</dt>
                <dd>Organization Name</dd>
                <dt>objectClass</dt>
                <dd>The values of the objectClass attribute describe the kind of object which an entry represents. The objectClass attribute is present in every entry, with at least two values. One of the values is either "top" or "alias".</dd>
                <dt>ou</dt>
                <dd>Organizational Unit Name</dd>
                <dt>sn</dt>
                <dd>Surname</dd>
                <dt>uid</dt>
                <dd>Unique Identifier</dd>
            </dl>
        </div>
        <div class="col-md-4">
            <h2>Query Results</h2>
            <div id="SearchPanel" runat="server" class="well bg-warning" visible="false">
                <asp:Label ID="SearchException" runat="server" />
            </div>
            <dl>
                <dt>MatchedDN</dt>
                <dd><asp:Label ID="resultDn" runat="server" /></dd>
                <dt>ResultCode</dt>
                <dd><asp:Label ID="resultCode" runat="server" /></dd>
                <dt>ErrorMessage</dt>
                <dd><asp:Label ID="resultMessage" runat="server" /></dd>
            </dl>
            <asp:Repeater ID="LdapR" runat="server" ItemType="LDAPClient.LdapEntry">
                <ItemTemplate>
                    <div>
                        <span class="label label-primary">DN: </span>
                        &nbsp;&nbsp;
                        <%# Item.DistinguishedName %>
                        <details>
                            <summary>Attributes</summary>
                            <asp:Repeater ID="AttributeRepeater" runat="server"
                                 DataSource="<%# Item.Attributes %>"
                                 ItemType="LDAPClient.LdapAttribute">
                                <ItemTemplate>
                                    <div>
                                        Name: <%# Item.Name %><br />
                                        Values: 
                                        <asp:Repeater ID="AttributeValuesRepeater" runat="server" DataSource="<%# Item.Values %>" ItemType="System.String">
                                            <ItemTemplate>
                                                <small class="badge"><%# Item %></small>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </details>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <script>
        $(function () {
          $('[data-toggle="tooltip"]').tooltip()
        })
    </script>
    <style>
        details {
            display: inline-block;
        }
    </style>
</asp:Content>
