using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using UnitOfWork.Interfaces;
using UnitOfWork.Models;


namespace BusinessLogicLayer.Services
{
    public class ProductManipulator : IProductManipulator
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public ProductManipulator(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mapper = mapper;
        }

        public async Task<bool> CreateProduct(ProductBLL product)
        {
            try
            {
                var item = _mapper.Map<UnitProduct>(product);
                await _unitOfWork.Products.CreateAsync(item);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateProduct(ProductBLL updProduct)
        {
            try
            {
                var item = _mapper.Map<UnitProduct>(updProduct);
                await _unitOfWork.Products.UpdateAsync(item);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                await _unitOfWork.Products.DeleteAsync(id);
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
