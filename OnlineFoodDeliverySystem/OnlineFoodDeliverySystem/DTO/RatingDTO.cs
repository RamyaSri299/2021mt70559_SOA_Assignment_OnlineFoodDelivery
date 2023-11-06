using OnlineFoodDeliverySystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodDeliverySystem.DTO
{
    public class RatingDTO
    {
        public int rating_id { get; set; }

        public int rating { get; set; }

        public int restaurant_id { get; set; }

        public List<RestaurantDetails> Restaurants { get; set; }
    }
}
