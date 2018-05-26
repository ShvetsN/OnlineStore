using DataLayer.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Models;

namespace UnitOfWork.Interfaces
{
    public interface IUserUnitOfWork
    {
        Task<string> AuthorizationAsync(LoginUser user);
        Task<string> RegistrationAsync(RegistrationUser user);
    }
}
