using JAllaireCIS341Project1.Data;
using Microsoft.AspNetCore.Mvc;

namespace JAllaireCIS341Project1.Controllers
{
    public class ManagerController : Controller
    {
        private readonly RestaurantContext _context;

        public ManagerController(RestaurantContext context)
        {
            _context = context;
        }

        [Route("Management/ListIngredients")]
        public IActionResult ListIngredients()
        {
            ViewData["Message"] = "In house ingredients";

            return View();
        }

        [Route("Management/CreateIngredientOrder")]
        public IActionResult CreateIngredientOrder()
        {
            ViewData["Message"] = "Create an ingredient order";

            return View();
        }

        [Route("Management/UpdateIngredientOrder")]
        public IActionResult UpdateIngredientOrder()
        {
            ViewData["Message"] = "Update ingredient order";

            return View();
        }

        [Route("Management/DeleteIngredientOrder")]
        public IActionResult DeleteIngredientOrder()
        {
            ViewData["Message"] = "Delete ingredient order";

            return View();
        }
    }
}
