using System.Collections.Generic;

namespace JAllaireCIS341Project1.Models
{
    public class Restaurant
    {
        //Keys
        public int RestaurantID { get; set; }

        //Properties
        public string Name { get; set; }

        //Navigation Properties
        public ICollection<CustomerOrder> OrderItems { get; set; }
    }
}
