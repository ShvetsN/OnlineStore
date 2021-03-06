﻿using System;
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

    public class OrderService :BaseService, IOrderService
    {
     
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper): base(unitOfWork, mapper) { }    

        /**
         * ATTENTION!ATTENTION!ATTENTION! 
         * We could just use UnitOrder without OrderBLL and mapping but rusik13312 is a person without even rating on github
         * 
         */
        public async Task<bool> CreateOrder(OrderBLL order)
        {
            if (order.Products == null || order.Products.Count == 0)
                return false;
            try
            {
                order.Date = DateTime.Now;

                var unitOrder = _mapper.Map<UnitOrder>(order);

                await _unitOfWork.Orders.CreateAsync(unitOrder);
                await _unitOfWork.SaveAsync();

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
                var order = await _unitOfWork.Orders.ReadAsync(id);

                if (order.State != OrderState.InProcess) return false;

                if (confirmed)
                {
                    var products = await DecreaseAmountIfValid(id);
                    if (products != null)
                    {
                        foreach (var product in products)
                        {
                            await _unitOfWork.Products.UpdateAsync(product);
                        }
                        await _unitOfWork.Orders.AcceptOrder(id);
                    }
                    else
                    {
                        await _unitOfWork.Orders.DeclineOrder(id);
                    }
                }
                else
                {
                    await _unitOfWork.Orders.DeclineOrder(id);
                }

                await _unitOfWork.SaveAsync();
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
         * If there're not enough amount at any product returns null 
         */

        internal protected async Task<IEnumerable<UnitProduct>> DecreaseAmountIfValid(int id)

        {
            var order = await _unitOfWork.Orders.ReadWithProductsAsync(id);

            var resProds = new List<UnitProduct>();
            foreach (var productOrder in order.Products)
            {
                var item = resProds.Find(p => p.Id == productOrder.ProductId);
                if (item == null)
                {
                    item = productOrder.Product;
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
