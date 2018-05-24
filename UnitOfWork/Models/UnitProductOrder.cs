using System;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork.Models
{
    public class UnitProductOrder
    {
        public int ProductId { get; set; }

        public UnitProduct Product { get; set; }

        public int OrderId { get; set; }

        public UnitOrder Order { get; set; }
    }
}
