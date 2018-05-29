using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class ProductOrderModel
    {
        [Required]
        [Range(1,10000)]
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
        [Required]
        [Range(1,1000)]
        public int OrderId { get; set; }
        public OrderModel Order { get; set; }
    }
}
