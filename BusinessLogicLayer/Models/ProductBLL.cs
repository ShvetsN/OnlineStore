using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Models
{
    public class ProductBLL
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public int CategoryId { get; set; }
        //public double Price { get; set; }
        //public string Photo { get; set; }
        //public int Amount { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Photo { get; set; }

        public int Amount { get; set; }

        public int CategoryId { get; set; }

        public CategoryBLL Category { get; set; }

        public virtual ICollection<ProductOrderBLL> Orders { get; set; }
    }
}
