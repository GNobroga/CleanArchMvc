using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Products.Queries;

public class GetProductWithCategoryQuery(int id) : IRequest<Product> {
    public int Id => id;
};