using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamTest.Models.Dtos;
using TeamTest.Models.Entities;
using AutoMapper;
using TeamTest.Models.Payloads;

namespace TeamTest.WebApi
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();
            CreateMap<ClientPayload, Client>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CategoryPayload, Category>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<Brand, BrandDto>();
        }
    }
}
