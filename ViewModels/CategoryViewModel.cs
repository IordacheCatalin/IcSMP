using IcSMP.Models;

namespace IcSMP.ViewModels
{
    public class CategoryViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<CategoryModel> Category = new List<CategoryModel>();
    }
}
