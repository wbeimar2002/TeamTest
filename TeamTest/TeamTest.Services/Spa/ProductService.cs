using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TeamTest.Models.Dtos;
using TeamTest.Models.Entities;
using TeamTest.Models.Payloads;
using TeamTest.Repositories.Repositories;
using TeamTest.Services.Interfaces;
using System.Linq;

namespace TeamTest.Services.Spa
{
    public class ProductService : IProductService
    {
        private readonly ISpaRepository<Product> _productRepository;
        private readonly ISpaRepository<ProductCategory> _productCategoryRepository;
        private readonly ISpaRepository<Category> _categoryRepository;
        private readonly ISpaRepository<Brand> _brandRepository;
        private readonly IMapper _mapper;

        public ProductService(ISpaRepository<Product> spaRepository, IMapper mapper, ISpaRepository<Category> categoryRepository, ISpaRepository<ProductCategory> productsCategoriesRepository, ISpaRepository<Brand> brandRepository)
        {
            _productRepository = spaRepository;
            _categoryRepository = categoryRepository;
            _productCategoryRepository = productsCategoriesRepository;
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            try
            {
                var products = _productRepository.GetAllWithInclude("ProductCategory", "Brand");
                return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products.ToList()); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Save(ProductPayload product)
        {
            try
            {
                var result = false;
                if (product != null && product.Id != 0)
                {
                    result = _productRepository.Update(ProductMaptoSave(product, false));
                }
                else
                {
                    var prod = _productRepository.AddWithReturn(ProductMaptoSave(product, true));
                    foreach (var productcategory in product.ProductsCategories)
                    {
                        var productsCategories = new ProductCategory 
                        {
                            CategoryId = productcategory,
                            ProductId = prod.Id
                        };

                        _productCategoryRepository.Add(productsCategories);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Product ProductMaptoSave(ProductPayload product, bool isCreate)
        {
            Product result = new Product();
            if (!isCreate)
                result = _productRepository.GetById(product.Id);

            result.Name = product.Name;
            result.Description= product.Description;
            result.BrandId= product.BrandId;
            result.Photo = product.Photo;
            result.Price = product.Price;
            result.Stock= product.Stock;
            return result;
        }

        public IEnumerable<ProductCategory> GetProductCategories()
        {
            var productCategory = _productCategoryRepository.GetAll();
            return productCategory;
        }
    }
}
