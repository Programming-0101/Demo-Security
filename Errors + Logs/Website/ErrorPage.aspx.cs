using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.UrlReferrer != null)
            {
                FromUrl.Text = "You came to this page from " + Request.UrlReferrer.OriginalString;
                var status = Request.QueryString["status"];
                if (!string.IsNullOrEmpty(status))
                    FromUrl.Text += " (with a status of " + status + ")";
            }
        }
    }
}