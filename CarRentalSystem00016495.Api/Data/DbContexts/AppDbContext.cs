using Microsoft.EntityFrameworkCore;
using CarRentalSystem00016495.Api.Domain.Entities;

namespace CarRentalSystem00016495.Api.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Rental> Rentals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .HasMany(c => c.Rentals)
            .WithOne(r => r.Car)
            .HasForeignKey(r => r.CarId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Rental>()
            .Property(r => r.TotalPrice)
            .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Car>()
            .Property(c => c.PricePerDay)
            .HasColumnType("decimal(18, 2)");
    }
}
