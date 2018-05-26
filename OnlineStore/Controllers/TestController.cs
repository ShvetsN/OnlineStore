using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;

namespace OnlineStore.Controllers
{
    [Produces("application/json")]
    [Route("api/test")]
    public class TestController : Controller
    {
        IOrderManipulator _ordManplr;
        IMapper _mapper;
        IProductManipulator _prdManplr;
        public TestController(IOrderManipulator ord, IMapper mapper, IProductManipulator prd)
        {
            _ordManplr = ord;
            _mapper = mapper;
            _prdManplr = prd;
        }

        /***
         * !!!!!!!!!!!!!
         * Made for test
         * !!!!!!!!!!!!!
         */
        [HttpGet("order")]
        public async Task<IActionResult> CreateOrder()
        {
            await _ordManplr.CreateOrder(1, new int[] { 1, 3 }, TypeOfDeliveryBLL.CourierDelivery);
            ProductBLL prd = new ProductBLL { CategoryId = 1, Name = "Igor Moobile" };
            await _prdManplr.CreateProduct(prd);

            return new ObjectResult("Success");
        }

        [HttpGet("product/add")]
        public async Task<IActionResult> CreateProduct()
        {
            ProductBLL prd = new ProductBLL { CategoryId = 1, Name = "Igor Moobile" };
            await _prdManplr.CreateProduct(prd);

            return new ObjectResult("Success");
        }

        [HttpGet("product/update")]
        public async Task<IActionResult> UpdateProduct()
        {
            ProductBLL prd = new ProductBLL { CategoryId = 1, Name = "Igor Kuznetsov", Id = 6 };
            await _prdManplr.UpdateProduct(prd);

            return new ObjectResult("Success");
        }

        [HttpGet("product/delete")]
        public async Task<IActionResult> DeleteProduct()
        {
            await _prdManplr.DeleteProduct(6);

            return new ObjectResult("Success");
        }

        [HttpGet("order/confirm")]
        public async Task<IActionResult> ConfirmOrder()
        {
            await _ordManplr.Process(2, true);

            return new ObjectResult("Success");
        }
    }
}
 