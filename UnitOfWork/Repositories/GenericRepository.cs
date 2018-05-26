using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;
using DataLayer.Entities;
using DataLayer.Contexts;

namespace UnitOfWork.Repositories
{
    public class GenericRepository<Entity,UnitEntity> : IRepository<Entity,UnitEntity>  where Entity : class where UnitEntity : class
    {
        protected readonly StoreContext _context;
        protected readonly IMapper _mapper;

        public GenericRepository(StoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(UnitEntity entity)
        {
            var item = _mapper.Map<Entity>(entity);
            await _context.Set<Entity>().AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Set<Entity>().FindAsync(id);
            _context.Set<Entity>().Remove(item);
        }

        public async Task<UnitEntity> ReadAsync(int id)
        {
            var item = await _context.Set<Entity>().FindAsync(id);
            _context.Entry(item).State = EntityState.Detached;
            return _mapper.Map<UnitEntity>(item);
        }

        public async Task<IEnumerable<UnitEntity>> ReadAllAsync()
        {
            var items = await _context.Set<Entity>().AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<UnitEntity>>(items);
        }

        // Has to be checked
        public async Task UpdateAsync(UnitEntity entity)
        {
            var item = _mapper.Map<Entity>(entity);
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
