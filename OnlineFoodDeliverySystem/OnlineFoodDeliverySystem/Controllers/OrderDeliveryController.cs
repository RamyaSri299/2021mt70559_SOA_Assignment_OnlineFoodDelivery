using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodDeliverySystem.DTO;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Models.DbContext;

namespace OnlineFoodDeliverySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDeliveryController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;


        public OrderDeliveryController(ApplicationDbContext _context)
        {
            _dbContext = _context;
        }


        [HttpPost("OrderDeliveryStatus/{orderID}")]
        public async Task<IActionResult> OrderDeliveryStatus([FromBody] orderDeliveryModelDTO Deliverystatus)
        {
            if (Deliverystatus.Delivery_Status == "Delivered")
            {
                var orderDelivery = new DeliveryDetails
                {
                    OrderID = Deliverystatus.OrderID,
                    DeliveryAddress = Deliverystatus.Delivery_Status,
                    Delivery_Status = Deliverystatus.Delivery_Status

                };
                _dbContext.DeliveryDetails.Add(orderDelivery);
                _dbContext.SaveChanges();

                var order = _dbContext.OrderDetails.Find(Deliverystatus.OrderID);
                if (order != null)
                {
                    order.Delivery_status = "Order Delivered";
                    _dbContext.SaveChanges();
                }

                return Ok("Order Delivered, updated in orders");
            }
            else
            {
                return BadRequest("Waiting for Delivery Update");
            }


        }
    }
}
