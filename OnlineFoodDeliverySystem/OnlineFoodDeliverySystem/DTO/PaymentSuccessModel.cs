using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodDeliverySystem.DTO
{
    public class PaymentSuccessModel
    {
        public int payment_Id { get; set; }

        public int AmountPaid { get; set; }
        public bool IsSuccessfull { get; set; }

        public string Status { get; set; } 
        public int OrderID { get; set; }
    }
}
