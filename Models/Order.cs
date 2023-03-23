using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IcSMP.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime MaxDueDate { get; set; }
        public DateTime ShippingDate { get; set; }   


    }
}
