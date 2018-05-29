using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public TypeOfDeliveryModel DeliveryType { get; set; }
        public OrderStateModel State { get; set; } = OrderStateModel.InProcess;
        [Required]
        public ICollection<ProductOrderModel> Products { get; set; } = new List<ProductOrderModel>();
    }
}
