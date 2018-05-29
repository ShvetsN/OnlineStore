using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork.Interfaces;
using UnitOfWork.Models;
using UnitOfWork.Repositories;

namespace UnitOfWork.Extensions
{
    public static class EntryUniotOfWorkExtension
    {
        public static GenericRepository<DataLayer.Entities.Entity, Models.UnitEntity> Entry<UnitEntity>(this IUnitOfWork uof) 
        {
            if (typeof(UnitEntity).Equals(typeof(UnitCategory)))
            {
                return uof.Categories as GenericRepository<DataLayer.Entities.Entity, Models.UnitEntity>;
            }
            else if (typeof(UnitEntity).Equals(typeof(UnitProduct)))
            {
                return uof.Products as GenericRepository<Entity, Models.UnitEntity>;
            }
            else
            {
                return null;
            }

        }
    }
}
