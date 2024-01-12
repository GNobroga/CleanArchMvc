using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Entities.Base;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Entities;

public sealed class Category : BaseEntity
{
    public string Name { get; private set; }

    public ICollection<Product> Products { get; private set; } = [];

    public Category(string name)
    {
        ValidateDomain(name);
        Name = name;
    }

    public Category(int id, string name) : this(name)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id Value");
        Id = id;
    }

    public void Update(string name)
    {
        ValidateDomain(name);
        Name = name;
    }

    private static void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
            "Invalid category.Name is required");

        DomainExceptionValidation.When(name.Length < 3, 
        "Invalid category.Name, too short, minimum 3 characters");
    }
}