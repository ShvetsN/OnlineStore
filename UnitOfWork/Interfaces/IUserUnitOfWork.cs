﻿using DataLayer.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.Interfaces
{
    interface IUserUnitOfWork : IDisposable
    {
        UserManager<User> UserManager { get; }
        RoleManager<User> RoleManager { get; }
        Task SaveAsync();
    }
}
