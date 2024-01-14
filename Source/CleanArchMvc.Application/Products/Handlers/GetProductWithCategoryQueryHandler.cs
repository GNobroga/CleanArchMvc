using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers;

public class GetProductWithCategoryQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductWithCategoryQuery, Product>
{
    public async Task<Product> Handle(GetProductWithCategoryQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetProductWithCategory(request.Id) ?? throw new ApplicationException("Product not found");
        return product;
    }
}