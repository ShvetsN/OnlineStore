using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork.UnitOfWork;

namespace BusinessLogicLayer.Services
{
    public class UserServices
    {
        private readonly UserUnitOfWork _userUnitOfWork;

        public UserServices(UserUnitOfWork userUnitOfWork)
        {
            _userUnitOfWork = userUnitOfWork;
        }
    }
}
