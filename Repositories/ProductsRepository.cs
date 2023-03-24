//using IcSMP.DataContext;
//using IcSMP.Models;
//using Microsoft.EntityFrameworkCore;

//namespace IcSMP.Repositories
//{
//    public class ProductsRepository
//    {
//        public readonly IcSMPDataContext _context;

//        public ProductsRepository(IcSMPDataContext context)
//        {
//            _context = context;
//        }

//        public DbSet<ProductModel> GetProducts()
//        {
//            return _context.Product;

//        }

//        public ProductModel GetProductById(int id)
//        {
//            ProductModel product = _context.Product.Find(id);
//            return product;
//        }



//    }
//}
