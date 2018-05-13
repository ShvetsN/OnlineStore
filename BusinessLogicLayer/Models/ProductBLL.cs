using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Models
{
    class ProductBLL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public string Photo { get; set; }
        public int Amount { get; set; }
    }
}
