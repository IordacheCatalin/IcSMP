using IcSMP.DataContext;
using IcSMP.Models;
using IcSMP.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace IcSMP.Repositories
{
    public class ProductsRepository
    {
        public readonly IcSMPDataContext _context;

        private string connectionString = "Server=localhost\\SQLEXPRESS; Initial Catalog=IcStock; Trusted_Connection=True; ConnectRetryCount=0; Encrypt=False";


        public ProductsRepository(IcSMPDataContext context)
        {
            _context = context;
        }

        public DbSet<ProductModel> GetProducts()
        {
            return _context.Product;

        }

        public ProductModel GetProductById(int id)
        {
            ProductModel product = _context.Product.Find(id);
            return product;
        }

        public void AddProduct(ProductModel product)
        {
            product.Id = new();
            _context.Entry(product).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void UpdateProduct(ProductModel product)
        {
            _context.Product.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            ProductModel product = GetProductById(id);
            if (product != null)
            {
                _context.Product.Remove(product);
                _context.SaveChanges();
            }

        }
        //Method that calculate col1 * col2 an save tge result in database
        public decimal CalculateAndSave(string column1 , string column2 , string columnUpdateInDatabase)
        {
            decimal Result = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT Id, {column1} , {column2} , {columnUpdateInDatabase} FROM Product";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["Id"]);
                        decimal column1Value = (int)reader[$"{column1}"];
                        decimal column2Value = (decimal)reader[$"{column2}"];
                        decimal columnToSaveValue = (decimal)reader[$"{columnUpdateInDatabase}"];

                        

                        //if (columnToSaveValue == 0)
                        //{
                            columnToSaveValue = column1Value * column2Value;
                            // Save the result in another column
                            SaveToDatabase(id, columnToSaveValue , columnUpdateInDatabase);
                        //}
                    }

                    reader.Close();
                }
            }

            return Result;
        }

        //Method that calculate sum of a col an save tge result in database
        public decimal CalculateColumnValueAndSave(string column, string columnUpdateInDatabase)
        {
            decimal sum = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT Id, {column} FROM Product";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["Id"]);
                        decimal columnValue = (decimal)reader[$"{column}"];
                        sum += columnValue;

                        SaveToDatabase(id,sum, columnUpdateInDatabase);
                    }

                    reader.Close();
                }
            }

            return sum;
        }

        private void SaveToDatabase(int id, decimal columnToSaveValue , string columnUpdateInDatabase)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"UPDATE Product SET {columnUpdateInDatabase} = @0 WHERE Id = @id ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@0", columnToSaveValue);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
