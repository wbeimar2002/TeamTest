namespace TeamTest.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TeamTest.Models.Entities;
    using TeamTest.Services.Interfaces;

    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            var result = _clientService.GetAll();

            return result;
        }

        [HttpPost]
        public bool Post([FromBody] Client value)
        {
            var result = _clientService.Save(value);

            return result;
        }

        [HttpDelete]
        public bool Delete([FromBody] int clientId)
        {
            var result = _clientService.Remove(clientId);
            return result;
        }
    }
}