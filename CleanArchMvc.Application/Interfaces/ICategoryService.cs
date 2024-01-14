using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
    Task<CategoryDTO> GetByIdAsync(int id);

    Task<CategoryDTO> AddAsync(CategoryDTO categoryDTO);

    Task<CategoryDTO> UpdateAsync(int id, CategoryDTO categoryDTO);

    Task<CategoryDTO> RemoveAsync(int id);
}