namespace Phonebook.Models
{
    using System.Threading;

    public class Email
    {
        public int Id { get; set; }

        public string EmailAdress { get; set; }

        public virtual Contact Contact { get; set; }

        public override string ToString()
        {
            return $"{this.EmailAdress}";
        }
    }
}
