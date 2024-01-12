using CleanArchMvc.Domain.Validation;
using CleanArchMvc.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class CategoryUnitTest
{
    [Fact(DisplayName = "Cannot create a category with invalid name")]
    public void CreateCategory_First_Case()
    {
        Action action = () => new Category(null!);
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid category.Name is required");
    }

    [Fact(DisplayName = "Cannot create a category with id fewer than zero")]
    public void CreateCategory_Second_Case()
    {
        Action action = () => new Category(-1, "abcd");
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid Id Value");
    }

    [Fact(DisplayName = "Cannot create a category with name fewer than 3 characters")]
    public void CreateCategory_Third_Case()
    {
        Action action = () => new Category(0, "el");
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid category.Name, too short, minimum 3 characters");
    }

}