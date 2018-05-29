using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager, Administrator")]
    public class StatisticController: Controller
    {
        private readonly IStatisticService _statisticService;
        private readonly IMapper _mapper;

        public StatisticController(IStatisticService statisticService, IMapper mapper)
        {
            _statisticService = statisticService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/api/statistic/specialday")]
        public async Task<IActionResult> Statistic([FromQuery] DateTime date)
        {
            var result = await _statisticService.GetOrdersOfSpecialDay(date);
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/statistic/products")]
        public async Task<IActionResult> Stat([FromQuery] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var result = await _statisticService.GetAmountOfSpecialProductsInOrders(_mapper.Map<ProductBLL>(product));
                return Ok(result);
            }
            else
                return BadRequest();
        }
    }
}
