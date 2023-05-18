using IcSMP.DataContext;
using IcSMP.Models;
using IcSMP.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Newtonsoft.Json.Linq;
using System.Linq;
namespace IcSMP.Services
{
    public class MethodsCalculation : IMethodsCalculation
    {
        public readonly IcSMPDataContext _context;

        private string connectionString = "Server=localhost\\SQLEXPRESS; Initial Catalog=IcStock; Trusted_Connection=True; ConnectRetryCount=0; Encrypt=False";
        public MethodsCalculation(IcSMPDataContext context)
        {
            _context = context;
        }
        
        const decimal vatRate = 0.19M;


        //public decimal CalculateVat(int id ,decimal sellPrice)
        //{
        //    string columnUpdateInDatabase = "SellPriceVat";

        //    decimal vat = sellPrice * vatRate;
        //    decimal sellPriceWhitVat = sellPrice + vat;
        //    decimal updateValue = sellPriceWhitVat;

        //    SaveToDatabase(id, updateValue, columnUpdateInDatabase);

        //    return sellPriceWhitVat;
        //}

   
        public decimal calculatePriceWithoutVat(int id , decimal Price_Whit_Vat, string columnUpdateInDatabase)
        {
            decimal vatAmount = Price_Whit_Vat / (1 + vatRate) * vatRate;
            decimal PriPrice_Whitout_Vatce = Price_Whit_Vat - vatAmount;
            decimal updateValue = PriPrice_Whitout_Vatce;

            SaveToDatabase(id, updateValue , columnUpdateInDatabase);

            return PriPrice_Whitout_Vatce;
        }

        public decimal calculateVat(int id, decimal Price_Whit_Vat, string columnUpdateInDatabase)
        {
            decimal vatAmount = Price_Whit_Vat / (1 + vatRate) * vatRate;
            
            decimal updateValue = vatAmount;

            SaveToDatabase(id, updateValue, columnUpdateInDatabase);

            return vatAmount;
        }

        public decimal calculateTotal_Sell(int id ,decimal sellPrice, int buc , string columnUpdateInDatabase)
        {
                   
            decimal result = sellPrice * buc;
            decimal updateValue = result;

            SaveToDatabase(id, updateValue, columnUpdateInDatabase);

            return result;
        }


        private void SaveToDatabase(int id, decimal updateValue, string columnUpdateInDatabase)
        {
            if (!string.IsNullOrEmpty(columnUpdateInDatabase))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = $"UPDATE Product SET {columnUpdateInDatabase} = @0 WHERE Id = @1";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@0", updateValue);
                    command.Parameters.AddWithValue("@1", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

       }
}
