﻿using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.Interfaces;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Models;
using UnitOfWork.Interfaces;
using UnitOfWork.Models;

namespace BusinessLogicLayer.Services
{
    public class CategoryService : BaseService, ICategoryService
    {

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<bool> CreateCategory(CategoryBLL category)
        {
            try
            {
                var item = _mapper.Map<UnitCategory>(category);
                await _unitOfWork.Categories.CreateAsync(item);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateCategory(CategoryBLL updCategory)
        {
            try
            {
                var item = _mapper.Map<UnitCategory>(updCategory);
                await _unitOfWork.Categories.UpdateAsync(item);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCategory(int id)
        {
            try
            {
                await _unitOfWork.Categories.DeleteAsync(id);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
