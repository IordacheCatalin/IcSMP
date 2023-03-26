using IcSMP.DataContext;
using IcSMP.Models;
using IcSMP.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace IcSMP.Repositories
{
    public class ProductsRepository
    {
        public readonly IcSMPDataContext _context;

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
    }
}
