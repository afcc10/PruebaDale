using AutoMapper;
using Models.Models;


namespace DataAccess.Models.Mapper
{
    public class ClienteProfileMap : Profile
    {
        public ClienteProfileMap()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
        }
    }
}
