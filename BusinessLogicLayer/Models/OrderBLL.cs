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
        public DeliveryType DeliveryType { get; set; }
        public OrderState State {get;set;}
        //public virtual ICollection<ProductOrder> Products { get; set; }
    }
}
