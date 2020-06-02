using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JAllaireCIS341Project1.Models
{
    public class CustomerOrder
    {
        //Keys
        public int CustomerOrderID { get; set; }
        public int RestaurantID { get; set; }
        public int OrderStatusID { get; set; }

        //Properties
        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Credit card number is required.")]
        [CreditCard(ErrorMessage = "Credit card number was not valid.")]
        [Display(Name = "Credit Card Number")]
        public string CCNumber { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Expiration Date")]
        public DateTime CCExpirationDate { get; set; }

        //Navigation Properties
        [Display(Name = "Order Status")]
        public OrderStatus OrderStatus { get; set; }
        public Restaurant Restaurant { get; set; }
        [Display(Name = "Order Items")]
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
