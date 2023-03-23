using System.ComponentModel.DataAnnotations;


namespace IcSMP.Models
{
    public class CourierModel
    {
        [Key]
        public int Id { get; set; }

        public string CourierName { get; set; }


        public string Description { get; set; }
    }
}
