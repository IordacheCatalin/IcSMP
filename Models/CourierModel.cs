using System.ComponentModel.DataAnnotations;


namespace IcSMP.Models
{
    public class CourierModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20, ErrorMessage = "Maximum number of characters is 50!")]
        public string CourierName { get; set; }

        [StringLength(20, ErrorMessage = "Maximum number of characters is 50!")]
        public string Description { get; set; }
    }
}
