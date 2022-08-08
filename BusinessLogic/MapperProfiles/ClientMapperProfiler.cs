using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace BusinessLogic.MapperProfiles
{
    public class ClientMapperProfiler : Profile
    {
        public ClientMapperProfiler()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();
        }
    }
}
