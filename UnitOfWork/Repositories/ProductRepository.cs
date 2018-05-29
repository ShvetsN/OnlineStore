using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.Contexts;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using UnitOfWork.Interfaces;
using UnitOfWork.Models;

namespace UnitOfWork.Repositories
{
    public class ProductRepository: GenericRepository<Product, UnitProduct>, IProductRepository
    {
        public ProductRepository(StoreContext context, IMapper mapper) : base(context, mapper) { }

       /* public async Task<UnitProduct> ReadWithCategoryAsync(int id)
        {
            var value = await _context.Orders.AsNoTracking().Include(c => c.Products).ThenInclude(p => p.Product).FirstOrDefaultAsync(o => o.Id == id);
            return _mapper.Map<UnitOrder>(value);
        }*/

        public async Task<IEnumerable<UnitProduct>> ReadAllWithCategoryAsync()
        {
            var list = await _context.Product.Include(c => c.Category).ToListAsync();
            return _mapper.Map<IEnumerable<UnitProduct>>(list);
        }
    }
}
