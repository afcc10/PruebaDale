using System;
using AutoMapper;
using Models.Models;

namespace DataAccess.Models.Mapper
{
    public class ProductoProfileMap : Profile
    {
        public ProductoProfileMap()
        {
            CreateMap<Producto, ProductoDto>().ReverseMap();
        }
    }
}
