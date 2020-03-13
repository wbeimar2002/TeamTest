namespace TeamTest.WebApi.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TeamTest.Models.Dtos;
    using TeamTest.Models.Payloads;
    using TeamTest.Services.Interfaces;

//#if !DEBUG
    //[Authorize]
//#endif
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IEnumerable<ClientDto> Get()
        {
            var result = _clientService.GetAll();

            return result;
        }

        [HttpPost]
        public bool Post([FromBody] ClientPayload value)
        {
            var result = _clientService.Save(value);

            return result;
        }

        [HttpDelete]
        public bool Delete(int clientId)
        {
            var result = _clientService.Remove(clientId);
            return result;
        }
    }
}