using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class ProductRepository(ApplicationDbContext context) : Repository<Product>(context), IProductRepository
{
    public async Task<IEnumerable<Product>> GetProductsWithCategories()
    {
        return await _dbSet.Include(p => p.Category).AsNoTracking().ToListAsync();
    }
    public async Task<Product> GetProductWithCategory(int id)
    {
        var product = await _dbSet.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        return product!;
    }
}