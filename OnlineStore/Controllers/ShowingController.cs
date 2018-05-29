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
    public class ShowingController :Controller
    {

        private readonly IShowingService _showingService;
        private readonly IMapper _mapper;

        public ShowingController(IShowingService showingService, IMapper mapper)
        {
            _showingService = showingService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/showing/getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _showingService.GetAll();
            var res = _mapper.Map<IEnumerable<ProductModel>>(result);
            if (result != null)
                return Ok(res);
            else
                return BadRequest(res);
        }

        [HttpGet]
        [Route("api/showing/getcategory/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var result = await _showingService.GetForCategory(id);
            var res = _mapper.Map<IEnumerable<ProductModel>>(result);
            if (result != null)
                return Ok(res);
            else
                return BadRequest(res);
        }

        [HttpGet]
        [Route("api/showing/search/{request}")]
        public async Task<IActionResult> Search(string request)
        {
            var result = await _showingService.Search(request);
            var res = _mapper.Map<IEnumerable<ProductModel>>(result);
            if (result != null)
                return Ok(res);
            else
                return BadRequest(res);
        }

        [HttpGet]
        [Route("api/showing/filter/{min}/{max}")]
        public async Task<IActionResult> Filter( int min, int max)
        {
            var result = await _showingService.GetFilter(min, max);
            var res = _mapper.Map<IEnumerable<ProductModel>>(result);
            if (result != null)
                return Ok(res);
            else
                return BadRequest(res);
        }
    }
}
