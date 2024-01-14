using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services;

public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
{
    public async Task<ProductDTO> AddAsync(ProductDTO productDTO)
    {
        var product = mapper.Map<Product>(productDTO);
        await productRepository.SaveAsync(product);
        return mapper.Map<ProductDTO>(product);
    }

    public async Task<ProductDTO> GetByIdAsync(int id)
    {
        var product = await productRepository.FindByIdAsync(id);
        return mapper.Map<ProductDTO>(product);
    }

    public async Task<ProductDTO> GetProductCategoryAsync(int id)
    {
        var product = await productRepository.GetProductWithCategory(id);
        return mapper.Map<ProductDTO>(product);
    }

    public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
    {
        var products = await productRepository.FindAllAsync();
        return mapper.Map<List<ProductDTO>>(products);
    }

    public async Task<ProductDTO> RemoveAsync(int id)
    {
        var product = await productRepository.FindByIdAsync(id);
        await productRepository.DeleteAsync(product);
        return mapper.Map<ProductDTO>(product);
    }

    public async Task<ProductDTO> UpdateAsync(int id, ProductDTO productDTO)
    {
        var product = await productRepository.FindByIdAsync(id);
        mapper.Map(productDTO, product);
        await productRepository.UpdateAsync(product);
        return mapper.Map<ProductDTO>(product);
    }
}