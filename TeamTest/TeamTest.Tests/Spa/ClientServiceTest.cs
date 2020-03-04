using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamTest.Models.Dtos;
using TeamTest.Models.Entities;
using TeamTest.Services.Interfaces;
using TeamTest.Services.Spa;
using TeamTest.Tests.DataMocks;

namespace TeamTest.Tests.Spa
{
    [TestClass]
    public class ClientServiceTest
    {
        private IClientService _ClientService;

        [TestInitialize]
        public void TestInitialize()
        {
            _ClientService = new ClientService(MockData.GetClientRepository(), MockData.GetMockAutomapper());
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void GetAllClients()
        {
            var result = _ClientService.GetAll().ToList();

            Assert.AreEqual(2,result.Count());
        }
    }
}
