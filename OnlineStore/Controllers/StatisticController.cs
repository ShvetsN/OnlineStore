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

namespace OnlineStore.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
    public class StatisticController: Controller
    {
        private readonly IStatisticService _statisticService;
        

        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
            
        }

        [HttpGet]
        [Route("/api/stat")]
        public async Task<IActionResult> Statistic()
        {
            DateTime date = DateTime.Today;
            var result = await _statisticService.GetOrdersOfSpecialDay(date);
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/stati")]
        public async Task<IActionResult> Stat()
        {
            ProductBLL product = new ProductBLL
            {
                Id = 1
            };
            var result = await _statisticService.GetAmountOfSpecialProductsInOrders(product);
            return Ok(result);
        }
    }
}
