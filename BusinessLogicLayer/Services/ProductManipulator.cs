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
<<<<<<< HEAD
    public class ProductManipulator: IProductManipulator
=======
    public class ProductManipulator : IProductManipulator
>>>>>>> 3c18d17f425ad70f3e26bec8249c25bdcd7880cc
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public ProductManipulator(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

<<<<<<< HEAD
        public Task<bool> CreateProduct(ProductBLL product)
        {
            try
            {
                return null;
=======
        public async Task<bool> CreateProduct(ProductBLL product)
        {
            try
            {

                return true;
>>>>>>> 3c18d17f425ad70f3e26bec8249c25bdcd7880cc
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
<<<<<<< HEAD
        
=======


>>>>>>> 3c18d17f425ad70f3e26bec8249c25bdcd7880cc
    }
}
