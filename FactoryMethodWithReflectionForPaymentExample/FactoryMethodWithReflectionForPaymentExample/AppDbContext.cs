using FactoryMethodWithReflectionForPaymentExample.Models;
using Microsoft.EntityFrameworkCore;

namespace FactoryMethodWithReflectionForPaymentExample;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Payment> Payments => Set<Payment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Payment entity
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PaymentName).IsRequired();
            entity.Property(e => e.PaymentClassName).IsRequired();
        });
    }
}