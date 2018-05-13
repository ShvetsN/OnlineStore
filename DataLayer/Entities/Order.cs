using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        // TypeOfDelivery
        // Accepted

        public virtual ICollection<ProductOrder> Products { get; set; }
    }
}

