using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Contexts;
using UnitOfWork.Models;
using DataLayer.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;

namespace UnitOfWork.Repositories
{
    public class OrderRepository: GenericRepository<Order,UnitOrder>, IOrderRepository
    {
        public OrderRepository(IMapper mapper, StoreContext context): base(context, mapper) { }

        public async Task<IEnumerable<UnitOrder>> ReadAllWithProductsAsync()
        {
            var values = await _context.Orders.Include(c => c.Products).ToListAsync();
            return _mapper.Map<IEnumerable<UnitOrder>>(values);
        }
    }
}
