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
            else
                return BadRequest(res);
        }

        [HttpGet]
        [Route("api/showing/getcategory/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var result = await _showingController.GetForCategory(id);
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
            var result = await _showingController.Search(request);
            var res = _mapper.Map<IEnumerable<ProductModel>>(result);
            if (result != null)
                return Ok(res);
            else
                return BadRequest(res);
        }

        [HttpGet]
        [Route("api/showing/filter")]
        public async Task<IActionResult> Filter([FromBody] int min, [FromBody] int max)
        {
            var result = await _showingController.GetFilter(min, max);
            var res = _mapper.Map<IEnumerable<ProductModel>>(result);
            if (result != null)
                return Ok(res);
            else
                return BadRequest(res);
        }
    }
}
