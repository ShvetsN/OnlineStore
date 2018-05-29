using AutoMapper;
using DataLayer.Entities;
using DataLayer.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork.Models;

namespace UnitOfWork.Profiles
{
    public class UnitOfWorkProfile: Profile
    {
        public UnitOfWorkProfile()
        {
            CreateMap<RegistrationUser, User>().ReverseMap();

            CreateMap<UnitOrder, Order>();
            CreateMap<Order, UnitOrder>();

            CreateMap<ProductOrder, UnitProductOrder>();
            CreateMap<UnitProductOrder, ProductOrder>();

            CreateMap<Product, UnitProduct>();
            CreateMap<UnitProduct, Product>();

        }
    }
}
