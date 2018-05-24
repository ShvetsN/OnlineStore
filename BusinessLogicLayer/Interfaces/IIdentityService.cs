using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IIdentityService
    {
        Task<string> Login(LoginUserBLL loginUser);
        Task<string> Registrate(RegistrationUserBLL registrationUser);
    }
}
