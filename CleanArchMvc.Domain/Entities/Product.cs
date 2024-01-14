using System.ComponentModel.DataAnnotations.Schema;
using CleanArchMvc.Domain.Entities.Base;
using CleanArchMvc.Domain.Validation;
using CleanArchMvc.Entities;

namespace CleanArchMvc.Domain.Entities;

public sealed class Product : BaseEntity<int>
{
    public string Name { get; private set; }

    public string Description { get; private set; }

    public decimal Price { get; private set; }

    public int Stock { get; private set; }

    public string Image { get; private set; }

    public int CategoryId { get; set; }

    public Category? Category { get; set; }

    public Product(string name, string description, decimal price, int stock, string image)
    {
        ValidateDomain(name, description, price, stock, image);
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }

    public Product(int id, string name, string description, decimal price, int stock, string image) : this(name, description, price, stock, image)
    {   
        DomainExceptionValidation.When(id < 0, "Invalid Id value");
        ValidateDomain(name, description, price, stock, image);
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }

    public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
    {
        ValidateDomain(name, description, price, stock, image);
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
        CategoryId = categoryId;
    }

    private void ValidateDomain(string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "Invalid name. product.Name is required");

        DomainExceptionValidation.When(name.Length < 3,
            "product.Name is very short, minimum 3 characters");

        DomainExceptionValidation.When(string.IsNullOrEmpty(description),
            "product.Description is required.");

        DomainExceptionValidation.When(description.Length < 5,
            "product.Description is very short, minimum 5 characters");

        DomainExceptionValidation.When(price < 0,
            "product.Price needs be greather then or equals zero.");

        DomainExceptionValidation.When(stock < 0,
            "product.Stock needs be greather then or equals zero.");

        DomainExceptionValidation.When(image?.Length > 250,
            "product.Image accepts at maximum 250 characters");
    }
}