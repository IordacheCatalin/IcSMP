using System.ComponentModel.DataAnnotations;

namespace IcSMP.Models
{
    public class SupplierModel
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }

        public string ContactName { get; set; }
        public string ContactTitle { get; set; }

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
