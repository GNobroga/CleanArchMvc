using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Commands.Base;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Entities;

namespace CleanArchMvc.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CategoryDTO, Category>().ReverseMap();
        CreateMap<ProductDTO, Product>().ReverseMap();
        CreateMap<Product, ProductCommand>().ReverseMap();
    }
}