using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Website.Backend
{
    internal class AppSecurity
    {
        public const string APP_USER = "AppUser";

        public static AppSecurity Create()
        {
            return new AppSecurity();
        }

        private AppSecurity() { }

        public string[] GetUserRoles(string username)
        {
            using (var context = new AppSecurityContext())
            {
                var result = from data in context.UserRoles
                             where data.User.Equals(username)
                             select data.Role;
                return result.ToArray();
            }
        }

        public bool IsInAppRole(string username, string rolename, bool addIfNotExists = false)
        {
            bool isMatch = false;
            using (var context = new AppSecurityContext())
            {
                var match = context.UserRoles.Find(username, rolename);
                if (match != null)
                    isMatch = true;
                else if (addIfNotExists)
                {
                    context.UserRoles.Add(new UserRole() { User = username, Role = rolename });
                    context.SaveChanges();
                    isMatch = true;
                }
            }
            return isMatch;
        }
    }

    internal class AppSecurityContext : DbContext
    {
        public AppSecurityContext() : base("name=SecurityDb")
        {
        }
        public DbSet<UserRole> UserRoles { get; set; }
    }

    [Table("UserRoles", Schema="App")]
    internal class UserRole
    {
        [Key, Column(Order=0)]
        public string User { get; set; }
        [Key, Column(Order = 1)]
        public string Role { get; set; }
    }
}