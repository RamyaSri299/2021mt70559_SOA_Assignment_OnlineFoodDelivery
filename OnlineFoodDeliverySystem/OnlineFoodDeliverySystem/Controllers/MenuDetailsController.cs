using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodDeliverySystem.DTO;
using OnlineFoodDeliverySystem.Models.DbContext;
using OnlineFoodDeliverySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace OnlineFoodDeliverySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;


        public MenuDetailsController(ApplicationDbContext _context)
        {
            _dbContext = _context;
        }

        [HttpGet]
        [Route("~/api/GetMenuDetails")]

        public async Task<IActionResult> GetMenuDetails()
        {
            try
            {
                List<MenuItemsList> menuList = _dbContext.MenuDetails.ToList();


                if (menuList != null)
                {
                    return Ok(menuList);
                }
                return Ok("they are not MenuItems in the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("~/api/GetMenuitemById")]

        public async Task<ActionResult> GetMenuitemById(int id)
        {
            try
            {
                var MenuItem = await _dbContext.MenuDetails.FindAsync(id);
                //var MenuDetails = _dbContext.MenuDetails.Where(m => m.Item_ID == id).ToList();
                menuListRequestDTO menu = new menuListRequestDTO
                {

                    Item_Name = MenuItem.Item_Name,
                    Price = MenuItem.Price,
                    Type = MenuItem.Type,
                    Category = MenuItem.Category,
                    Restaurant_id = MenuItem.Restaurant_Id

                };
                if (menu != null)
                {
                    return Ok(menu);
                }
                return Ok("they are not menuItems in the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpGet]
        [Route("~/api/GetmenuItemWithRestaurant")]
        public async Task<ActionResult<MenuListDTO>> GetmenuItemWithRestaurant(int id)
        {

            var MenuItem = await _dbContext.MenuDetails.FindAsync(id);

            if (MenuItem == null)
            {
                return NotFound();
            }
            else
            {
                var RestaurentDetails= _dbContext.RestaurantDetails.Where(m=>m.Restaurant_id==MenuItem.Restaurant_Id).ToList();
                MenuListDTO menu = new MenuListDTO
                {

                    Item_Name = MenuItem.Item_Name,
                    Price=MenuItem.Price,
                    Type= MenuItem.Type,
                    Category=MenuItem.Category,
                    Restaurant_id=MenuItem.Restaurant_Id

                };

            if (RestaurentDetails!=null && RestaurentDetails.Count() > 0)

                {
                    menu.RestaurantDetails = new List<RestaurantDetails>();
                    foreach (var items in RestaurentDetails)
                    {
                        RestaurantDetails restaurant = new RestaurantDetails
                        {
                            Restaurant_id = items.Restaurant_id,
                            Restaurant_Name = items.Restaurant_Name,
                            address = items.address,
                            phone = items.phone
                        };
                        menu.RestaurantDetails.Add(restaurant);

                    }

                }
                return menu;
            }

           
        }

        [HttpPost]
        [Route("~/api/CreatemenuItems")]

        public async Task<ActionResult<MenuListDTO>> CreatemenuItems([FromBody]menuListRequestDTO menuItem)
        {
            if (menuItem == null)
            {
                return BadRequest("Invalid data");
            }
            try
            {
                var menuItemList = new MenuItemsList
                {
                   
                    Item_Name = menuItem.Item_Name,
                    Price= menuItem.Price,
                    Type = menuItem.Type,
                    Category = menuItem.Category,
                    Restaurant_Id = menuItem.Restaurant_id

                };
                _dbContext.MenuDetails.Add(menuItemList);
                await _dbContext.SaveChangesAsync();
                // return CreatedAtAction("GetMenuItemById", new { id = menuItemList.Item_ID });
                return await GetmenuItemWithRestaurant(menuItemList.Item_ID);
            }
           
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal Server error:{ex.Message}");
            }

        }
    
        

      
       
    }
}
