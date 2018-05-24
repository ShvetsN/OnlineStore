using AutoMapper;
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
        }
    }
}
