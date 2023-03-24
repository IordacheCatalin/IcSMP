using System.ComponentModel.DataAnnotations;


namespace IcSMP.Models
{
    public class CategoryModel
    {

        [Key]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Maximum number of characters is 50!")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "Maximum number of characters is 50!")]
        public string Description { get; set; }

    }
}
