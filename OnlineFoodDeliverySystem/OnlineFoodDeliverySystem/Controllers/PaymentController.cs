using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodDeliverySystem.DTO;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Models.DbContext;

namespace OnlineFoodDeliverySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;


        public PaymentController(ApplicationDbContext _context)
        {
            _dbContext = _context;
        }

        [HttpPost("OrderPaymentDetails/{orderId}")]
        public async Task<IActionResult> OrderPaymentDetails([FromBody] PaymentSuccessModel SuccessData)
        {
            if (SuccessData.Status == "Success")
            {
                var payment = new Payment
                {
                    OrderID = SuccessData.OrderID,
                    AmountPaid = SuccessData.AmountPaid,
                    IsSuccessfull = true

                };
                _dbContext.Payment.Add(payment);
                _dbContext.SaveChanges();

                var order = _dbContext.OrderDetails.Find(SuccessData.OrderID);
                if(order != null)
                {
                    order.Order_Status = "order served!";
                    _dbContext.SaveChanges();
                }
                
                return Ok("payment successfull, order served");
            }
            
            if (SuccessData.Status == "Pending")
            {
                var payment = new Payment
                {
                    OrderID = SuccessData.OrderID,
                    AmountPaid = SuccessData.AmountPaid,
                    IsSuccessfull = false

                };
                _dbContext.Payment.Add(payment);
                _dbContext.SaveChanges();

                var order = _dbContext.OrderDetails.Find(SuccessData.OrderID);
                if (order != null)
                {
                    order.Order_Status = "Order is ready to prepare once payment will done";
                    _dbContext.SaveChanges();
                }

                return Ok("order is waiting for payment, Order Status is updated");
            }
            if (SuccessData.Status == "Failed")
            {
                var payment = new Payment
                {
                    OrderID = SuccessData.OrderID,
                    AmountPaid = SuccessData.AmountPaid,
                    IsSuccessfull = false

                };
                _dbContext.Payment.Add(payment);
                _dbContext.SaveChanges();

                var order = _dbContext.OrderDetails.Find(SuccessData.OrderID);
                if (order != null)
                {
                    order.Order_Status = "order cancelled due to payment failed";
                    _dbContext.SaveChanges();
                }

                return Ok("payment Failed, order Updated.");
            }
            else
            {
                return BadRequest("payment Cancelled");
            }


        }

    }
}
