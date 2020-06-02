namespace JAllaireCIS341Project1.Models
{
    public class MenuItemIngredient
    {
        //Keys
        public int MenuItemIngredientID { get; set; }
        public int MenuItemID { get; set; }
        public int IngredientID { get; set; }

        //Properties
        public int Quantity { get; set; }

        //Navigation Properties
        public MenuItem MenuItem { get; set;  }
        public Ingredient Ingredient { get; set; }
    }
}
