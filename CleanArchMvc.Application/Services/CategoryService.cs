using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Entities;

namespace CleanArchMvc.Application.Services;

public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
{
    public async Task<CategoryDTO> AddAsync(CategoryDTO categoryDTO)
    {
        var category = mapper.Map<Category>(categoryDTO);
        await categoryRepository.SaveAsync(category);
        return mapper.Map<CategoryDTO>(category);
    }

    public async Task<CategoryDTO> GetByIdAsync(int id)
    {
        var category = await categoryRepository.FindByIdAsync(id);
        return mapper.Map<CategoryDTO>(category);
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
    {
        var categories = await categoryRepository.FindAllAsync();
        return mapper.Map<List<CategoryDTO>>(categories);
    }

    public async Task<CategoryDTO> RemoveAsync(int id)
    {
        var category = await categoryRepository.FindByIdAsync(id);
        await categoryRepository.DeleteAsync(category);
        return mapper.Map<CategoryDTO>(category);
    }

    public async Task<CategoryDTO> UpdateAsync(int id, CategoryDTO categoryDTO)
    {
        var category = await categoryRepository.FindByIdAsync(id);
        mapper.Map(categoryDTO, category);
        await categoryRepository.UpdateAsync(category);
        return mapper.Map<CategoryDTO>(category);
    }
}