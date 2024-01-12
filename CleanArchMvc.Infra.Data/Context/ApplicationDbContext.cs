using System.Reflection;
using CleanArchMvc.Domain.Entities;
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

}