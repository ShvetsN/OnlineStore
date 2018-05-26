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

namespace OnlineStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryManipulator _categoryManipulator;
        IMapper _mapper;

        public CategoryController(ICategoryManipulator categoryManipulator, IMapper mapper)
        {
            _categoryManipulator = categoryManipulator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Create([FromBody] CategoryModel category)
        {
            var result = await _categoryManipulator.CreateCategory(_mapper.Map<CategoryBLL>(category));
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }

        public async Task<IActionResult> Update([FromBody] CategoryModel category)
        {
            var result = await _categoryManipulator.UpdateCategory(_mapper.Map<CategoryBLL>(category));
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
