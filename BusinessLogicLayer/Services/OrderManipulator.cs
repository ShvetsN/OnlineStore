using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using UnitOfWork.Interfaces;
using UnitOfWork.Models;


namespace BusinessLogicLayer.Services
{
    public class OrderManipulator //: IOrderManipulator
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public OrderManipulator(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

       /* public async Task<OrderBLL> CreateOrder(OrderBLL order)
        {
            try
            {
                order.Date = DateTime.Now;


            }
            catch (Exception)
            {
                return null;
            }
        }*/
    }
}
