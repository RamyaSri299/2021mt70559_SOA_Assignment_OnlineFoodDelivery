using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodDeliverySystem.Models.DbContext;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.DTO;

namespace OnlineFoodDeliverySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;


        public RatingController(ApplicationDbContext _context)
        {
            _dbContext = _context;
        }

        [HttpGet]
        [Route("~/api/GetRestaurantRatingDetails")]

        public async Task<IActionResult> GetAllRestaurantRatingDetails()
        {
            try
            {
                List<Rating> Ratingdetails = _dbContext.Rating.ToList();


                if (Ratingdetails != null)
                {
                    return Ok(Ratingdetails);
                }
                return Ok("Ratings are not given to the restaurant in database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("~/api/GetRatingbyRestaurant")]

        public async Task<ActionResult<RatingDTO>> GetRatingbyRestaurant(int id)
        {


            try
            {
                var Rating = await _dbContext.Rating.FindAsync(id);
                if (Rating == null)
                {
                    return NotFound();
                }
                else
                {
                    var RestaurentDetails = _dbContext.RestaurantDetails.Where(m => m.Restaurant_id == Rating.restaurant_id).ToList();
                    RatingDTO RestaurantRating = new RatingDTO
                    {
                        rating_id = Rating.rating_id,
                        rating= Rating.rating,
                        restaurant_id = Rating.restaurant_id

                    };
                   
                    if (RestaurentDetails != null && RestaurentDetails.Count() > 0)

                    {
                        RestaurantRating.Restaurants = new List<RestaurantDetails>();
                        foreach (var items in RestaurentDetails)
                        {
                            RestaurantDetails restaurant = new RestaurantDetails
                            {
                                Restaurant_id = items.Restaurant_id,
                                Restaurant_Name = items.Restaurant_Name,
                                address = items.address,
                                phone = items.phone
                            };
                            RestaurantRating.Restaurants.Add(restaurant);

                        }
                    }

                    return RestaurantRating;
                }
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("~/api/CreateRatingToRestaurant")]

        public async Task<ActionResult<RatingDTO>> CreateRatingToRestaurant([FromBody] RatingRequestDTO ratingRequest)
        {
            if (ratingRequest == null)
            {
                return BadRequest("Invalid data");
            }
            try
            {
                var rating = new Rating
                {

                    rating = ratingRequest.rating,
                restaurant_id=ratingRequest.restaurant_id

                };
                _dbContext.Rating.Add(rating);
                await _dbContext.SaveChangesAsync();
                
                return await GetRatingbyRestaurant(rating.restaurant_id);
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server error:{ex.Message}");
            }

        }
    }
}
