using System.Text;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class ProductUnitTest
{
    [Fact(DisplayName = "Cannot create a product with invalid inputs")]
    public void CreateProduct_First_Case()
    {
        Dictionary<string, Action> cases = new()
        {   
            {"Invalid name. product.Name is required", () => CreateProduct(null!, "description", 100, 100, null!)},
            {"product.Name is very short, minimum 3 characters", () => CreateProduct("pr", "description", 100, 100, null!)},
            {"product.Description is required.", () => CreateProduct("product", null!, 100, 100, null!)},
            {"product.Description is very short, minimum 5 characters", () => CreateProduct("product", "desc", 100, 100, null!)},
            {"product.Price needs be greather then or equals zero.", () => CreateProduct("product", "description", -1, 100, null!)},
            {"product.Stock needs be greather then or equals zero.", () => CreateProduct("product", "description", 100, -1, null!)},
            {"product.Image accepts at maximum 250 characters", () => CreateProduct("product", "description", 100, 100, GetLongText("A", 300))},
            {"Invalid Id value", () => CreateProduct(-1, "product", "description", 100, 100, null!)},
        };

        foreach (var (error, value) in cases)
            value.Should().Throw<DomainExceptionValidation>().WithMessage(error);
    }

    private string GetLongText(string value, int size) 
    {
        return new StringBuilder(value.Length * size)
            .Insert(0, value, size)
            .ToString();
    }

    private static Product CreateProduct(string name, string description, decimal price, int stock, string image)
    {
        return new Product(name, description, price, stock, image);
    }

    private static Product CreateProduct(int id, string name, string description, decimal price, int stock, string image)
    {
        return new Product(id, name, description, price, stock, image);
    }

}