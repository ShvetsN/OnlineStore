using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using OnlineStore.Models;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace OnlineStore.Controllers
{
    public class ShowingController
    {
        private readonly IShowing _showingController;
        IMapper _mapper;

        public ShowingController(IShowing showingController, IMapper mapper)
        {
            _showingController = showingController;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/showing/getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _showingController.GetAll();
            var res = _mapper.Map<IEnumerable<ProductModel>>(result);
            if (result != null)
                return Ok(res);
        }
    }
}
