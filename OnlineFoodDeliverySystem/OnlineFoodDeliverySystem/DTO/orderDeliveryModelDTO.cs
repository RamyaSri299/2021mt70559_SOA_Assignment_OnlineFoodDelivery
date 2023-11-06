using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodDeliverySystem.DTO
{
    public class orderDeliveryModelDTO
    {
        public int Delivery_Id { get; set; }

        public string DeliveryAddress { get; set; }
        public string Delivery_Status { get; set; }

        public int OrderID { get; set; }
    }
}
