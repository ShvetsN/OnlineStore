using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;
using DataLayer.Entities;

namespace UnitOfWork.Repositories
{
    class GenericRepository<Entity,UnitEntity> : IRepository<Entity,UnitEntity>  where Entity : class where UnitEntity : class
    {
        private readonly StoreContext _context;
        private readonly IMapper _mapper;

        public GenericRepository(StoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(UnitEntity entity)
        {
            var item = _mapper.Map<Entity>(entity);
            await _context.Set<Entity>().AddAsync(item);
        }

        public async Task Delete(int id)
        {
            var item = await _context.Set<Entity>().FindAsync(id);
            _context.Set<Entity>().Remove(item);
        }

        public async Task<UnitEntity> Read(int id)
        {
            var item = await _context.Set<Entity>().FindAsync(id);
            return _mapper.Map<UnitEntity>(item);
        }

        public async Task<IEnumerable<UnitEntity>> ReadAll()
        {
            var items = await _context.Set<Entity>().FindAsync();
            return _mapper.Map<IEnumerable<UnitEntity>>(items);
        }

        // Has to be checked
        public async Task Update(UnitEntity entity)
        {
            var item = _mapper.Map<Entity>(entity);
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
