using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork.Interfaces
{
    public interface IRepository<Entity,UnitEntity> where Entity : class where UnitEntity : class
    {
        Task Create(UnitEntity entity);
        Task Delete(int id);
        Task Update(UnitEntity entity);
        Task<UnitEntity> Read(int id);
        Task<IEnumerable<UnitEntity>> ReadAll();
    }
}
