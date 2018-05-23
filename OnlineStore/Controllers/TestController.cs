using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork.Models;
using UnitOfWork.UnitOfWork;

namespace OnlineStore.Controllers
{
    public class TestController: Controller
    {
        UnitOfWorkPattern _unitOfWorkPattern;

        public TestController(UnitOfWorkPattern unitOfWorkPattern)
        {
            _unitOfWorkPattern = unitOfWorkPattern;
        }

        [HttpPost]
        [Route("api/categories/add")]
        public IActionResult Add([FromBody] UnitCategory unitCategory)
        {
            _unitOfWorkPattern.Categories.CreateAsync(unitCategory);
            return Ok(unitCategory);
        }
    }
}
