using BangazonServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using BangazonServer.DTO;

var builder = WebApplication.CreateBuilder(args);

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<BangazonServerDbContext>(builder.Configuration["BangazonServerDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// CORS Configuration 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();

// GET All Products
app.MapGet("api/products", (BangazonServerDbContext db) =>
{
    return Results.Ok(db.Products.ToList());
});
// GET Recent Products - for homepage, gets 20 newest products
app.MapGet("api/products/new", (BangazonServerDbContext db) =>
{
    List<Product> newProducts = db.Products.OrderByDescending(s => s.DateCreated).Take(20).ToList();
    return Results.Ok(newProducts);
});
// GET Single Product - for product details
app.MapGet("api/products/{id}", (BangazonServerDbContext db, int id) =>
{
    Product product = db.Products.Include(p => p.Vendor).SingleOrDefault(p => p.Id == id);
    if (product == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(product);
});
// GET Products by Vendor
app.MapGet("api/products/vendor/{vendorId}", (BangazonServerDbContext db, int vendorId) =>
{
    List<Product> vendorsProducts = db.Products.Where(v => v.VendorId == vendorId).ToList();
    if (vendorsProducts == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(vendorsProducts);
});
// GET Products by Category
app.MapGet("api/products/category/{categoryId}", (BangazonServerDbContext db, int categoryId) =>
{
    List<Product> categoryProducts = db.Products.Where(v => v.CategoryId == categoryId).ToList();
    if (categoryProducts == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(categoryProducts);
});
// GET Open Order
app.MapGet("api/customers/{customerId}/openOrders", (BangazonServerDbContext db, int customerId) =>
{
    Order openOrder = db.Orders
    .Where(o => o.IsCompleted == false)
    .Include(o => o.Products)
    .SingleOrDefault(o => o.CustomerId == customerId);
    if (openOrder == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(openOrder);
});
// GET Customer Orders
app.MapGet("api/user/{userId}/order-history", (BangazonServerDbContext db, int userId) =>
{
    List<Order> orders = db.Orders
    .Include(o => o.Products)
    .Where(o => o.CustomerId == userId && o.IsCompleted == true)
    .ToList();

    if (orders == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(orders);
});
// GET Vendor Orders
app.MapGet("api/user/{vendorId}/vendor-orders", (BangazonServerDbContext db, int vendorId) =>
{

    List<Product> orders = db.Products.Include(o => o.Orders).ThenInclude(o => o.Customer).Where(p => p.VendorId == vendorId && p.Orders.Any(o => o.IsCompleted)).ToList();

    if (orders == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(orders);
});
// GET Single Order 
app.MapGet("api/orders/{orderId}", (BangazonServerDbContext db, int orderId) =>
{
    return Results.Ok(db.Orders.Include(o => o.Products).SingleOrDefault(o => o.Id == orderId));
});
// CREATE Order
app.MapPost("api/orders", (BangazonServerDbContext db, Order newOrder) =>
{
    db.Orders.Add(newOrder);
    db.SaveChanges();
    return Results.Created($"/api/orders/{newOrder.Id}", newOrder);
});
// UPDATE Order
app.MapPut("api/orders/{orderId}", (BangazonServerDbContext db, Order order, int orderId) =>
{
    Order orderUpdate = db.Orders.SingleOrDefault(o => o.Id == orderId);
    if (orderUpdate == null)
    {
        return Results.NotFound();
    }
    orderUpdate.IsCompleted = order.IsCompleted;
    orderUpdate.PaymentTypeId = order.PaymentTypeId;
    orderUpdate.ShippingRequired = order.ShippingRequired;

    db.SaveChanges();
    return Results.Ok();
});
// ADD Product to Order
app.MapPost("api/orders/add-product", (BangazonServerDbContext db, OrderProductDto orderProduct) =>
{ 
        var currentOrder = db.Orders.Include(o => o.Products).SingleOrDefault(o => o.Id == orderProduct.OrderId && o.IsCompleted == false);

        var addProduct = db.Products.SingleOrDefault(p => p.Id == orderProduct.ProductId);

        if (currentOrder == null)
        {
            return Results.BadRequest();
        }
        currentOrder.Products.Add(addProduct);
        db.SaveChanges();
        return Results.Ok();
});
// DELETE Product from Order
app.MapDelete("api/orders/{orderId}/delete-product/{productId}", (BangazonServerDbContext db, int orderId, int productId) =>
{
    var currentOrder = db.Orders.Include(o => o.Products).SingleOrDefault(o => o.Id == orderId);

    var removeProduct = db.Products.SingleOrDefault(p => p.Id == productId);

    if (currentOrder == null)
    {
        return Results.BadRequest();
    }
    currentOrder.Products.Remove(removeProduct);
    db.SaveChanges();
    return Results.Ok();
});
// Check User
app.MapGet("api/checkuser/{uid}", (BangazonServerDbContext db, string uid) =>
{
    var checkUser = db.Users.Where(x => x.Uid == uid).ToList();
    if (uid == null) 
    {
        return Results.NotFound();
    }
    return Results.Ok(checkUser);
});
// GET All Users
app.MapGet("api/users", (BangazonServerDbContext db) =>
{
    var users = db.Users.ToList();
    return Results.Ok(users);
});
// GET Single User
app.MapGet("api/user/{id}", (BangazonServerDbContext db, int id) =>
{
    var singleUser = db.Users.SingleOrDefault(u => u.Id == id);
    if (singleUser == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(singleUser);
});
// GET Vendors 
app.MapGet("api/vendors", (BangazonServerDbContext db) =>
{
    var allVendors = db.Users
    .Include(p => p.Products)
    .Where(u => u.IsVendor == true)
    .ToList();
    if (allVendors == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(allVendors);
});
// CREATE User
app.MapPost("api/register", (BangazonServerDbContext db, User newUser) =>
{
    db.Users.Add(newUser);
    db.SaveChanges();
    return Results.Created($"api/user/{newUser.Id}", newUser);
});
// UPDATE User
app.MapPut("api/users/{id}", (BangazonServerDbContext db, int id, User user) =>
{
    User userToUpdate = db.Users.SingleOrDefault(u => u.Id == id);
    if (userToUpdate == null)
    {
        return Results.NotFound();
    }
    userToUpdate.Username = user.Username;
    userToUpdate.FirstName = user.FirstName;
    userToUpdate.LastName = user.LastName;
    userToUpdate.Email = user.Email;
    userToUpdate.IsVendor = user.IsVendor;
    db.SaveChanges();
    return Results.NoContent();
});
// GET Payment Types
app.MapGet("api/payment-types", (BangazonServerDbContext db) =>
{
    var paymentTypes = db.PaymentTypes.ToList();
    return Results.Ok(paymentTypes);
});
// GET Categories
app.MapGet("api/categories", (BangazonServerDbContext db) =>
{
    var categories = db.Categories.ToList();
    return Results.Ok(categories);
});

app.Run();

