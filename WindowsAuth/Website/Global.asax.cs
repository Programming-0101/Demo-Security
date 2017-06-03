using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Website.Backend;

namespace Website
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        // Credits: https://brockallen.com/2012/05/23/think-twice-about-using-roleprovider/
        void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var ctx = HttpContext.Current;
            if (ctx.Request.IsAuthenticated)
            {
                string[] roles = AppSecurity.Create().GetUserRoles(ctx.User.Identity.Name);
                var newUser = new GenericPrincipal(ctx.User.Identity, roles);
                // Assign the updated user info to both
                // the current thread and the current HttpContext
                ctx.User = Thread.CurrentPrincipal = newUser;
            }
        }
    }
}