namespace DemoEncryption.Entities
{
    // Note that this entity isn't defined in the ProtectedDBContext class;
    // It is only used as the result set of calling the stored procedure ListPeople.
    public class DecryptedPerson
    {
        public int PersonID { get; set; }
        public byte[] FirstName { get; set; }
        public byte[] LastName { get; set; }
        public byte[] DOB { get; set; }

        // The following are not actual columns in the People table,
        // but are included in the results of the stored procedure ListPeople.
        public string GivenName { get; set; }
        public string Surname { get; set; }
    }
}
