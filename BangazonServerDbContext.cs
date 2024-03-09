using Microsoft.EntityFrameworkCore;
using BangazonServer.Models;
using Microsoft.Extensions.Options;

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
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User {Id = 1, Uid = "xADM7ueUqUY7CPPNTjxpUQfgzNu2", Image = "", Username = "magsbags", FirstName = "Maggie", LastName = "Chafee", Email = "myemail@gmail.com", IsVendor = false},
                new User {Id = 2, Uid = "sdii73n390p89", Image = "https://i.etsystatic.com/isla/71bf5d/25387147/isla_280x280.25387147_8h2wthbu.jpg?version=0", Username = "lucky_stars_stitches", FirstName = "Natalie", LastName = "Mays", Email = "natalie.m@me.com", IsVendor = true},
                new User {Id = 3, Uid = "cXdi4knv90p45", Image = "", Username = "jayRude88", FirstName = "Jason", LastName = "Peterson", Email = "jayrude@yahoo.com", IsVendor = false},
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
                new Product {Id = 1, Name = "Seascape Painting", Image="https://i.pinimg.com/736x/9e/b6/f5/9eb6f55c2fdbb362434d6221d6d4a37b.jpg", Description = "It is a painting of the sea.", Price = 250.00M, IsAvailable = true, DateCreated = new DateTime(2024, 2, 1), CategoryId = 1, VendorId = 3},
                new Product {Id = 2, Name = "Orchid Charcoal Drawing", Image="https://blaxill.com/graphics/white_orchids_ch.jpg", Description = "It is a charcoal drawing of a flower.", Price = 150.00M, IsAvailable = true, DateCreated = new DateTime(2024, 1, 1), CategoryId = 1, VendorId = 3},
                new Product {Id = 3, Name = "Teacup Felt Embroidery", Image="https://i.etsystatic.com/19196972/r/il/7f93f4/4298409161/il_794xN.4298409161_25mf.jpg", Description = "Embroidered Teacup", Price = 50.00M, IsAvailable = false, DateCreated = new DateTime(2024, 1, 15), CategoryId = 2, VendorId = 2},
                new Product {Id = 4, Name = "Custom Denim Jacket Embroidery", Image = "https://i.etsystatic.com/14731249/r/il/61d043/2682960726/il_570xN.2682960726_7kl3.jpg", Description = "Choose Your Own Adventure", Price = 100.00M, IsAvailable = true, DateCreated = new DateTime(2024, 1, 21), CategoryId = 2, VendorId = 2},
                new Product {Id = 5, Name = "Iris Charcoal Drawing", Image="https://i.etsystatic.com/11855537/r/il/f543e3/2067126220/il_fullxfull.2067126220_jrw7.jpg", Description = "A charcoal drawing of an iris.", Price = 100.00M, IsAvailable = false, DateCreated = new DateTime(2024, 1, 31), CategoryId = 1, VendorId = 3}
            });

            modelBuilder.Entity<Order>().HasData(new Order[]
            {
                new Order {Id = 1, PaymentTypeId = 2, CustomerId = 1, IsCompleted = true, DateCreated=new DateTime(2024, 2, 10), ShippingRequired = true},
                new Order {Id = 2, PaymentTypeId = 3, CustomerId = 2, IsCompleted = false, DateCreated=new DateTime(2024, 2, 12), ShippingRequired = false},
                new Order {Id = 3, PaymentTypeId = 1, CustomerId = 1, IsCompleted = true, DateCreated=new DateTime(2024, 2, 1), ShippingRequired = false},
                new Order {Id = 4, PaymentTypeId = 5, CustomerId = 3, IsCompleted = false, DateCreated=new DateTime(2024, 2, 4), ShippingRequired = true},          
            });

    }
    }



