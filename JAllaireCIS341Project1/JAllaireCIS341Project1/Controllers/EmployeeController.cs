using JAllaireCIS341Project1.Data;
using Microsoft.AspNetCore.Mvc;

namespace JAllaireCIS341Project1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly RestaurantContext _context;

        public EmployeeController(RestaurantContext context)
        {
            _context = context;
        }

        [Route("Orders/ListCustomerOrders")]
        public IActionResult ListCustomerOrders()
        {
            ViewData["Message"] = "Pending Customer Orders";

            return View();
        }

        [Route("Orders/ViewCustomerOrderDetails")]
        public IActionResult ViewCustomerOrderDetails()
        {
            ViewData["Message"] = "Order Details";

            return View();
        }

        [Route("Orders/UpdateCustomerOrders")]
        public IActionResult UpdateCustomerOrders()
        {
            ViewData["Message"] = "Update Order";

            return View();
        }

        [Route("Orders/DeleteCustomerOrders")]
        public IActionResult DeleteCustomerOrders()
        {
            ViewData["Message"] = "Delete Order";

            return View();
        }
    }
}
