using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Data
{   
    public class AdvertDbContext : IdentityDbContext
    {
        public AdvertDbContext(DbContextOptions options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new[]
            {
            new Category() { Id = 1,Name="Electronic"},
            new Category() { Id = 2,Name="Sport"},
            new Category() { Id = 3,Name="Toys & Hobbies"}
            });

            modelBuilder.Entity<Advert>().HasData(new[]
        {
        new Advert(){Id=1, Name="MacBook 2019", CategoryId=1, Price=1500, City="Rovno",Description="Normal view",ContactInformation="0974585652", Foto= "https://content.rozetka.com.ua/goods/images/big/30872706.jpg"},
        new Advert(){Id=2, Name="Iphone 13", CategoryId=1,Price=850, City="Luchk",Description="Cool view",ContactInformation="0634584521",Foto= "https://img.ktc.ua/img/base/1/3/416083.jpg"},
        new Advert(){Id=3, Name="MacBook 2021", CategoryId=1,Price=2200, City="Lviv",Description="New",ContactInformation="0665241245",Foto= "https://appleworld.ua/content/images/46/480x269l50nn0/chekhol-nakladka-hard-shell-case-for-macbook-pro-14-prozrachnyy-93478982432795.jpg"}
            });
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Adverts_Board_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //    optionsBuilder.UseSqlServer("Data Source=USER-PC\\SQLEXPRESS;Initial Catalog=Adverts_Board_DB; Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //}

        //------------data collecting-------------
        public DbSet <Advert> Adverts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
 