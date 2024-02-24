using Microsoft.EntityFrameworkCore;
using BangazonServer.Models;

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

            modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
            {
                new PaymentType {Id = 1, Name = "Visa"},
                new PaymentType {Id = 2, Name = "MasterCard"},
                new PaymentType {Id = 3, Name = "Amex"},
                new PaymentType {Id = 4, Name = "Paypal"},
                new PaymentType {Id = 5, Name = "Discover"}
            });

            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product {Id = 1, Name = "Seascape Painting", Description = "It is a painting of the sea.", Price = 250.00M, IsAvailable = true, DateCreated = new DateTime(2024, 2, 1), CategoryId = 1, VendorId = 3},
                new Product {Id = 2, Name = "Orchid Charcoal Drawing", Description = "It is a charcoal drawing of a flower.", Price = 150.00M, IsAvailable = true, DateCreated = new DateTime(2024, 1, 1), CategoryId = 1, VendorId = 3},
                new Product {Id = 3, Name = "Teacup Felt Embroidery", Description = "Embroidered Teacup", Price = 50.00M, IsAvailable = false, DateCreated = new DateTime(2024, 1, 15), CategoryId = 2, VendorId = 2},
                new Product {Id = 4, Name = "Custom Denim Jacket Embroidery", Description = "Choose Your Own Adventure", Price = 100.00M, IsAvailable = true, DateCreated = new DateTime(2024, 1, 21), CategoryId = 2, VendorId = 2},
                new Product {Id = 3, Name = "Iris Charcoal Drawing", Description = "A charcoal drawing of an iris.", Price = 100.00M, IsAvailable = false, DateCreated = new DateTime(2024, 1, 31), CategoryId = 1, VendorId = 3}
            });

            modelBuilder.Entity<Order>().HasData(new Order[]
            {
                new Order {Id = 1, PaymentTypeId = 2, CustomerId = 1, IsCompleted = true, DateCreated=new DateTime(2024, 2, 13), ShippingRequired = false},
                new Order {Id = 2, PaymentTypeId = 3, CustomerId = 2, IsCompleted = true, DateCreated=new DateTime(2024, 2, 13), ShippingRequired = false},
                new Order {Id = 3, PaymentTypeId = 1, CustomerId = 1, IsCompleted = true, DateCreated=new DateTime(2024, 2, 13), ShippingRequired = false},
                new Order {Id = 4, PaymentTypeId = 5, CustomerId = 1, IsCompleted = true, DateCreated=new DateTime(2024, 2, 13), ShippingRequired = false},
                new Order {Id = 5, PaymentTypeId = 4, CustomerId = 1, IsCompleted = true, DateCreated=new DateTime(2024, 2, 13), ShippingRequired = false},
            });
        }
    }



