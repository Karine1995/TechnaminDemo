using AutoMapper;
using Common.Models.Inputs.Products;
using DAL.Entities;
using DTOs;

namespace BLL.Mappers.Profiles
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductInput, Product>();

            CreateMap<Product, ProductDTO>();
        }
    }
}
