using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;

namespace Website.Backend
{
    public static class SecurityExtensions
    {
        /// <summary>
        /// Determines whether the current principal belongs to the specified role as managed by this application.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="role">The name of the role for which to check membership.</param>
        /// <returns>true if the current principal is a member of the specified role; otherwise, false.</returns>
        public static bool IsInAppRole(this IPrincipal self, string role)
        {
            return AppSecurity.Create().IsInAppRole(self.Identity.Name, role);
        }
    }
}