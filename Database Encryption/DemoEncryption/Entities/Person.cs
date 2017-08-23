using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEncryption.Entities
{
    [Table("People")] // Not really needed in this example
    public class Person
    {
        public int PersonID { get; set; }
        public byte[] FirstName { get; set; }
        public byte[] LastName { get; set; }
        public byte[] DOB { get; set; }

        // The following are not actual columns in the People table,
        [NotMapped]
        public string GivenName { get; set; }
        [NotMapped]
        public string Surname { get; set; }
    }
}
