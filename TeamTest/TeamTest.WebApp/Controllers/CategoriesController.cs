using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamTest.Models.Dtos;
using TeamTest.Models.Payloads;
using TeamTest.Services.Interfaces;
using TeamTest.Services.Spa;

namespace TeamTest.WebApi.Controllers
{
//#if !DEBUG
    [Authorize]
//#endif
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;
        public CategoriesController(ICategoryService clientService)
        {
            _categoryService = clientService;
        }

        [HttpGet]
        public IEnumerable<CategoryDto> Get()
        {
            var result = _categoryService.GetAll();

            return result;
        }

        [HttpPost]
        public bool Post([FromBody] CategoryPayload value)
        {
            var result = _categoryService.Save(value);

            return result;
        }

        [HttpGet]
        [Route("GetCategoryById")]
        public CategoryDto GetById(int categoryId)
        {
            var result = _categoryService.GetById(categoryId);
            return result;
        }
    }
}