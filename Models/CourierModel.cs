using System.ComponentModel.DataAnnotations;


namespace IcSMP.Models
{
    public class CourierModel
    {
        [Key]
        public int id { get; set; }

        public string CourierName { get; set; }


        public string DescriptionName { get; set; }
    }
}
