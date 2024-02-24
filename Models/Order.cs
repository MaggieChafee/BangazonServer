namespace BangazonServer.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int PaymentTypeId { get; set; }
        public bool IsCompleted { get; set; }
        public int CustomerId {  get; set; }
        public User Customer { get; set; }
        public DateTime DateCreated { get; set; }
        public bool ShippingRequired { get; set; }
        public ICollection<Order> Products { get; set; }
    }
}
