using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JAllaireCIS341Project1.Models
{
    public class CartItem
    {
        //Keys
        [Key]
        public int CartItemID { get; set; }
        public int CartID { get; set; }
        public int MenuItemID { get; set; }

        //Properties
        public int Quantity { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
