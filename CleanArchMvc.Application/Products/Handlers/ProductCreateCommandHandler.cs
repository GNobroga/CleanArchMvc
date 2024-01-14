using AutoMapper;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers;

public class ProductCreateCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository) : IRequestHandler<ProductCreateCommand, Product>
{
    public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {

        _ = await categoryRepository.FindByIdAsync(request.CategoryId) ?? throw new ApplicationException("Category does not exist.");

        var product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image)
        {
            CategoryId = request.CategoryId
        };
        return await productRepository.SaveAsync(product);
    }
}