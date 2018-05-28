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
    public class ProductController : Controller
    {
        private readonly IProductManipulator _productManipulator;
        IMapper _mapper;

        public ProductController(IProductManipulator productManipulator, IMapper mapper)
        {
            _productManipulator = productManipulator;
            _mapper = mapper;
        }

        [HttpPost]
<<<<<<< HEAD
        [Route("/api/produtc/create")]
=======
        [Route("api/product/create")]
>>>>>>> 1d896b8ac7aca5954f0c38d82770d945b373ad2c
        public async Task<IActionResult> Create([FromBody] ProductModel product)
        {
            var result = await _productManipulator.CreateProduct(_mapper.Map<ProductBLL>(product));
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPut]
        [Route("/api/product/update")]
        public async Task<IActionResult> Update([FromBody] ProductModel product)
        {
            var result = await _productManipulator.UpdateProduct(_mapper.Map<ProductBLL>(product));
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete]
        [Route("/api/product/delete")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var result = await _productManipulator.DeleteProduct(id);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
