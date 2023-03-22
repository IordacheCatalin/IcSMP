using IcSMP.DataContext;
using IcSMP.Models;
using Microsoft.EntityFrameworkCore;

namespace IcSMP.Repositories
{
    //In the repository I implement the CRUD operation
    public class CategoriesRepository
    {
        private readonly IcSMPDataContext _context;
        public CategoriesRepository(IcSMPDataContext context)
        {
            _context = context;
        }

        //GET ALL FROM TABLE SECTION 
        public DbSet<CategoryModel> GetCategories()
        {
            return _context.Category;
        }

        //GET CODE FOR A CERTAIN ID

        public CategoryModel GetCatagoryById(int id)
        {
            CategoryModel category = _context.Category.Find(id);
            return category;

        }

        //ADD SECTION

        public void AddCategory(CategoryModel category)
        {

            _context.Category.Add(category);
            _context.SaveChanges();
        }

        //UPDATE SECTION

        public void Update(CategoryModel category)
        {

            _context.Category.Update(category);
            _context.SaveChanges();
        }
    }
}
