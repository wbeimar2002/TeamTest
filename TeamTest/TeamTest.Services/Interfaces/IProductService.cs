using System;
using System.Collections.Generic;
using System.Text;
using TeamTest.Models.Dtos;
using TeamTest.Models.Payloads;

namespace TeamTest.Services.Interfaces
{
    public interface IProductService
    {
        public IEnumerable<ProductDto> GetAll();
        public bool Save(ProductPayload product);
    }
}
