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
    public class OrderManipulator////IOrderManipulator
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public OrderManipulator(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateOrder(int customerId, int[] products, TypeOfDeliveryBLL deliveryType)
        {
            try
            {
                OrderBLL order = new OrderBLL { CustomerId = customerId, DeliveryType = deliveryType, Date = DateTime.Now };

                foreach (int a in products)
                {
                    order.Products.Add(new ProductOrderBLL { ProductId = a });
                }

                var unitOrder = _mapper.Map<UnitOrder>(order);
                await _unitOfWork.Orders.CreateAsync(unitOrder);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
