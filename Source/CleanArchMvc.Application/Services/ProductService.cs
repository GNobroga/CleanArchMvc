using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Services;

public class ProductService(IMediator mediator, IMapper mapper) : IProductService
{
    #region Async method
    public async Task<ProductDTO> AddAsync(ProductDTO productDTO)
    {
        var product = mapper.Map<Product>(productDTO);
        var command = mapper.Map<ProductCreateCommand>(product);
        return mapper.Map<ProductDTO>(await mediator.Send(command));
    }

    public async Task<ProductDTO> GetByIdAsync(int id)
    {
        var command = new GetProductByIdQuery(id);
        var product = await mediator.Send(command);
        return mapper.Map<ProductDTO>(product);
    }

    public async Task<ProductDTO> GetProductCategoryAsync(int id)
    {
        var command = new GetProductWithCategoryQuery(id);
        var product = await mediator.Send(command);
        return mapper.Map<ProductDTO>(product);
    }

    public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
    {
        var command = new GetProductsQuery();
        var products = await mediator.Send(command);
        return mapper.Map<List<ProductDTO>>(products);
    }

    public async Task<ProductDTO> RemoveAsync(int id)
    {
        var command = new ProductRemoveCommand(id);
        var product = await mediator.Send(command);
        return mapper.Map<ProductDTO>(product);
    }

    public async Task<ProductDTO> UpdateAsync(int id, ProductDTO productDTO)
    {   
        var query = new GetProductByIdQuery(id);
        var product = await mediator.Send(query);

        mapper.Map(productDTO, product);

        var command = new ProductUpdateCommand(id);

        mapper.Map(product, command);

        return mapper.Map<ProductDTO>(await mediator.Send(command));
    }
    #endregion
}