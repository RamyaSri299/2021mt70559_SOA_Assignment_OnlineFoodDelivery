using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodDeliverySystem.Models
{
    public class Payment
    {
        [Key]
        public int payment_Id { get; set; }
        
        public int AmountPaid  { get; set; }
        public bool IsSuccessfull { get; set; }
        [ForeignKey("orderDetails")]
        public int OrderID { get; set; }

       public OrderDetails orderDetails  { get; set; }
    }

}
