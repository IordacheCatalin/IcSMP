using IcSMP.DataContext;
using IcSMP.Models;
using Microsoft.EntityFrameworkCore;

namespace IcSMP.Repositories
{
    public class SuppliersRepository
    {
        private readonly IcSMPDataContext _context;

        public SuppliersRepository(IcSMPDataContext context)
        {
            _context = context;
        }
        //GET ALL FROM TABLE SECTION 

        public DbSet<SupplierModel> GetSuppliers()
        {
            return _context.Supplier;
        }

        //GET CODE FOR A CERTAIN ID

        public SupplierModel GetSupplierById(int id)
        {
            SupplierModel supplier = _context.Supplier.Find(id);
            return supplier;
        }

        //ADD SECTION

        public void AddSupplier(SupplierModel supplier)
        {
            _context.Supplier.Add(supplier);
            _context.SaveChanges();
        }

        //UPDATE SECTION

        public void Update(SupplierModel supplier)
        {
            _context.Supplier.Update(supplier);
            _context.SaveChanges();
        }

        //DELETE SECTION

        public void Delete(int id) 
        {
            SupplierModel supplier = GetSupplierById(id);
            if(supplier != null)
            {
                _context.Supplier.Remove(supplier);
                _context.SaveChanges();
            }
        }
    }
}
