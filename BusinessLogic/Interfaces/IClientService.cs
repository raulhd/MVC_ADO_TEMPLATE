using Entities.Dtos;
using System.Collections.Generic;

namespace BusinessLogic.Service
{
    public interface IClientService
    {
        ClientDto Create(ClientDto dto);
        bool Delete(int id);
        List<ClientDto> GetAll();
        ClientDto GetById(int id);
        ClientDto Update(ClientDto dto);
    }
}