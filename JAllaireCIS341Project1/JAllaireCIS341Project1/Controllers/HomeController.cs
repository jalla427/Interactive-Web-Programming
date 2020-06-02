using Microsoft.EntityFrameworkCore;
using JAllaireCIS341Project1.Data;
using JAllaireCIS341Project1.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace JAllaireCIS341Project1.Controllers
{
    public class HomeController : Controller
    {
        private readonly RestaurantContext _context;

        public HomeController(RestaurantContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListMenuItems()
        {
            List<MenuItem> items = _context.MenuItems.ToList<MenuItem>();
            return View(items);
        }

        [HttpGet]
        public IActionResult add(int id)
        {
            //Do I have this item in the cart already
            foreach(Cart c in _context.MyCart.Include(i => i.CartItems))
            {
                foreach (CartItem ci in c.CartItems)
                {
                    if (ci.CartItemID == id)
                    {
                        //Up quantity
                        ci.Quantity++;
                        List<Cart> itemsa = _context.MyCart.Include(i => i.CartItems).ThenInclude(fi => fi.MenuItem).ToList<Cart>();
                        return View("ShoppingCart", itemsa);
                    }
                }
            }
            //If not create new item
            var cartItem = new CartItem[]
            {
                new CartItem{CartID=1,MenuItemID=id,Quantity=1}
            };
            foreach(CartItem ci in cartItem)
            {
                _context.CartItems.Add(ci);
            }
            _context.SaveChanges();

            //Return Shopping Cart View
            List<Cart> items = _context.MyCart.Include(i => i.CartItems).ToList<Cart>();
            return View("ShoppingCart", items);
        }

        [HttpGet]
        public IActionResult PlaceOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PlaceOrder(string Email, string CCNumber)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                //Creates an order for each cart (only one)
                foreach(Cart c in  _context.MyCart.Include(i => i.CartItems).ThenInclude(fi => fi.MenuItem))
                {
                    var order = new CustomerOrder[]
                    {
                        new CustomerOrder{Email=Email,OrderDate=System.DateTime.Now,OrderStatusID=1,RestaurantID=1,CCExpirationDate=DateTime.Today, CCNumber=CCNumber}
                    };
                    foreach (CustomerOrder o in order)
                    {
                        _context.CustomerOrders.Add(o);
                        //Creates an order item for each cart item
                        foreach(CartItem ci in c.CartItems)
                        {
                            var orderItem = new OrderItem[]
                            {
                            new OrderItem{OrderItemID=o.CustomerOrderID,MenuItemID=ci.MenuItem.MenuItemID,Quantity=ci.Quantity}
                            };
                            foreach (OrderItem oi in orderItem)
                            {
                                _context.OrderItems.Add(oi);
                            } 
                        }
                        _context.SaveChanges();
                    }
                }
                _context.SaveChanges();

                ViewBag.Message = "*** Order successfully placed ***";
                List<Cart> items = _context.MyCart.Include(i => i.CartItems).ThenInclude(fi => fi.MenuItem).ToList<Cart>();
                return View("ShoppingCart", items);
            }
        }

        [HttpGet]
        public IActionResult ShoppingCart()
        {
            List<Cart> items = _context.MyCart.Include(i => i.CartItems).ToList<Cart>();
            return View(items);
        }

        [HttpGet]
        public IActionResult delete(int id)
        {
            //Hunt down and eliminate cart item with particular ID
            foreach(Cart c in _context.MyCart.Include(i => i.CartItems))
            {
                foreach (CartItem ci in c.CartItems)
                {
                    if (ci.CartItemID == id)
                    {
                        if(ci.Quantity == 1)
                        {
                            //Currently cannot delete 
                            _context.CartItems.Remove(ci);
                        }
                        else
                        {
                            ci.Quantity--;
                        }
                    }
                }
            }
            //Return Shopping Cart
            List<Cart> items = _context.MyCart.Include(i => i.CartItems).ThenInclude(fi => fi.MenuItem).ToList<Cart>();
            return View("ShoppingCart", items);
        }
    }
}
