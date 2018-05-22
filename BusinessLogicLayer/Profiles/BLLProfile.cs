using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using UnitOfWork.Models;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Profiles
{
    class BLLProfile : Profile
    {
        public BLLProfile()
        {
            CreateMap<UnitOrder, OrderBLL>();
            CreateMap<UnitProduct, ProductBLL>();
        }
    }
}
