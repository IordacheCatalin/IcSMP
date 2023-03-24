using System.ComponentModel.DataAnnotations;


namespace IcSMP.Models
{
    public class ClientModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Maximum number of characters is 50!")]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage = "Maximum number of characters is 50!")]
        public string LastName { get; set; }
        [StringLength(50, ErrorMessage = "Maximum number of characters is 50!")]
        public string IdentificationNumber { get; set; }

        public bool IsPrivatePerson { get; set; }
        [StringLength(50, ErrorMessage = "Maximum number of characters is 50!")]
        public string City { get; set; }
        [StringLength(50, ErrorMessage = "Maximum number of characters is 50!")]
        public string Street { get; set; }
        [StringLength(50, ErrorMessage = "Maximum number of characters is 50!")]
        public string Number { get; set; }
        [StringLength(50, ErrorMessage = "Maximum number of characters is 50!")]
        public string Zipcode { get; set; }
        [StringLength(50, ErrorMessage = "Maximum number of characters is 50!")]
        public string Municipality { get; set; }
        [StringLength(50, ErrorMessage = "Maximum number of characters is 50!")]
        public string Country { get; set; }
        [StringLength(50, ErrorMessage = "Maximum number of characters is 50!")]
        public string Phone { get; set; }
        [StringLength(50, ErrorMessage = "Maximum number of characters is 50!")]
        public string Email { get; set; }
        [StringLength(50, ErrorMessage = "Maximum number of characters is 50!")]
        public string BankAccount { get; set; }

    }
}
