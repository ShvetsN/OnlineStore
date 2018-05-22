using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Identity;
using DataLayer.Сontexts;
using Microsoft.AspNetCore.Identity;
using UnitOfWork.Interfaces;

namespace UnitOfWork.UnitOfWork
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly UserContext _context;

        private readonly SignInManager<User> _signInManager;

        private readonly UserManager<User> _userManager;

        private readonly RoleManager<User> _roleManager;

        public UserUnitOfWork(UserManager<User> userManager, RoleManager<User> roleManager, UserContext context)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public SignInManager<User> SignInManager
        {
            get
            {
                return _signInManager;
            }
        }

        public UserManager<User> UserManager
        {
            get
            {
                return _userManager;
            }
        }

        public RoleManager<User> RoleManager
        {
            get
            {
                return _roleManager;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _userManager.Dispose();
                    _roleManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
