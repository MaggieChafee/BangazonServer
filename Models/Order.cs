namespace BangazonServer.Models
{
    public class Order
    {
        public int Id { get; set; }
        public PaymentType PaymentType { get; set; }
        public bool IsCompleted { get; set; }
        public User Customer {  get; set; }
        public DateTime DateCreated { get; set; }
        public bool ShippingRequired { get; set; }
    }
}
