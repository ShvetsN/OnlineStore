using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Models
{
    public class ProductOrderBLL
    {
        public int ProductId { get; set; }
        public ProductBLL Product { get; set; }

        public int OrderId { get; set; }
        public OrderBLL Order { get; set; }
    }
}
