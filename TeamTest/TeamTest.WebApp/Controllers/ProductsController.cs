namespace TeamTest.WebApi.Controllers
{
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

//#if !DEBUG
    //[Authorize]
//#endif
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService  _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public bool Post([FromBody] ProductPayload value)
        {
            var result = _productService.Save(value);
            return result;
        }

        [HttpGet]
        public IEnumerable<ProductDto> Get()
        {
            var result = _productService.GetAll();

            return result;
        }
    }
}