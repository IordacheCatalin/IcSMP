using IcSMP.Models;

namespace IcSMP.ViewModels
{
    public class SupplierViewModel
    {
        public string CompanyName { get; set; }

        public List<SupplierModel> Supplier = new List<SupplierModel>();
    }
}
