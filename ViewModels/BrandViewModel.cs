using IcSMP.Models;

namespace IcSMP.ViewModels
{
    public class BrandViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<BrandModel> Brand = new List<BrandModel>();
    }
}

