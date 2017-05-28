using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // User Security Info
            AuthType.Text = "Individual User Accounts";
            LoggedInUser.Text = User.Identity.Name;
            IsLoggedIn.Checked = Request.IsAuthenticated;
            NetworkDomainName.Text = Environment.UserDomainName;
            IsInRole.Text = User.IsInRole(RoleName.Text) ? "Yes" : "No";

            // Web Application Info
            WebAppIdentity.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            // Server Info
            IISVersion.Text = Request.ServerVariables["SERVER_SOFTWARE"];
            AuthenticationType.Text = User.Identity.AuthenticationType;
            DomainInfo.Text = Request.Url.Authority + " &hArr; " + (Request.IsLocal ? "127.0.0.1" : Request.UserHostAddress);
            MachineName.Text = Environment.MachineName;
            OSVersion.Text = Environment.OSVersion.ToString();
            //FriendlyOSVersion.Text = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
            //                          select x.GetPropertyValue("Caption")).FirstOrDefault();
        }
    }
}