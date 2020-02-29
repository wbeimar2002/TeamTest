namespace TeamTest.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TeamTest.Models.Entities;
    public interface IClientService
    {
        IEnumerable<Client> GetAll();
        Client GetById(int clientId);
        bool Create(Client client);
        bool Remove(int clientId);
    }
}
