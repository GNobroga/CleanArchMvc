using CleanArchMvc.Application.Products.Commands.Base;

namespace CleanArchMvc.Application.Products.Commands;

public class ProductUpdateCommand(int id) : ProductCommand
{
    public int Id => id;
}