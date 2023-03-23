using IcSMP.Models;
using Microsoft.EntityFrameworkCore;

namespace IcSMP.DataContext
{
    public class IcSMPDataContext : DbContext
    {
        public IcSMPDataContext(DbContextOptions<IcSMPDataContext> options) : base(options) { }

        public DbSet<CategoryModel> Category { get; set; }

        public DbSet<ClientModel> Client { get; set; }


        public DbSet<CourierModel> Courier { get; set; }

        //public DbSet<OrderModel> Orders { get; set; }

        //public DbSet<ProductModel> Products { get; set; }

        public DbSet<SupplierModel> Supplier { get; set; }
    }
}
