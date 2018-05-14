using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.Interfaces
{
    interface IUserUnitOfWork<T>: IDisposable where T:class
    {
        IUserRepository UsersProfile { get; }
        UserManager<T> UserManager { get; }
        RoleManager<T> RoleManager { get; }

        Task SaveAsync();
    }
}
