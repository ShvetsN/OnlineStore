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
    public class OrderController : Controller
    {
        private readonly IOrderManipulator _orderManipulator;
        IMapper _mapper;

        public OrderController(IOrderManipulator orderManipulator, IMapper mapper)
        {
            _orderManipulator = orderManipulator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("api/order/create")]
        public async Task<IActionResult> Create([FromBody]int id, [FromBody]int[] products, [FromBody] TypeOfDeliveryModel type)
        {
            var result = await _orderManipulator.CreateOrder(id, products, _mapper.Map<TypeOfDeliveryBLL>(type));
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPut]
        [Route("/api/order/process")]
        public async Task<IActionResult> Process([FromBody]int id, [FromBody] bool confirmed)
        {
            var result = await _orderManipulator.Process(id, confirmed);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
