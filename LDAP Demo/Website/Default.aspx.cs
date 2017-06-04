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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetDefaults();
                QueryLdap_Click(sender, e);
            }
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

                List<LdapEntry> details = new List<LdapEntry>();

                foreach (SearchResultEntry entry in searchResult.Entries)
                {
                    LdapEntry en = new LdapEntry()
                    {
                        DistinguishedName = entry.DistinguishedName,
                        Attributes = new List<LdapAttribute>()
                    };
                    foreach (string attrName in entry.Attributes.AttributeNames)
                    {
                        LdapAttribute at = new LdapAttribute()
                        {
                            Name = attrName,
                            Values = entry.Attributes[attrName].GetValues(typeof(string)).Cast<string>()
                        };
                        en.Attributes.Add(at);
                    }
                    details.Add(en);
                }

                LdapR.DataSource = details;
                LdapR.DataBind();
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