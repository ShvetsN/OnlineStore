using System;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork.Models
{
    public class UnitOrder
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime Date { get; set; }

        public TypeOfDelivery DeliveryType { get; set; }

        public OrderState State { get; set; }

        public ICollection<UnitProductOrder> Products { get; set; }
    }
}
