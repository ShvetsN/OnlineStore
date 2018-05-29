using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IOrderService
    {
        Task<bool> CreateOrder(OrderBLL order);
        Task<bool> Process(int id, bool confirmed);
    }
}
