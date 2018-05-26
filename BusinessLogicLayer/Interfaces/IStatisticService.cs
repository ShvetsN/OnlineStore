using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IStatisticService
    {
        Task<IEnumerable<OrderBLL>> GetOrdersOfSpecialDay(DateTime date);
        Task<int> GetAmountOfSpecialProductsInOrders(ProductBLL product);
    }
}
