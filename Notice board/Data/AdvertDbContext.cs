using Microsoft.EntityFrameworkCore;
using Notice_board.Entities;

namespace Notice_board.Data
{
    public class AdvertDbContext : DbContext
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
        new Advert(){Id=1, Name="MacBook 2019", CategoryId=1, Price=1500, City="Rovno",Description="Normal view",ContactInformation="0974585652"},
        new Advert(){Id=2, Name="Iphone 13", CategoryId=1,Price=850, City="Luchk",Description="Cool view",ContactInformation="0634584521"},
        new Advert(){Id=3, Name="MacBook 2021", CategoryId=1,Price=2200, City="Lviv",Description="New",ContactInformation="0665241245"}
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
 