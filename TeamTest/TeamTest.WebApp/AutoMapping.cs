using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamTest.Models.Dtos;
using TeamTest.Models.Entities;
using AutoMapper;
using TeamTest.Models.Payloads;

namespace TeamTest.WebApi
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();
            CreateMap<ClientPayload, Client>();
        }
    }
}
