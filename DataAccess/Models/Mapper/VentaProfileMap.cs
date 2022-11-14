using AutoMapper;
using Models.Models;


namespace DataAccess.Models.Mapper
{
    public class VentaProfileMap : Profile
    {
        public VentaProfileMap()
        {
            CreateMap<Venta, VentaDto>().ReverseMap();
        }
    }
}
