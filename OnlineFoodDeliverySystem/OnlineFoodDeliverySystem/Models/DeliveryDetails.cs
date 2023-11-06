using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodDeliverySystem.Models
{
    public class DeliveryDetails
    {
        [Key]
        public int Delivery_Id { get; set; }

        public string DeliveryAddress { get; set; }
        public string Delivery_Status { get; set; }

        [ForeignKey("orderDetails")]
        public int OrderID { get; set; }

        public OrderDetails orderDetails { get; set; }
    }
}
