using System.Collections.Generic;
using Entities.Models;

namespace Repositories
{
    public interface IClientRepository
    {
        Client Create(Client dto);
        bool Delete(int id);
        List<Client> GetAll();
        Client GetById(int id);
        Client Update(Client client);
    }
}