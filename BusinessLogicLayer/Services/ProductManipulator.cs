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
        }

        public async Task<bool> CreateProduct(ProductBLL product)
        {
            try
            {

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<bool> UpdateProduct(int id, ProductBLL updProduct)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }


    }
}
