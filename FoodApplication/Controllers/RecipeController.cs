using Microsoft.AspNetCore.Mvc;
using FoodApplication.Models;
using Microsoft.AspNetCore.Identity;
using NuGet.Packaging.Rules;
using NuGet.Protocol.VisualStudio;
using Microsoft.AspNetCore.Authorization;
using FoodApplication.ContextDBConfig;

namespace FoodApplication.Controllers
{
    public class RecipeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly FoodApplicationDBContext context;
        public RecipeController(UserManager<ApplicationUser> userManager,
            FoodApplicationDBContext dBContext ) 
        { 
        
        _userManager = userManager;
        this.context= dBContext;
        
        }
        public IActionResult Index()   
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetRecipeCard([FromBody] List<Recipe> recipes)
        { 
            return PartialView("_RecipeCard",recipes);
        }
        public IActionResult Search([FromQuery] String recipe)
        {
            ViewBag.Recipe =recipe;
            return View();


        }
        public  IActionResult Order([FromQuery] String id)
        {

            ViewBag.Id = id;
            return View();
           
        }
        [HttpPost]
        public async Task<IActionResult> ShowOrder( OrderRecipeDetails orderRecipeDetails )
        { 
            Random random = new Random();
            ViewBag.Price = Math.Round(random.Next(150, 500)/5.0) * 5;
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.UserId = user?.Id;
            ViewBag.Address = user?.Address;
            return PartialView("_ShowOrder", orderRecipeDetails);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Order([FromForm]Order order) 
        {
            order.OrderDate = DateTime.Now;
            if (ModelState.IsValid)
            {              
                context.Orders.Add(order);
                context.SaveChanges();
                return RedirectToAction("index", "Recipe");

            }
         return RedirectToAction("Order","Recipe",new {id= order.Id});
        
        }
    }
}
