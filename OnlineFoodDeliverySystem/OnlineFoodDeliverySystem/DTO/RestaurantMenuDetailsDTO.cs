using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodDeliverySystem.DTO
{
    public class RestaurantMenuDetailsDTO
    {
        public int Item_ID { get; set; }
        public string? Item_Name { get; set; }
        public string? Price { get; set; }
        public string? Type { get; set; }
        public string? Category { get; set; }
        public int Restaurant_id { get; set; }
        public string? Restaurant_Name { get; set; }
        public string? address { get; set; }
        public string? phone { get; set; }
    }
}
