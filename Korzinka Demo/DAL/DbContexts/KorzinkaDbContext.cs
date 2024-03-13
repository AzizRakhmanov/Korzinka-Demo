using Korzinka_Demo.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Korzinka_Demo.DAL.DbContexts
{
    public class KorzinkaDbContext : DbContext
    {
        public KorzinkaDbContext(DbContextOptions<KorzinkaDbContext> options)
            : base(options)
        { }

         public KorzinkaDbContext() { }
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserAddress> UserAddresses { get; set; }

        public DbSet<ProductAddress> ProductAddresses { get; set; }

        public DbSet<ShoppingCard> ShoppingCards { get; set; }  

        public DbSet<Check> Checks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=DESKTOP-4HKLI08\\MSSQLSERVER01;Database=Korzinka;Trusted_Connection=true;TrustServerCertificate=true;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //    .Property(p => p.Email)
            //    .HasAnnotation("")

            //modelBuilder.Entity<User>()
            //    .HasOne(p => p.PhoneNumber)
            //    .WithMany()
            //    .IsRequired(true)
            //    .HasConstraintName("Phone");

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
