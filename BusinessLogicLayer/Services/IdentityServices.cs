using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;
using UnitOfWork.Models;
using UnitOfWork.UnitOfWork;

namespace BusinessLogicLayer.Services
{
    public class IdentityServices: IIdentityService
    {
        private readonly IUserUnitOfWork _userUnitOfWork;

        private readonly IMapper _mapper;

        public IdentityServices(IUserUnitOfWork userUnitOfWork, IMapper mapper)
        {
            _userUnitOfWork = userUnitOfWork;
            _mapper = mapper;
        }

        public async Task<string> Login(LoginUserBLL loginUser)
        {
            try
            {
                var user = _mapper.Map<LoginUser>(loginUser);
                return await _userUnitOfWork.AuthorizationAsync(user);
            }
            catch (Exception)
            {
                return null;
            }    
        }

        public async Task<string> Registrate(RegistrationUserBLL registrationUser)
        {
            try
            {
                var user = _mapper.Map<RegistrationUser>(registrationUser);
                return await _userUnitOfWork.RegistrationAsync(user);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
