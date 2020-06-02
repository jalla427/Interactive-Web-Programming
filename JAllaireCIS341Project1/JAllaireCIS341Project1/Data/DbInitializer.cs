using JAllaireCIS341Project1.Models;
using System;
using System.Linq;

namespace JAllaireCIS341Project1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RestaurantContext context)
        {
            context.Database.EnsureCreated();

            //Look for any orders
            if (context.CustomerOrders.Any())
            {
                return;   //DB has been seeded
            }

            //Define restaurants
            var restaurants = new Restaurant[]
            {
                new Restaurant{Name="Stevens Point"},
                new Restaurant{Name="Wausau"}
            };

            //Iterate through Restaurant entities and add to DB context
            foreach (Restaurant r in restaurants)
            {
                context.Restaurants.Add(r);
            }

            //Save changes to DB
            context.SaveChanges();

            //Define ingredients
            var ingredients = new Ingredient[]
            {
                new Ingredient{Name="Beef",StockLevel=10,WholeSalePrice=3.99M},
                new Ingredient{Name="Chicken",StockLevel=10,WholeSalePrice=1.99M},
                new Ingredient{Name="Rice",StockLevel=10,WholeSalePrice=0.99M}
            };

            foreach (Ingredient i in ingredients)
            {
                context.Ingredients.Add(i);
            }

            context.SaveChanges();

            //Define menu items
            var fooditems = new MenuItem[]
            {
                new MenuItem{Name="Beef and Rice",Description="Delicious!",Price=9.99M},
                new MenuItem{Name="Chicken and Rice",Description="Even More Delicious!",Price=8.99M}
            };

            foreach (MenuItem f in fooditems)
            {
                context.MenuItems.Add(f);
            }

            context.SaveChanges();

            //Join table between Menu Items and Ingredients
            var ingredientmappings = new MenuItemIngredient[]
            {
                new MenuItemIngredient{MenuItemID=1,IngredientID=1,Quantity=1},
                new MenuItemIngredient{MenuItemID=1,IngredientID=3,Quantity=1},
                new MenuItemIngredient{MenuItemID=2,IngredientID=2,Quantity=1},
                new MenuItemIngredient{MenuItemID=2,IngredientID=3,Quantity=1}
            };

            foreach (MenuItemIngredient im in ingredientmappings)
            {
                context.MenuItemIngredients.Add(im);
            }

            context.SaveChanges();

            //Order statuses
            var orderstatuses = new OrderStatus[]
            {
                new OrderStatus{StatusText="Ordered"},
                new OrderStatus{StatusText="Being prepared"},
                new OrderStatus{StatusText="Ready for pickup"}
            };

            foreach (OrderStatus os in orderstatuses)
            {
                context.OrderStatuses.Add(os);
            }

            context.SaveChanges();

            //Cart
            var cart = new Cart[]
            {
                new Cart{}
            };

            foreach (Cart ca in cart)
            {
                context.MyCart.Add(ca);
            }

            context.SaveChanges();

            //Orders
            var customerorders = new CustomerOrder[]
            {
                new CustomerOrder{Email="foo@foo.com",OrderDate=DateTime.Now,OrderStatusID=1,RestaurantID=1,CCExpirationDate=DateTime.Today, CCNumber="1111222233334444"},
                new CustomerOrder{Email="foo@foo.com",OrderDate=DateTime.Now,OrderStatusID=1,RestaurantID=2,CCExpirationDate=DateTime.Today, CCNumber="5555222233334444"}
            };

            foreach (CustomerOrder co in customerorders)
            {
                context.CustomerOrders.Add(co);
            }

            context.SaveChanges();

            //Join table between Orders and Menu Items

            var orderitems = new OrderItem[]
            {
                new OrderItem{CustomerOrderID=1,MenuItemID=1,Quantity=3},
                new OrderItem{CustomerOrderID=2,MenuItemID=2,Quantity=1}
            };

            foreach (OrderItem oi in orderitems)
            {
                context.OrderItems.Add(oi);
            }

            context.SaveChanges();
        }
    }
}
