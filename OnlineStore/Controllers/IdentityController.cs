using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using OnlineStore.Models;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork.Models;
using UnitOfWork.UnitOfWork;
using AutoMapper;

namespace OnlineStore.Controllers
{
    public class IdentityController: Controller
    {
        IIdentityService _userServices;
        IMapper _mapper;

        public IdentityController(IIdentityService userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }
        
        [HttpPost]
        [Route("api/registrate")]
        public async Task<IActionResult> Registration([FromBody] RegistrationUserModel user)
        {
            
            var token = await _userServices.Registrate(_mapper.Map<RegistrationUserBLL>(user));
            if ( token == null)
                BadRequest();
            return Ok(token);
        }

        [HttpPost]
        [Route("api/login")]
        public async Task<IActionResult> Login([FromBody] LoginUserModel user) 
        {
            var token = await _userServices.Login(_mapper.Map<LoginUserBLL>(user));
            if (token == null)
                BadRequest();
            return Ok(token);
        }
    }
}
