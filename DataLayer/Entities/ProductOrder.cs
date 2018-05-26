using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
