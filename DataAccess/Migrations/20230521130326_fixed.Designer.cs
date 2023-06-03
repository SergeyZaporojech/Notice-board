﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AdvertDbContext))]
    [Migration("20230521130326_fixed")]
    partial class @fixed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Data.Entities.Advert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactInformation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Adverts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            City = "Rovno",
                            ContactInformation = "0974585652",
                            Description = "Normal view",
                            Foto = "https://content.rozetka.com.ua/goods/images/big/30872706.jpg",
                            Name = "MacBook 2019",
                            Price = 1500
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            City = "Luchk",
                            ContactInformation = "0634584521",
                            Description = "Cool view",
                            Foto = "https://img.ktc.ua/img/base/1/3/416083.jpg",
                            Name = "Iphone 13",
                            Price = 850
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            City = "Lviv",
                            ContactInformation = "0665241245",
                            Description = "New",
                            Foto = "https://appleworld.ua/content/images/46/480x269l50nn0/chekhol-nakladka-hard-shell-case-for-macbook-pro-14-prozrachnyy-93478982432795.jpg",
                            Name = "MacBook 2021",
                            Price = 2200
                        });
                });

            modelBuilder.Entity("Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Electronic"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sport"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Toys & Hobbies"
                        });
                });

            modelBuilder.Entity("Data.Entities.Advert", b =>
                {
                    b.HasOne("Data.Entities.Category", "Category")
                        .WithMany("Adverts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Data.Entities.Category", b =>
                {
                    b.Navigation("Adverts");
                });
#pragma warning restore 612, 618
        }
    }
}
