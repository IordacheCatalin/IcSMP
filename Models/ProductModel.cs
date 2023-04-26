using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IcSMP.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Maximum number of characters is 50!")]
        public string Name { get; set; }
        
        public int ProductNumber { get; set; }
        [DisplayName("Caen Code")]
        [Required(ErrorMessage = "Square Feet is Required")]
        //[Range(0, int.MaxValue, ErrorMessage = "Square Feet must be a positive number")]
        public long Caen { get; set; }

        public string Description { get; set; }
        [DisplayName("Supplier")]
        public int SupplierId { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        public decimal BuyPrice { get; set; }

        public decimal SellPrice { get; set; }

        public decimal SellPriceVat { get; set; }

        public int Buc { get; set; }

    }
}
