using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JAllaireCIS341Project1.Models
{
    public class IngredientOrder
    {
        //Keys
        public int IngredientOrderID { get; set; }
        public int RestaurantID { get; set; }
        public int OrderStatusID { get; set; }

        //Properties
        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        [EmailAddress]
        [Display(Name = "Manager Email")]
        public string ManagerEmail { get; set; }
        [Display(Name = "Order Value")]
        public int OrderValue { get; set; }


        //Navigation Properties
        [Display(Name = "Order Status")]
        public OrderStatus OrderStatus { get; set; }
        public Restaurant Restaurant { get; set; }
        [Display(Name = "Order Items")]
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
