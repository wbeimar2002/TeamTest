using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TeamTest.Models.Entities;
using TeamTest.Repositories.Repositories;

namespace TeamTest.Services.Spa
{
    public class BrandService
    {
        private readonly ISpaRepository<Brand> _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(ISpaRepository<Brand> spaRepository, IMapper mapper)
        {
            _brandRepository = spaRepository;
            _mapper = mapper;
        }

        public Brand GetById(int brandId)
        {
            try
            {
                var result = _brandRepository.GetById(brandId);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
