using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JAllaireCIS341Project1.Models
{
    public class Cart
    {
        //Keys
        public int CartID { get; set; }

        //Navigation Properties
        [Display(Name = "Order Items")]
        public ICollection<CartItem> CartItems { get; set; }
    }
}