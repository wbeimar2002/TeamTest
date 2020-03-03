using System;
using System.Collections.Generic;
using System.Text;
using TeamTest.Models.Dtos;
using TeamTest.Models.Payloads;

namespace TeamTest.Services.Interfaces
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryDto> GetAll();
        public CategoryDto GetById(int categoryId);
        public bool Save(CategoryPayload category);
    }
}
