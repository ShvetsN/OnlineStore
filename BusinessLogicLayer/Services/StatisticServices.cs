using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;
using AutoMapper;
using BusinessLogicLayer.Interfaces;
using UnitOfWork.Models;

namespace BusinessLogicLayer.Services
{
    public class StatisticServices: IStatisticService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public StatisticServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderBLL>> GetOrdersOfSpecialDay(DateTime date)
        {
            var orders = await _unitOfWork.Orders.ReadAllAsync();
            var items = orders.Where(c => c.Date == date ).ToList();
            return _mapper.Map<IEnumerable<OrderBLL>>(items);
        }

        public async Task<int> GetAmountOfSpecialProductsInOrders(ProductBLL product)
        {
            var prod = _mapper.Map<UnitProduct>(product);
            var orders = await _unitOfWork.Orders.ReadAllWithProductsAsync();
            orders.Where(c => c.Products == prod).ToList();
            return orders.Count();
        }
    }
}
