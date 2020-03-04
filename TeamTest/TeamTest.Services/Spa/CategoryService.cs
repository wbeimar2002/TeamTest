using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TeamTest.Models.Dtos;
using TeamTest.Models.Entities;
using TeamTest.Models.Payloads;
using TeamTest.Repositories.Repositories;
using TeamTest.Services.Interfaces;

namespace TeamTest.Services.Spa
{
    public class CategoryService: ICategoryService
    {
        private readonly ISpaRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ISpaRepository<Category> spaRepository, IMapper mapper)
        {
            _categoryRepository = spaRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            try
            {
                var result = _mapper.Map<IEnumerable<CategoryDto>>(_categoryRepository.GetAll());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CategoryDto GetById(int categoryId)
        {
            try
            {
                var result = _mapper.Map<CategoryDto>(_categoryRepository.GetById(categoryId));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Save(CategoryPayload category)
        {
            try
            {
                var result = false;
                if (category != null && category.Id != 0)
                {
                    result = _categoryRepository.Update(CatMap(category, false));
                }
                else
                {
                    result = _categoryRepository.Add(CatMap(category, true));
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Category CatMap(CategoryPayload category, bool isCreate)
        {
            Category result = new Category();
            if (!isCreate)
                result = _categoryRepository.GetById(category.Id);

            result.Name = category.Name;
            result.Description = category.Description;
            return result;
        }
    }
}
