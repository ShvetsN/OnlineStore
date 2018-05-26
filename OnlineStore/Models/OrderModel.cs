using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public TypeOfDeliveryModel DeliveryType { get; set; }
        public OrderStateModel State { get; set; } = OrderStateModel.InProcess;
        public ICollection<ProductOrderModel> Products { get; set; } = new List<ProductOrderModel>();
    }
}
