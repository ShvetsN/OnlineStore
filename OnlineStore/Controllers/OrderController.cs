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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        
        [HttpPost]
        [Authorize(Roles = "User")]
        [Route("api/order/create")]
        public async Task<IActionResult> Create([FromBody]int id, [FromBody]int[] products, [FromBody] TypeOfDeliveryModel type)
        {
            
                var result = await _orderService.CreateOrder(id, products, _mapper.Map<TypeOfDeliveryBLL>(type));
                if (result)
                    return Ok(result);
                else
                    return BadRequest(result);
            
        }

        [HttpPut]
        [Route("/api/order/process")]
        public async Task<IActionResult> Process([FromBody]int id, [FromBody] bool confirmed)
        {
            var result = await _orderService.Process(id, confirmed);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
