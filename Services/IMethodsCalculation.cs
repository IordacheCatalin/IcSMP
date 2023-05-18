using IcSMP.Models;
using IcSMP.ViewModels;

namespace IcSMP.Services
{
    public interface IMethodsCalculation
    {
        //public decimal CalculateVat(int id, decimal sellPrice);
        public decimal calculatePriceWithoutVat(int id, decimal Price_Whit_Vat, string columnUpdateInDatabase);
        public decimal calculateTotal_Sell(int id, decimal sellPrice, int buc, string columnUpdateInDatabase);

        public decimal calculateVat(int id, decimal Price_Whit_Vat, string columnUpdateInDatabase);

    }
}
