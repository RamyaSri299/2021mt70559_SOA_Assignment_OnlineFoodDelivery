using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodDeliverySystem.DTO
{
    public class OrderRequestDTO
    {
    
        public int TotalAmount { get; set; }
        public string Order_Status { get; set; }
        public string Delivery_status { get; set; }

        public int user_id { get; set; }
    }
}
