using DemoIdentity.BLL;
using DemoIdentity.DAL;
using DemoIdentity.Entities;
using IdentityManager;
using IdentityManager.AspNetIdentity;
using IdentityManager.Configuration;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Website.Startup))]
namespace Website
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);

            app.Map("/idm", idm =>
            {
                var factory = new IdentityManagerServiceFactory();
                factory.IdentityManagerService = new Registration<IIdentityManagerService, ApplicationIdentityManagerService>();
                factory.Register(new Registration<ApplicationUserManager>());
                factory.Register(new Registration<ApplicationUserStore>());
                factory.Register(new Registration<ApplicationRoleManager>());
                factory.Register(new Registration<ApplicationRoleStore>());
                //factory.Register(new Registration<ApplicationDbContext>(resolver => new ApplicationDbContext("foo")));
                factory.Register(new Registration<ApplicationDbContext>());

                idm.UseIdentityManager(new IdentityManagerOptions
                {
                    Factory = factory
                });
            });
        }
    }

    public class ApplicationIdentityManagerService :
        AspNetIdentityManagerService<ApplicationUser, string, IdentityRole, string>
    {
        public ApplicationIdentityManagerService(ApplicationUserManager userMgr, ApplicationRoleManager roleMgr)
            : base(userMgr, roleMgr)
        {
        }
    }
}
