﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BangazonServer.Migrations
{
    [DbContext(typeof(BangazonServerDbContext))]
    partial class BangazonServerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BangazonServer.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Visual Artwork"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Textile"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Gifts"
                        });
                });

            modelBuilder.Entity("BangazonServer.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("integer");

                    b.Property<bool>("ShippingRequired")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            DateCreated = new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsCompleted = true,
                            PaymentTypeId = 2,
                            ShippingRequired = true
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            DateCreated = new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsCompleted = false,
                            PaymentTypeId = 3,
                            ShippingRequired = false
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 1,
                            DateCreated = new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsCompleted = true,
                            PaymentTypeId = 1,
                            ShippingRequired = false
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 3,
                            DateCreated = new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsCompleted = false,
                            PaymentTypeId = 5,
                            ShippingRequired = true
                        });
                });

            modelBuilder.Entity("BangazonServer.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Visa"
                        },
                        new
                        {
                            Id = 2,
                            Name = "MasterCard"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Amex"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Paypal"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Discover"
                        });
                });

            modelBuilder.Entity("BangazonServer.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("VendorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("VendorId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            DateCreated = new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "It is a painting of the sea.",
                            Image = "https://i.pinimg.com/736x/9e/b6/f5/9eb6f55c2fdbb362434d6221d6d4a37b.jpg",
                            IsAvailable = true,
                            Name = "Seascape Painting",
                            Price = 250.00m,
                            VendorId = 3
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            DateCreated = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "It is a charcoal drawing of a flower.",
                            Image = "https://blaxill.com/graphics/white_orchids_ch.jpg",
                            IsAvailable = true,
                            Name = "Orchid Charcoal Drawing",
                            Price = 150.00m,
                            VendorId = 3
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            DateCreated = new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Embroidered Teacup",
                            Image = "https://i.etsystatic.com/19196972/r/il/7f93f4/4298409161/il_794xN.4298409161_25mf.jpg",
                            IsAvailable = false,
                            Name = "Teacup Felt Embroidery",
                            Price = 50.00m,
                            VendorId = 2
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            DateCreated = new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Choose Your Own Adventure",
                            Image = "https://i.etsystatic.com/14731249/r/il/61d043/2682960726/il_570xN.2682960726_7kl3.jpg",
                            IsAvailable = true,
                            Name = "Custom Denim Jacket Embroidery",
                            Price = 100.00m,
                            VendorId = 2
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            DateCreated = new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A charcoal drawing of an iris.",
                            Image = "https://i.etsystatic.com/11855537/r/il/f543e3/2067126220/il_fullxfull.2067126220_jrw7.jpg",
                            IsAvailable = false,
                            Name = "Iris Charcoal Drawing",
                            Price = 100.00m,
                            VendorId = 3
                        });
                });

            modelBuilder.Entity("BangazonServer.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<bool>("IsVendor")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "myemail@gmail.com",
                            FirstName = "Maggie",
                            Image = "",
                            IsVendor = false,
                            LastName = "Chafee",
                            Uid = "xADM7ueUqUY7CPPNTjxpUQfgzNu2",
                            Username = "magsbags"
                        },
                        new
                        {
                            Id = 2,
                            Email = "natalie.m@me.com",
                            FirstName = "Natalie",
                            Image = "https://i.etsystatic.com/isla/71bf5d/25387147/isla_280x280.25387147_8h2wthbu.jpg?version=0",
                            IsVendor = true,
                            LastName = "Mays",
                            Uid = "sdii73n390p89",
                            Username = "lucky_stars_stitches"
                        },
                        new
                        {
                            Id = 3,
                            Email = "jayrude@yahoo.com",
                            FirstName = "Jason",
                            Image = "",
                            IsVendor = false,
                            LastName = "Peterson",
                            Uid = "cXdi4knv90p45",
                            Username = "jayRude88"
                        });
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductsId")
                        .HasColumnType("integer");

                    b.HasKey("OrdersId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("BangazonServer.Models.Category", b =>
                {
                    b.HasOne("BangazonServer.Models.Product", null)
                        .WithMany("Category")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("BangazonServer.Models.Order", b =>
                {
                    b.HasOne("BangazonServer.Models.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BangazonServer.Models.Product", b =>
                {
                    b.HasOne("BangazonServer.Models.User", "Vendor")
                        .WithMany("Products")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("BangazonServer.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BangazonServer.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BangazonServer.Models.Product", b =>
                {
                    b.Navigation("Category");
                });

            modelBuilder.Entity("BangazonServer.Models.User", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
