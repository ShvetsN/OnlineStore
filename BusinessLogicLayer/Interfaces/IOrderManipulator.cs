using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IOrderManipulator
    {
        Task CreateOrder(int customerId, int[] products, TypeOfDeliveryBLL deliveryType); 
        Task Update(int id, bool confirmed);
    }
}
