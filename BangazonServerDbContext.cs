using Microsoft.EntityFrameworkCore;
using BangazonServer.Models;

namespace BangazonServer
{
    public class BangazonServerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }

        public BangazonServerDbContext(DbContextOptions<BangazonServerDbContext> context) : base(context) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User {Id = 1, Uid = "judi73nv90p89", Username = "magsbags", FirstName = "Maggie", LastName = "Chafee", Email = "myemail@gmail.com", IsVendor = false},
                new User {Id = 2, Uid = "sdii73n390p89", Username = "lucky_stars_stitches", FirstName = "Natalie", LastName = "Mays", Email = "natalie.m@me.com", IsVendor = true},
                new User {Id = 3, Uid = "cXdi4knv90p45", Username = "jayRude88", FirstName = "Jason", LastName = "Peterson", Email = "jayrude@yahoo.com", IsVendor = false},
            });

            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category {Id = 1, Name = "Visual Artwork"},
                new Category {Id = 2, Name = "Textile"},
                new Category {Id = 3, Name = "Gifts"}
            });

            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product {Id = 1, Name = "Seascape Painting", Description = "It is a painting of the sea.", Price = 250.00M, IsAvailable = true, DateCreated = new DateTime(2024, 2, 1), CategoryId = 1, VendorId = 3}
                new Product {Id = 2, Name = "Seascape Painting", Description = "It is a painting of the sea.", Price = 250.00M, IsAvailable = true, DateCreated = new DateTime(2024, 2, 1), CategoryId = 1, VendorId = 3}
            });
        }
    }
}


