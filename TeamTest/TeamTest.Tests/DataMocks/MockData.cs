using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Moq;
using TeamTest.Models.Dtos;
using TeamTest.Models.Entities;
using TeamTest.Repositories.Repositories;
using TeamTest.WebApi;

namespace TeamTest.Tests.DataMocks
{
    public class MockData
    {
        internal static readonly Client client1 = new Client()
        {
            Id = 1,
            Name = "Patient 1",
            Gender = "Male",
            IdentificationNumber = "8888888",
            PhoneNumber = "999999",
            Email = "clien1@mail.com"
        };
        internal static readonly Client client2 = new Client()
        {
            Id = 2,
            Name = "Patient 2",
            Gender = "Male",
            IdentificationNumber = "777777",
            PhoneNumber = "666666",
            Email = "clien2@mail.com"

        };
        internal static readonly ClientDto clientDto = new ClientDto()
        {
            Id = 2,
            Name = "Patient 2",
            Gender = "Male",
            IdentificationNumber = "777777",
            PhoneNumber = "666666",
            Email = "clien2@mail.com"

        };
        internal static ISpaRepository<Client> GetClientRepository()
        {
            var patientRepositoryMock = new Mock<ISpaRepository<Client>>();
            patientRepositoryMock.Setup(x => x.GetAll()).Returns(new[] { client1, client2 });
            patientRepositoryMock.Setup(x => x.GetById(1)).Returns(client1);
            patientRepositoryMock.Setup(x => x.GetById(2)).Returns(client2);
            return patientRepositoryMock.Object;
        }

        internal static IMapper GetMockAutomapper()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });
            var mapper = mockMapper.CreateMapper();
            return mapper;
        }




    }
}
