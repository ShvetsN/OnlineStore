﻿using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Models;

namespace UnitOfWork.Interfaces
{
    public interface IOrderRepository : IRepository<Order,UnitOrder>
    {
        Task<IEnumerable<UnitOrder>> ReadAllWithProductsAsync();
        Task<UnitOrder> ReadWithProductsAsync(int id);
        Task AcceptOrder(int id);
        Task DeclineOrder(int id);
    }
}
