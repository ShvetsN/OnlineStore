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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
    public class CategoryController : Controller
    {
        private readonly ICategoryManipulator _categoryManipulator;
        IMapper _mapper;

        public CategoryController(ICategoryManipulator categoryManipulator, IMapper mapper)
        {
            
                _categoryManipulator = categoryManipulator;
                _mapper = mapper;
            
        }

        [HttpPost]
        [Route("api/category/create")]
        public async Task<IActionResult> Create([FromBody] CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryManipulator.CreateCategory(_mapper.Map<CategoryBLL>(category));
                if (result)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            else return BadRequest();
        }

        [HttpPut]
        [Route("api/category/update")]
        public async Task<IActionResult> Update([FromBody] CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryManipulator.UpdateCategory(_mapper.Map<CategoryBLL>(category));
                if (result)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            else return BadRequest();
        }

        [HttpDelete]
        [Route("api/category/delete")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            
                var result = await _categoryManipulator.DeleteCategory(id);
                if (result)
                    return Ok(result);
                else
                    return BadRequest(result);
            
       
        }
    }
}
