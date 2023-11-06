using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineFoodDeliverySystem.DTO;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Models.DbContext;

namespace OnlineFoodDeliverySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;


        public RestaurantDetailsController(ApplicationDbContext _context)
        {
            _dbContext = _context;
        }

        [HttpGet]
        [Route("~/api/GetRestaurantDetails")]

        public async Task<IActionResult> GetRestaurantDetails()
        {
            try
            {
                List<RestaurantDetails> restaurantDetails= _dbContext.RestaurantDetails.ToList();


                if (restaurantDetails != null)
                {
                    return Ok(restaurantDetails);
                }
                return Ok("they are not books in the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDetails>> GetRestaurants(int id)
        {
            var restaurants = await _dbContext.RestaurantDetails.FindAsync(id);

            if (restaurants == null)
            {
                return NotFound();
            }

            return restaurants;
        }

        [HttpPost]
        [Route("~/api/PostRestaurantDetails")]

        public async Task<ActionResult<RestaurantDetails>> PostRestaurantDetails(RestaurantDTO restaurant)
        {
            var restaurantDetails = new RestaurantDetails
            {
                
                Restaurant_Name = restaurant.Restaurant_Name,
                address = restaurant.address,
                phone = restaurant.phone

            };

            _dbContext.RestaurantDetails.Add(restaurantDetails);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetRestaurantDetails", new { id = restaurantDetails.Restaurant_id }, restaurantDetails);

        }


    }
    }
