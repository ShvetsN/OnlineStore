using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Models
{
    public class OrderBLL
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public TypeOfDeliveryBLL DeliveryType { get; set; }
        public OrderStateBLL State { get; set; } = OrderStateBLL.InProcess;
        public ICollection<ProductOrderBLL> ProductOrders { get; set; } = new List<ProductOrderBLL>();
    }
}
