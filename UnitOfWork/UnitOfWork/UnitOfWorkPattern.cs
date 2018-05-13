using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;
using UnitOfWork.Interfaces;
using UnitOfWork.Models;

namespace UnitOfWork.UnitOfWork
{
    class UnitOfWorkPattern : IUnitOfWork
    {
        private readonly StoreContext _context;

        private readonly IRepository<Order, UnitOrder> _order;

        private readonly IRepository<Product, UnitProduct> _products;

        private readonly IRepository<Category, UnitCategory> _categories;

        public UnitOfWorkPattern(StoreContext context, IRepository<Order, UnitOrder> orders, IRepository<Product, UnitProduct> products,
                     IRepository<Category, UnitCategory> categories )
        {
            _context = context;
            _order = orders;
            _products = products;
            _categories = categories;
        }

        public IRepository<Order, UnitOrder> Orders
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


        public async void Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
