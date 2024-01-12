using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces.Base;

namespace CleanArchMvc.Domain.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsWithCategories();
    Task<Product> GetProductWithCategory(int id);
}