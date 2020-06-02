using System.Collections.Generic;

namespace JAllaireCIS341Project1.Models
{
    public class Ingredient
    {
        //Keys
        public int IngredientID { get; set; }

        //Properties
        public string Name { get; set; }
        public decimal WholeSalePrice { get; set; }
        public decimal StockLevel { get; set; }

        //Navigation Properties
        public ICollection<MenuItemIngredient> MenuItemIngredients { get; set; }
    }
}
