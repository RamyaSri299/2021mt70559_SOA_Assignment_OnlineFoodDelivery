
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodDeliverySystem.Models
{
    public class OrderDetails
    {
        [Key]
        public int order_id { get; set; }
        public int TotalAmount { get; set; }
        public string Order_Status { get; set; }
        public string Delivery_status { get; set; }

        [ForeignKey("user")]
        public int user_id { get; set; }

        public CustomUserTable user { get; set; }

    }
}
