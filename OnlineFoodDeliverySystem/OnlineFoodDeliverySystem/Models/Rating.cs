using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDeliverySystem.Models
{
    public class Rating
    {
        [Key]
        public int rating_id { get; set; }
      
        public int rating { get; set; }
        

        [ForeignKey("Restaurants")]
        public int restaurant_id { get; set; }

        public RestaurantDetails Restaurants { get; set; }
    }
}
