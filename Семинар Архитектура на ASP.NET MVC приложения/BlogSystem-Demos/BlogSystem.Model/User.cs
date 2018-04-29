namespace BlogSystem.Model
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        public string Id { get; set; }

        public ContactInformation Contacts { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return this.Contacts.FirstName + " " + this.Contacts.LastName;
            }
        }
    }
}
