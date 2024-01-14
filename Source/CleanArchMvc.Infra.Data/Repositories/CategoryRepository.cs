using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Entities;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories.Base;

namespace CleanArchMvc.Infra.Data.Repositories;

public class CategoryRepository(ApplicationDbContext context) : Repository<Category, int>(context), ICategoryRepository
{

}