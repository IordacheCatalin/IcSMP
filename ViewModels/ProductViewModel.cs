using System.ComponentModel.DataAnnotations;

namespace IcSMP.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProductNumber { get; set; }

        public int Caen { get; set; }

        public string Description { get; set; }


        public string Supplier { get; set; }
        public int SupplierId { get; set; }


        public string Category { get; set; }
        public int CategoryId { get; set; }

        public decimal BuyPrice { get; set; }

        public decimal SellPrice { get; set; }

        public decimal SellPriceVat { get; set; }

    }
}
