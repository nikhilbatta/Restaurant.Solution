﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurant.Models;

namespace Restaurant.Migrations
{
    [DbContext(typeof(CuisineContext))]
    [Migration("20191016182846_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Restaurant.Models.Cuisine", b =>
                {
                    b.Property<int>("CuisineId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CuisineId");

                    b.ToTable("Cuisines");
                });

            modelBuilder.Entity("Restaurant.Models.RestaurantV", b =>
                {
                    b.Property<int>("RestaurantVId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CuisineId");

                    b.Property<string>("Name");

                    b.HasKey("RestaurantVId");

                    b.HasIndex("CuisineId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("Restaurant.Models.RestaurantV", b =>
                {
                    b.HasOne("Restaurant.Models.Cuisine", "Cuisine")
                        .WithMany("RestaurantVariable")
                        .HasForeignKey("CuisineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
