using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IOrderManipulator
    {
        Task<bool> CreateOrder(int customerId, int[] products, TypeOfDeliveryBLL deliveryType); 
        Task<bool> Process(int id, bool confirmed);
    }
}
