using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodDeliverySystem.Models
{
    public class MenuItemsList
    {

        [Key]
    public int Item_ID { get; set; }
        public string? Item_Name { get; set; }
        public string? Price { get; set; }
        public string? Type { get; set; }
        public string? Category { get; set; }

        [ForeignKey("Restaurants")]
        public int Restaurant_Id { get; set; }
        public RestaurantDetails Restaurants { get; set; }
       
    }
}
