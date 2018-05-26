using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataLayer.Contexts;
using UnitOfWork.Models;
using DataLayer.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;
using System.Linq;

namespace UnitOfWork.Repositories
{
    public class OrderRepository: GenericRepository<Order,UnitOrder>, IOrderRepository
    {
        public OrderRepository(IMapper mapper, StoreContext context): base(context, mapper) { }

        public async Task<UnitOrder> ReadWithProductsAsync(int id)
        {
            var value = await _context.Orders.AsNoTracking().Include(c => c.Products).ThenInclude(p => p.Product).FirstOrDefaultAsync(o => o.Id == id);
            return _mapper.Map<UnitOrder>(value);
        }

        public async Task<IEnumerable<UnitOrder>> ReadAllWithProductsAsync()
        {
            var values = await _context.Orders.AsNoTracking().Include(c => c.Products).ThenInclude(p => p.Product).ToListAsync();
            return _mapper.Map<IEnumerable<UnitOrder>>(values);
        }

        public async Task AcceptOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            order.State = DataLayer.Entities.OrderState.Confirmed;
            _context.Entry(order).State = EntityState.Modified;
        }

        public async Task DeclineOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            order.State = DataLayer.Entities.OrderState.Canceled;
            _context.Entry(order).State = EntityState.Modified;
        }
    }
}
