﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories;

#nullable disable

namespace StoreApp.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20240205124343_start")]
    partial class start
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Books"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Electronic"
                        });
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Property<int>("productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Summary")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("price")
                        .HasColumnType("TEXT");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("productId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            productId = 1,
                            CategoryId = 2,
                            ImageUrl = "/images/computer.jpg",
                            Summary = "",
                            price = 20000m,
                            productName = "Computer"
                        },
                        new
                        {
                            productId = 2,
                            CategoryId = 2,
                            ImageUrl = "/images/keyboard.jpg",
                            Summary = "",
                            price = 1000m,
                            productName = "Keyboard"
                        },
                        new
                        {
                            productId = 3,
                            CategoryId = 2,
                            ImageUrl = "/images/mouse.jpg",
                            Summary = "",
                            price = 500m,
                            productName = "Mouse"
                        },
                        new
                        {
                            productId = 4,
                            CategoryId = 2,
                            ImageUrl = "/images/default.jpg",
                            Summary = "",
                            price = 10000m,
                            productName = "Monitor"
                        },
                        new
                        {
                            productId = 5,
                            CategoryId = 2,
                            ImageUrl = "/images/deck.jpg",
                            Summary = "",
                            price = 1500m,
                            productName = "Deck"
                        },
                        new
                        {
                            productId = 6,
                            CategoryId = 1,
                            ImageUrl = "/images/yagmursonrasi.jpg",
                            Summary = "",
                            price = 150m,
                            productName = "Yağmur Sonrası"
                        },
                        new
                        {
                            productId = 7,
                            CategoryId = 1,
                            ImageUrl = "/images/bogurtlenkisi.jpg",
                            Summary = "",
                            price = 200m,
                            productName = "Böğürtlen Kışı"
                        });
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.HasOne("Entities.Models.Category", "category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("category");
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
