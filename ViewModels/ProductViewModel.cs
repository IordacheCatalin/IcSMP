using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IcSMP.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProductNumber { get; set; }

        public long Caen { get; set; }

        public string Description { get; set; }


        public string Supplier { get; set; }
        public int SupplierId { get; set; }


        public string Category { get; set; }
        public int CategoryId { get; set; }

        public decimal BuyPrice { get; set; }

        public decimal SellPrice { get; set; }

        public decimal SellPriceVat { get; set; }

        public int Buc { get; set; }

        [DisplayName("Total buy price")]
        public decimal TotalBuy { get; set; }

        //public decimal Vat { get; set; }

        //[DisplayName("Total sell price")]
        //public decimal TotalSell { get; set; }

        //[DisplayName("Total sell price + vat")]
        //public decimal TotalSellWhitVat { get; set; }
        //[DisplayName("Total buy buc * buy price")]
        //public decimal TotalBuyItem { get; set; }

        //[DisplayName("Total sell buc * sell price whit vat")]
        //public decimal Total_Sell_Whit_Vat_Item { get; set; }

        //[DisplayName("Total sell buc * sell price ")]
        //public decimal Total_Sell_Item { get; set; }

    }
}
