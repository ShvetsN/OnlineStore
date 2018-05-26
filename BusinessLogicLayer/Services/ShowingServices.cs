using System;
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
    class ShowingServices : IShowing
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public ShowingServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

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

        public async Task<IEnumerable<ProductBLL>> GetForCategory(string category)
        {
            try
            {
                var products = await _unitOfWork.Products.ReadAllAsync();
               return _mapper.Map<IEnumerable<ProductBLL>>(products.Where(c => c.Category.Name == category));
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
                return _mapper.Map<IEnumerable<ProductBLL>>(products.Where(c => c.Name.Contains(request)));
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
