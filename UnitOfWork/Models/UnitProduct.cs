using System;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork.Models
{
    public class UnitProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public string Photo { get; set; }
        public int Amount { get; set; }
    }
}
