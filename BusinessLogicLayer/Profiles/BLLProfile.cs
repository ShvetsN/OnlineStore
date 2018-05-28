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
            CreateMap<CategoryBLL, UnitCategory>().ReverseMap();
            CreateMap<IEnumerable<UnitProduct>, List<ProductBLL>>();

            CreateMap<UnitProduct, ProductBLL>();
            CreateMap<ProductBLL, UnitProduct>();

            CreateMap<UnitOrder, OrderBLL>();
            CreateMap<OrderBLL, UnitOrder>();

            CreateMap<UnitProductOrder, ProductOrderBLL>();
            CreateMap<ProductOrderBLL, UnitProductOrder>();
        }
    }
}
