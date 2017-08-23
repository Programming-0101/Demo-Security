using DemoEncryption.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEncryption.DAL
{
    internal class ProtectedDBContext : DbContext
    {
        public ProtectedDBContext() : base("name=DemoDB")
        {
            Database.SetInitializer<ProtectedDBContext>(null);
        }

        public DbSet<Person> People { get; set; }
    }
}
