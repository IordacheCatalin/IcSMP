namespace IcSMP.Services
{
    public interface IMethodsCalculation
    {
        public decimal CalculateVat(decimal sellPrice);
        public decimal calculateTotalBuy(decimal buyprice, int buc);
    }
}
