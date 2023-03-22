using System.ComponentModel.DataAnnotations;


namespace IcSMP.Models
{
    public class ClientModel
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }

        public bool IsPrivatePerson { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }


        public string Zipcode { get; set; }

        public string Municipality { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string BankAccount { get; set; }

    }
}
