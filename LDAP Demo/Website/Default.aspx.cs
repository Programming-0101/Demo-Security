using LDAPClient;
using System;
using System.Collections.Generic;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class _Default : Page
    {
        public const string DEFAULT_SERVER = "ldap.forumsys.com";
        public const int DEFAULT_PORT = 389;
        public const string DEFAULT_BASE_DN = "dc=example,dc=com";
        public const string DEFAULT_USER_DN = "cn=read-only-admin,dc=example,dc=com";
        public const string DEFAULT_PASSWORD = "password";

        private void SetDefaults()
        {
            LdapHost.Text = DEFAULT_SERVER;
            Port.Text = DEFAULT_PORT.ToString();
            BaseDN.Text = DEFAULT_BASE_DN;
            UserDN.Text = DEFAULT_USER_DN;
            Password.Text = DEFAULT_PASSWORD;
            QueryLabel.ToolTip = $"Will be appended with \",{BaseDN.Text}\"";
        }

        private bool CanConnect()
        {
            string server = "ldap.forumsys.com:";
            string userName = "uid = tesla,dc = example,dc = com";
            string password = "password";
             
            try
            {
                using (LdapConnection connection = new LdapConnection(server))
                {
                    connection.Timeout = new TimeSpan(0, 0, 10);
                    connection.AuthType = AuthType.Basic;
                    connection.SessionOptions.ProtocolVersion = 3; // Set protocol to LDAPv3

                    var credential = new NetworkCredential(userName, password);
                    connection.Bind(credential);
                }
                // If the bind succeeds, the credentials are valid
                return true;
            }
            catch (LdapException ldapEx)
            {
                // The supplied credential is invalid.
                if (ldapEx.ErrorCode.Equals(49))
                {
                    return false;
                }

                throw;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetDefaults();
                QueryLdap_Click(sender, e);
            }
            ////CanConnect();
            //string username = "cn = read-only-admin,dc = example,dc = com"
            //     , password = "password"
            //     , ldapServerUrl = "ldap.forumsys.com:389";
            //var client = new Client(username, password, ldapServerUrl);
            ////var searchResult = client.Search("ou=users,dc=example,dc=com", "objectClass=*");
            //var searchResult = client.Search(BaseDN.Text, "objectClass=*");
            ////var searchResult = client.Search("ou=users,dc=example,dc=com", "objectClass=*");
            //var output = new List<string>();
            //foreach (Dictionary<string, string> d in searchResult)
            //{
            //    output.Add(String.Join("\r\n", d.Select(x => x.Key + ": " + x.Value).ToArray()));
            //}
            //LdapResults.DataSource = output;
            //LdapResults.DataBind();
            /*
                Server: ldap.forumsys.com  
                Port: 389

                Bind DN: cn=read-only-admin,dc=example,dc=com
                Bind Password: password

                All user passwords are password.

                You may also bind to individual Users (uid) or the two Groups (ou) that include:

                ou=mathematicians,dc=example,dc=com

                riemann
                gauss
                euler
                euclid
                ou=scientists,dc=example,dc=com

                einstein
                newton
                galieleo
                tesla
             */
        }

        protected void QueryLdap_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new Client(UserDN.Text, Password.Text, LdapHost.Text);
                //var searchResult = client.Search("ou=users,dc=example,dc=com", "objectClass=*");
                string search;
                if (string.IsNullOrEmpty(Query.Text))
                    search = BaseDN.Text;
                else
                    search = Query.Text + "," + BaseDN.Text;

                var searchResult = client.Search(search);

                resultDn.Text = searchResult.MatchedDN;
                resultCode.Text = searchResult.ResultCode.ToString();
                resultMessage.Text = searchResult.ErrorMessage;

                LdapResults.DataSource = searchResult.Entries;
                LdapResults.DataBind();
                SearchPanel.Visible = false;
            }
            catch (LdapException ex)
            {
                SearchException.Text = ex.Message;
                SearchPanel.Visible = true;
            }
            catch (Exception ex)
            {
                SearchException.Text = ex.Message;
                SearchPanel.Visible = true;
            }
        }
    }
}