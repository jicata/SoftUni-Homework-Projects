namespace UniversitySystem.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class UniversityPerson
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

    }
}
