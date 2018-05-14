using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork.Interfaces
{
    interface IUserRepository
    {
        Task Create();
    }
}
