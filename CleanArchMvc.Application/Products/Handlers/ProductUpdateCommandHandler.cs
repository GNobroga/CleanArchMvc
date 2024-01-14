using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;


namespace CleanArchMvc.Application.Products.Handlers;

public class ProductUpdateCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository) : IRequestHandler<ProductUpdateCommand, Product>
{
    public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.FindByIdAsync(request.Id) ?? throw new ApplicationException("Product not found");

        _ = await categoryRepository.FindByIdAsync(request.CategoryId) ?? throw new ApplicationException("Category does not exist.");

        product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);

        return await productRepository.UpdateAsync(product);
    }
}