namespace TeamTest.Services.Spa
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using TeamTest.Models.Dtos;
    using TeamTest.Models.Entities;
    using TeamTest.Models.Payloads;
    using TeamTest.Repositories.Repositories;
    using TeamTest.Services.Interfaces;

    public class ClientService : IClientService
    {
        private readonly ISpaRepository<Client> _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(ISpaRepository<Client> spaRepository, IMapper mapper)
        {
            _clientRepository = spaRepository;
            _mapper = mapper;
        }
        public bool Save(ClientPayload client)
        {
            try
            {
                var result = false;
                if (client != null && client.Id != 0)
                {
                    result = _clientRepository.Update(ClientMap(client,false));
                }
                else
                {
                    result = _clientRepository.Add(ClientMap(client,true));
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ClientDto> GetAll()
        {
            try
            {
                var result = _mapper.Map<IEnumerable<ClientDto>>(_clientRepository.GetAll());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClientDto GetById(int clientId)
        {
            try
            {
                var result = _mapper.Map<ClientDto>(_clientRepository.GetById(clientId));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Remove(int clientId)
        {
            try
            {
                var client = _clientRepository.GetById(clientId);
                var result = _clientRepository.Delete(client);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Client ClientMap(ClientPayload client, bool isCreate)
        {
            Client result = new Client();
            if(!isCreate)
                result = _clientRepository.GetById(client.Id);

            result.IdentificationNumber = client.IdentificationNumber;
            result.Name = client.Name;
            result.PhoneNumber = client.PhoneNumber;
            result.Gender = client.Gender;
            result.Email = client.Email;
            return result;
        }
    }
}
