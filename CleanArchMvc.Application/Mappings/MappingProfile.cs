using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Entities;

namespace CleanArchMvc.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CategoryDTO, Category>().ReverseMap();
        CreateMap<ProductDTO, Product>().ReverseMap();
    }
}