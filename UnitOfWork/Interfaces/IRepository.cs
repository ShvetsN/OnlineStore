using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork.Interfaces
{
    public interface IRepository<Entity,UnitEntity> where Entity : DataLayer.Entities.Entity where UnitEntity : Models.UnitEntity
    {
        Task CreateAsync(UnitEntity entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(UnitEntity entity);
        Task<UnitEntity> ReadAsync(int id);
        Task<IEnumerable<UnitEntity>> ReadAllAsync();
    }
}
