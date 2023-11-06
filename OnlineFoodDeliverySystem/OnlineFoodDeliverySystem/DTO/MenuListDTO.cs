using OnlineFoodDeliverySystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodDeliverySystem.DTO
{
    public class MenuListDTO
    {
       
        public string Item_Name { get; set; }
        public string Price { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        
        public int Restaurant_id { get; set; }

        public List<RestaurantDetails> RestaurantDetails { get; set; }
    }
}
