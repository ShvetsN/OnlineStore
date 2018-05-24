using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork.Models;
using UnitOfWork.UnitOfWork;

namespace OnlineStore.Controllers
{
    public class IdentityController: Controller
    {
       // UnitOfWorkPattern _unitOfWorkPattern;
        IIdentityService _userServices;

        public IdentityController(IIdentityService userServices)
        {
            _userServices = userServices;
        }
        
        [HttpPost]
        [Route("api/registrate")]
        public async Task<IActionResult> Registration([FromBody] RegistrationUserBLL user)
        {
            var token = await _userServices.Registrate(user);
            if ( token == null)
                BadRequest();
            return Ok(token);
        }

        [HttpPost]
        [Route("api/login")]
        public async Task<IActionResult> Login([FromBody] LoginUserBLL user) 
        {
            var token = await _userServices.Login(user);
            if (token == null)
                BadRequest();
            return Ok(token);
        }

    }
}
