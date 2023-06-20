using IcSMP.DataContext;
using IcSMP.Models;
using Microsoft.EntityFrameworkCore;

namespace IcSMP.Repositories
{
    public class BrandsRepository
    {

        private readonly IcSMPDataContext _context;

        public BrandsRepository(IcSMPDataContext context)
        {
            _context = context;
        }

        public DbSet<BrandModel> GetBrands()
        {
            return _context.Brand;

        }

        public BrandModel GetBrandById(int id)
        {
            BrandModel brand = _context.Brand.Find(id);
            return brand;
        }

        public void AddBrand(BrandModel brand)
        {
            brand.Id = new();
            _context.Brand.Add(brand);
            _context.SaveChanges();
        }

        public void Update(BrandModel brand)
        {
            _context.Brand.Update(brand);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            BrandModel brand = GetBrandById(id);
            if (brand != null)
            {
                _context.Brand.Remove(brand);
                _context.SaveChanges();
            }
        }

    }
}
