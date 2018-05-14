using DataLayer.Contexts;
using DataLayer.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;
using UnitOfWork.Models;

namespace UnitOfWork.Repositories
{
    class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }
        public async Task Authorized()
        {
          
        }

        public Task Create()
        {
            throw new NotImplementedException();
        }

        public  async Task Registrate()
        {
           
        }
    }
}
