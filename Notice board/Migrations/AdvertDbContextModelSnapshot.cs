﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Notice_board.Data;

#nullable disable

namespace Notice_board.Migrations
{
    [DbContext(typeof(AdvertDbContext))]
    partial class AdvertDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Notice_board.Entities.Advert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                            Name = "MacBook 2021",
                            Price = 2200
                        });
                });

            modelBuilder.Entity("Notice_board.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("Notice_board.Entities.Advert", b =>
                {
                    b.HasOne("Notice_board.Entities.Category", "Category")
                        .WithMany("Adverts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Notice_board.Entities.Category", b =>
                {
                    b.Navigation("Adverts");
                });
#pragma warning restore 612, 618
        }
    }
}
