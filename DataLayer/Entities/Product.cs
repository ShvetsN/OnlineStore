using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Product : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public string Photo { get; set; }
        public int Amount { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<ProductOrder> Orders { get; set; }
    }
}
