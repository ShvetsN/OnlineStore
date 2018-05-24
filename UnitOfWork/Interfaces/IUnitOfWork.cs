using DataLayer.Entities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using UnitOfWork.Models;

namespace UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository Orders { get; }
        IRepository<Product, UnitProduct> Products{ get; }
        IRepository<Category, UnitCategory> Categories { get; }
        Task SaveAsync();
    }
}
