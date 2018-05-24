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
<<<<<<< HEAD

    public class OrderManipulator //: IOrderManipulator
=======
    public class OrderManipulator : IOrderManipulator
>>>>>>> 8c73c0a21fc1b410c4f16908841133c6cc3c68e1
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public OrderManipulator(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

<<<<<<< HEAD

        public async Task CreateOrder(int customerId, int[] products, TypeOfDeliveryBLL deliveryType)
=======
        /**
         * ATTENTION!ATTENTION!ATTENTION! 
         * We could just use UnitOrder without OrderBLL and mapping but rusik13312 is a person without even rating on github
         * 
         */
        public async Task<bool> CreateOrder(int customerId, int[] products, TypeOfDeliveryBLL deliveryType)
>>>>>>> 8c73c0a21fc1b410c4f16908841133c6cc3c68e1
        {
            try
            {
                OrderBLL order = new OrderBLL { CustomerId = customerId, DeliveryType = deliveryType, Date = DateTime.Now };

                foreach (int a in products)
                {
                    order.ProductOrders.Add(new ProductOrderBLL { ProductId = a });
                }

                var unitOrder = _mapper.Map<UnitOrder>(order);
                await _unitOfWork.Orders.CreateAsync(unitOrder);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Process(int id, bool confirmed)
        {   
            try
            {
                if (confirmed)
                {
                    var products = await DecreaseAmountIfValid(id);
                    if (products != null)
                    {
                        //Make other method
                        foreach (var product in products)
                        {
                            await _unitOfWork.Products.UpdateAsync(product);
                        }
                        //await _unitOfWork.Orders.AcceptOrder(id);
                    }
                    else
                    {
                        //await _unitOfWork.Orders.DeclineOrder(id);
                    }
                }
                else
                {
                    //await _unitOfWork.Orders.DeclineOrder(id);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /**
         * Get all products in order
         * Return collection of non-repeating products with updated amount
         * If there're not enough amount at any product return null 
         */
        protected async Task<IEnumerable<UnitProduct>> DecreaseAmountIfValid(int id)
        {
            //var item = Mapper.Map<OrderBLL>(_unitOfWork.Orders.ReadAsync(id));
            var order = await _unitOfWork.Orders.ReadAsync(id);

            var resProds = new List<UnitProduct>();
            foreach (var product in order.Products)
            {
                var item = resProds.Find(p => p.Id == product.Id);
                if (item == null)
                {
                    item = product;
                    resProds.Add(item);
                }
                item.Amount--;

                if (item.Amount < 0)
                {
                    return null;
                }
            }           

            return resProds;
        }
    }
}
