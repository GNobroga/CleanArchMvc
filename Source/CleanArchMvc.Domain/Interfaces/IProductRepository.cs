using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces.Base;

namespace CleanArchMvc.Domain.Interfaces;

public interface IProductRepository : IRepository<Product, int>
{
    Task<IEnumerable<Product>> GetWithCategories();
    Task<Product> GetWithCategory(int id);
}