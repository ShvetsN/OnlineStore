﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using UnitOfWork.Interfaces;
using UnitOfWork.Models;
using UnitOfWork.UnitOfWork;
using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services
{
    class ShowingService : BaseService, IShowingService
    {

        public ShowingService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<IEnumerable<ProductBLL>> GetAll()
        {
            try
            {
                var products = await _unitOfWork.Products.ReadAllAsync();
                return _mapper.Map<IEnumerable<ProductBLL>>(products);
        }
            catch (Exception)
            {
                return null;
            }
}

        public async Task<IEnumerable<ProductBLL>> GetForCategory(int categoryId)
        {
            try
            {
               var products = await _unitOfWork.Products.ReadAllAsync();
               return _mapper.Map<IEnumerable<ProductBLL>>(products.Where(c => c.CategoryId == categoryId));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ProductBLL>> Search(string request)
        {
            try
            {
                var products = await _unitOfWork.Products.ReadAllAsync();
                return _mapper.Map<IEnumerable<ProductBLL>>(products.Where(c => c.Name.Equals(request, StringComparison.OrdinalIgnoreCase)));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ProductBLL>> GetFilter(int min, int max)
        {
            try
            {
                var products = await _unitOfWork.Products.ReadAllAsync();
                return _mapper.Map<IEnumerable<ProductBLL>>(products.Where(c => c.Price > min && c.Price < max));
            }
            catch (Exception)
            {
                return null;
            }
        }

        
    }
}
