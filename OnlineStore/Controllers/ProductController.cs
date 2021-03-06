﻿using BusinessLogicLayer.Interfaces;
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
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/product/create")] 
        public async Task<IActionResult> Create([FromBody] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.CreateProduct(_mapper.Map<ProductBLL>(product));
                if (result)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            else
                return BadRequest();
        }

        [HttpPut]
        [Route("/api/product/update")]
        public async Task<IActionResult> Update([FromBody] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.UpdateProduct(_mapper.Map<ProductBLL>(product));
                if (result)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            else
                return BadRequest();
        }

        [HttpDelete]
        [Route("/api/product/delete")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var result = await _productService.DeleteProduct(id);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
