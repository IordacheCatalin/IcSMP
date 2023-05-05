using IcSMP.DataContext;
using IcSMP.Models;
using IcSMP.Repositories;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using System.Linq;
namespace IcSMP.Services
{
    public class MethodsCalculation : IMethodsCalculation
    {
        public readonly IcSMPDataContext _context;

        public MethodsCalculation(IcSMPDataContext context)
        {
            _context = context;
        }

        public decimal CalculateVat(decimal sellPrice)        {
            decimal vatRate = 0.19M;
            decimal vat = sellPrice * vatRate;
            decimal sellPriceWhitVat = sellPrice + vat;
            return sellPriceWhitVat;
        }

        public decimal calculateTotalBuy(decimal buyprice, int buc)
        {
            decimal totalbuy = buc * buyprice;
            return totalbuy;
        }
    }
}
