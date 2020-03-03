namespace TeamTest.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TeamTest.Models.Dtos;
    using TeamTest.Models.Entities;
    using TeamTest.Models.Payloads;

    public interface IClientService
    {
        IEnumerable<ClientDto> GetAll();
        ClientDto GetById(int clientId);
        bool Save(ClientPayload client);
        bool Remove(int clientId);
    }
}
