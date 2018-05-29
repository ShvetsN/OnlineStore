using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class BaseService
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected readonly IMapper _mapper;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
