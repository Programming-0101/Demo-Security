using DemoEncryption.DAL;
using DemoEncryption.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            ListPeopleDecrypted();
            Console.Write("Given Name: ");
            string given = Console.ReadLine();
            Console.Write("Surname: ");
            string surname = Console.ReadLine();

            AddPerson(given, surname);
            ListPeople();
        }

        static void ListPeopleDecrypted()
        {
            using (var context = new ProtectedDBContext())
            {
                string command = "OPEN SYMMETRIC KEY SharedEncryptionKey "
                               + "DECRYPTION BY CERTIFICATE EncryptTestCert; "
                               + "EXEC ListPeople";
                var data = context.Database.SqlQuery<DecryptedPerson>(command);
                foreach (var item in data)
                {
                    Console.WriteLine(item.PersonID);
                    Console.WriteLine(item.GivenName);
                    Console.WriteLine(item.Surname);
                    //Console.WriteLine(Convert.ToBase64String(item.FirstName));
                    //Console.WriteLine(Convert.ToBase64String(item.LastName));
                }
            }
        }

        static void AddPerson(string given, string surname)
        {
            using (var context = new ProtectedDBContext())
            {
                string command = "OPEN SYMMETRIC KEY SharedEncryptionKey "
                               + "DECRYPTION BY CERTIFICATE EncryptTestCert; "
                               + "EXEC SavePerson @keyName, @firstName, @lastName";

                context.Database.ExecuteSqlCommand(command,
                                                   new SqlParameter
                                                   {
                                                       ParameterName = "keyName",
                                                       Value = "SharedEncryptionKey"
                                                   },
                                                   new SqlParameter
                                                   {
                                                       ParameterName = "firstName",
                                                       Value = given
                                                   },
                                                   new SqlParameter
                                                   {
                                                       ParameterName = "lastName",
                                                       Value = surname
                                                   });
            }
        }
        static void ListPeople()
        {
            using (var context = new ProtectedDBContext())
            {
                var data = context.People;
                foreach (var item in data)
                {
                    Console.WriteLine(item.PersonID);
                    Console.WriteLine(Convert.ToBase64String(item.FirstName));
                    Console.WriteLine(Convert.ToBase64String(item.LastName));
                }
            }
        }
    }
}
