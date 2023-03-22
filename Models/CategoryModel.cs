using System.ComponentModel.DataAnnotations;


namespace IcSMP.Models
{
    public class CategoryModel
    {

        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

    }
}
