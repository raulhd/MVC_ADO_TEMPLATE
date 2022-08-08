using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using Repositories;

namespace BusinessLogic.Service
{
    public class ClientService : IClientService
    {
        public IMapper Mapper { get; private set; }
        public IClientRepository ClientRepository { get; private set; }

        public ClientService(IMapper mapper, IClientRepository clientRepository)
        {
            Mapper = mapper;
            ClientRepository = clientRepository;
        }

        public ClientDto Create(ClientDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("dto");

            var client = Mapper.Map<Client>(dto);
            Client result = ClientRepository.Create(client);

            return Mapper.Map<ClientDto>(client);
        }

        public bool Delete(int id)
        {
            try
            {
                var client = ClientRepository.GetById(id);
                ClientRepository.Delete(id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public List<ClientDto> GetAll()
        {
            List<ClientDto> result = new List<ClientDto>();
            List<Client> clients = ClientRepository.GetAll();

            foreach (var item in clients)
            {
                result.Add(Mapper.Map<ClientDto>(item));
            };

            return result;
        }

        public ClientDto GetById(int id)
        {
            Client client = ClientRepository.GetById(id);

            return Mapper.Map<ClientDto>(client);
        }

        public ClientDto Update(ClientDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("dto");

            var client = Mapper.Map<Client>(dto);
            var result = ClientRepository.Update(client);

            return Mapper.Map<ClientDto>(client);
        }
    }
}
