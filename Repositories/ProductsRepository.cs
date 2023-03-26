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

        //metoda care va incarca Category.date in ViewModel

        public CategoryViewModel GetProductCategory(int id)
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            CategoryModel category = _context.Category.Find(id);

            if (category != null)
            {
                categoryViewModel.Name = category.Name;
                categoryViewModel.Description = category.Description;

                IQueryable<CategoryModel> categoryProduct = _context.Category.Where(x => x.Id == id);
                foreach (CategoryModel dbCategory in categoryProduct)
                {
                    categoryViewModel.Category.Add(dbCategory);
                }
            }
            return categoryViewModel;
        }

        //metoda care va incarca Suppliers.date in ViewModel

        public SupplierViewModel GetProductSuplier(int id)
        {
            SupplierViewModel supplierViewModel = new SupplierViewModel();
            SupplierModel supplier = _context.Supplier.Find(id);

            if (supplier != null)
            {
                supplierViewModel.CompanyName = supplier.CompanyName;

                IQueryable<SupplierModel> supplierProduct = _context.Supplier.Where(x => x.Id == id);

                foreach (SupplierModel dbSupplier in supplierProduct)
                {
                    supplierViewModel.Supplier.Add(dbSupplier);
                }
            }
            return supplierViewModel;
        }
    }
}
