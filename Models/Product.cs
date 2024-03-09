using System.ComponentModel.DataAnnotations;
namespace BangazonServer.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime DateCreated { get; set; }
        public int VendorId { get; set; }
        public User Vendor { get; set; }
        public int CategoryId { get; set; }
        public List<Category> Category { get; set; }
        public ICollection<Order> Orders { get; set;}
    }
}
