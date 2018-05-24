using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Contexts;
using DataLayer.Entities;
using UnitOfWork.Interfaces;
using UnitOfWork.Models;

namespace UnitOfWork.UnitOfWork
{
    public class UnitOfWorkPattern : IUnitOfWork
    {
        private readonly StoreContext _context;

        private readonly IOrderRepository _order;

        private readonly IRepository<Product, UnitProduct> _products;

        private readonly IRepository<Category, UnitCategory> _categories;

        public UnitOfWorkPattern(StoreContext context, IOrderRepository orders, IRepository<Product, UnitProduct> products,
                     IRepository<Category, UnitCategory> categories )
        {
            _context = context;
            _order = orders;
            _products = products;
            _categories = categories;
        }

        public IOrderRepository Orders
        {
            get
            {
                return _order;
            }
        }

        public IRepository<Product, UnitProduct> Products
        {
            get
            {
                return _products;
            }
        }

        public IRepository<Category, UnitCategory> Categories
        {
            get
            {
                return _categories;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

       private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
