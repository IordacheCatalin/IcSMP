using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IcSMP.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProductNumber { get; set; }

        public int Caen { get; set; }

        public string Description { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public double BuyPrice { get; set; }

        public double SellPrice { get; set; }

        public double SellPriceVat { get; set; }

    }
}
