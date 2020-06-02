namespace JAllaireCIS341Project1.Models
{
    public class OrderItem
    {
        //Keys
        public int OrderItemID { get; set; }
        public int CustomerOrderID { get; set; }
        public int MenuItemID { get; set; }

        //Properties
        public int Quantity { get; set; }
    }
}
