namespace TeamTest.Services.Spa
{
    using System;
    using System.Collections.Generic;
    using TeamTest.Models.Entities;
    using TeamTest.Repositories.Repositories;
    using TeamTest.Services.Interfaces;

    public class ClientService : IClientService
    {
        private readonly ISpaRepository<Client> _clientRepository;

        public ClientService(ISpaRepository<Client> spaRepository)
        {
            _clientRepository = spaRepository;
        }
        public bool Save(Client client)
        {
            try
            {
                var result = false;
                if (client != null && client.Id != 0)
                {
                    Client existsClient = UpdateMap(client);
                    result = _clientRepository.Update(existsClient);
                }
                else
                {
                    result = _clientRepository.Add(client);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Client> GetAll()
        {
            try
            {
                var result = _clientRepository.List();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Client GetById(int clientId)
        {
            try
            {
                var result = _clientRepository.GetById(clientId);
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

        private Client UpdateMap(Client client)
        {
            var existclient = _clientRepository.GetById(client.Id);
            existclient.IdentificationNumber = client.IdentificationNumber;
            existclient.Name = client.Name;
            existclient.PhoneNumber = client.PhoneNumber;
            existclient.Gender = client.Gender;
            existclient.Email = client.Email;
            return existclient;
        }
    }
}
