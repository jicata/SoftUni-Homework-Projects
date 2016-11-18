namespace Phonebook.Models
{
    public class Phone
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public virtual Contact Contact { get; set; }


        public override string ToString()
        {
            return $"{this.PhoneNumber}";
        }
    }
}
