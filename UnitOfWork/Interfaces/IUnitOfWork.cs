using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork.Models;

namespace UnitOfWork.Interfaces
{
    interface IUnitOfWork
    {
        IRepository<Order, UnitOrder> Orders { get; }
        IRepository<Product, UnitProduct> Products{ get; }
        IRepository<Category, UnitCategory> Categories { get; }
        void Save();
    }
}
