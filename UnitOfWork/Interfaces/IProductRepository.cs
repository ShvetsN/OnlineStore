using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Models;

namespace UnitOfWork.Interfaces
{
    public interface IProductRepository: IRepository<Product, UnitProduct>
    {
        Task<IEnumerable<UnitProduct>> ReadAllWithCategoryAsync();
    }
}
