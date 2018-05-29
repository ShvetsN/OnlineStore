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
    public class StatisticService: BaseService, IStatisticService
    {

        public StatisticService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
   
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
