using System.ComponentModel.DataAnnotations;
namespace BangazonServer.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Uid { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string? Image {  get; set; }
        public ICollection<Product> Products { get; set; }
        public bool IsVendor { get; set; }
    }
}
