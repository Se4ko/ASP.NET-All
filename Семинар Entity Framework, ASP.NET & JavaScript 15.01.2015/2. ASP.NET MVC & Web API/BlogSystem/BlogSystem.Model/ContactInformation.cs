namespace BlogSystem.Model
{
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class ContactInformation
    {
        [Column("Email")]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
