using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProductsAsync();

    Task<ProductDTO> GetByIdAsync(int id);

    Task<ProductDTO> GetProductCategoryAsync(int id);

    Task<ProductDTO> AddAsync(ProductDTO productDTO);

    Task<ProductDTO> UpdateAsync(int id, ProductDTO  productDTO);

    Task<ProductDTO> RemoveAsync(int id);
}