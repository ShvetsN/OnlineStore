using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Contexts;
using UnitOfWork.Models;
using DataLayer.Entities;
using AutoMapper;


namespace UnitOfWork.Repositories
{
    class OrderRepository: GenericRepository<Order,UnitOrder>
    {
        public OrderRepository(IMapper mapper, StoreContext context): base(context, mapper) { }

       /* public async Task<UnitOrder> GetAsync()
        {
            var values = await _context.Orders.FindAsync();
        }*/
    }
}
