using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JAllaireCIS341Project1.Models
{
    public class MenuItem
    {
        //Keys
        public int MenuItemID { get; set; }

        //Properties
        [Display(Name = "Menu Items")]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //Navigation Properties
        public ICollection<MenuItemIngredient> MenuItemIngredients { get; set; }
        public ICollection<CustomerOrder> OrderItems { get; set; }
    }
}
