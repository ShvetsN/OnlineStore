using AutoMapper;
using BusinessLogicLayer.Models;
using OnlineStore.Models;

namespace OnlineStore.Profiles
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<ProductModel, ProductBLL>();
            CreateMap<ProductBLL, ProductModel>();

            CreateMap<OrderModel, OrderBLL>();
            CreateMap<OrderBLL, OrderModel>();

            CreateMap<ProductOrderModel, ProductOrderBLL>();
            CreateMap<ProductOrderBLL, ProductOrderModel>();
        }
    }
}
