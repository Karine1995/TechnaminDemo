using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Common;
using BLL.Services;
using DAL.Entities;
using DTOs;

namespace BLL.Mappers
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
