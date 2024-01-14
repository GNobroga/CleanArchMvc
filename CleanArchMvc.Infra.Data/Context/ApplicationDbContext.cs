using System.Reflection;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Entities.Base;
using CleanArchMvc.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Context;


public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
  public DbSet<Category> Categories { get; set; }

  public DbSet<Product> Products { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
      base.OnModelCreating(modelBuilder);
      modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
  }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      var entries = ChangeTracker.Entries().Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified);

      foreach (var entry in entries)
      {
        if (entry.Entity is not BaseEntity entity) continue;

        if (entry.State == EntityState.Modified)
        {
          entity.UpdatedAt = DateTime.Now;
        }
        else 
        {
          entity.CreatedAt = DateTime.Now;
        }
      }

      return base.SaveChangesAsync(cancellationToken);
    }

}