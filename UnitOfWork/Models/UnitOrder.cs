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
        // TypeOfDelivery
        // Accepted
    }
}
