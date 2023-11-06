using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodDeliverySystem.DTO;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Models.DbContext;

namespace OnlineFoodDeliverySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;


        public OrderDetailsController(ApplicationDbContext _context)
        {
            _dbContext = _context;
        }

        [HttpGet]
        [Route("~/api/GetAllOrderDetails")]

        public async Task<IActionResult> GetAllOrderDetails()
        {
            try
            {
                List<OrderDetails> orderDetails = _dbContext.OrderDetails.ToList();


                if (orderDetails != null)
                {
                    return Ok(orderDetails);
                }
                return Ok("Order data is not present in database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("~/api/Getordersbyuser")]

        public async Task<ActionResult<OrderDTO>> Getordersbyuser(int id)
        {

            try
            {
                var orders = await _dbContext.OrderDetails.FindAsync(id);
                if (orders == null)
                {
                    return NotFound();
                }
                else
                {
                    var orderDetails = _dbContext.CustomUserDetails.Where(m => m.ID == orders.user_id).ToList();
                    OrderDTO order = new OrderDTO
                    {
                        order_id = orders.order_id,
                        TotalAmount = orders.TotalAmount,
                        Order_Status = orders.Order_Status,
                        Delivery_status= orders.Delivery_status,
                        user_id= orders.user_id,
 
                    };

                    if (orderDetails != null && orderDetails.Count() > 0)

                    {
                        order.user = new List<CustomUserTable>();
                        foreach (var items in orderDetails)
                        {
                            CustomUserTable userdetails = new CustomUserTable
                            {
                                ID = items.ID,
                                UserName = items.UserName,
                                Email = items.Email
                                
                            };
                            order.user.Add(userdetails);

                        }
                    }

                    return order;
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("~/api/createorders")]

        public async Task<ActionResult<OrderDTO>> createorders([FromBody] OrderRequestDTO orderRequest)
        {
            if (orderRequest == null)
            {
                return BadRequest("Invalid data");
            }
            try
            {
                var order = new OrderDetails
                {

                    TotalAmount = orderRequest.TotalAmount,
                    Order_Status = orderRequest.Order_Status,
                    Delivery_status= orderRequest.Delivery_status,
                    user_id= orderRequest.user_id,

                };
                _dbContext.OrderDetails.Add(order);
                await _dbContext.SaveChangesAsync();

                return await Getordersbyuser(order.user_id);
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server error:{ex.Message}");
            }

        }
    }
}
