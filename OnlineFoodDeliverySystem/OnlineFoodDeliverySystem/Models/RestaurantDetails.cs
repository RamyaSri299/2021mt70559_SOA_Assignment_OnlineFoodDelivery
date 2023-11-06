using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDeliverySystem.Models
{
    public class RestaurantDetails
    {
        [Key]
    public int Restaurant_id { get; set; }
        public string? Restaurant_Name { get; set; }
        public string? address { get; set; }
        public string? phone { get; set; }

    }
}
